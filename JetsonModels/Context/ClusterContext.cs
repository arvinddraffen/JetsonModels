using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JetsonModels.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace JetsonModels.Context
{
    /// <summary>
    /// <see cref="ClusterContext"/> provides an interface to the SQLite database with EntityFramework.
    /// </summary>
    public class ClusterContext : DbContext
    {
        public static readonly Microsoft.Extensions.Logging.LoggerFactory DebugLoggingFactory =
           new Microsoft.Extensions.Logging.LoggerFactory(new[]
           {
                new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider(),
           });

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusterContext"/> class.
        /// </summary>
        /// <param name="asNoTracking">
        /// Determines whether global object tracking should be turned off or on
        /// with Entity Framework. If object tracking is enabled, the database will
        /// be automatically generated if needed.
        /// </param>
        public ClusterContext(DbContextOptions options, bool asNoTracking = false) : base(options)
        {
            if (asNoTracking)
            {
                this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }
            else
            {
                this.Database.EnsureCreated();
            }
        }

        /// <summary>
        /// Gets or sets the list of clusters (<see cref="Cluster"/>) which constitute the system.
        /// </summary>
        public DbSet<Cluster> Clusters { get; set; }

        /// <summary>
        /// Gets or sets the database set of all Node Power Entries (<see cref="NodePower"/>) in the database.
        /// </summary>
        public DbSet<NodePower> PowerData { get; set; }

        /// <summary>
        /// Gets or sets the database set of all Node Utilization Entries (<see cref="UtilizationData"/>) in the database.
        /// </summary>
        public DbSet<NodeUtilization> UtilizationData { get; set; }

        /// <inheritdoc/>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.SetupPrimaryKeys(modelBuilder);
            this.SetupValueConversions(modelBuilder);
            this.SetupIndexes(modelBuilder);
        }

        /// <summary>
        /// Assigns primary keys and associated database generation strategies to the storage types defined in <see cref="JetsonModels"/>.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        private void SetupPrimaryKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cluster>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Node>()
                .HasKey(x => x.GlobalId);
            modelBuilder.Entity<Node>()
                .Property(x => x.GlobalId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<NodePower>()
              .HasKey(x => x.Id);
            modelBuilder.Entity<NodePower>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<NodeUtilization>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<NodeUtilization>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }

        /// <summary>
        /// Assigns <see cref="ValueConverter"/>s to properties in <see cref="JetsonModels"/> to optimize storage in SQLite.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        private void SetupValueConversions(ModelBuilder modelBuilder)
        {
            // Setup value conversion for CpuCore since CPU cores don't need primary keys
            modelBuilder.Entity<NodeUtilization>()
                .Property(x => x.Cores)
                .HasConversion(new CpuCoreToStringConverter());

            // Store Timestamps as Integer type in SQLite, not TEXT.
            // Human readability is not critical, but ordering and lookup speed by relative time is.
            modelBuilder.Entity<NodeUtilization>()
                .Property(x => x.TimeStamp)
                .HasConversion(new DateTimeToTicksConverter());

            modelBuilder.Entity<NodePower>()
                .Property(x => x.Timestamp)
                .HasConversion(new DateTimeToTicksConverter());
        }

        /// <summary>
        /// Creates database indexes to speedup lookups on frequently used properties in <see cref="JetsonModels"/>.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        private void SetupIndexes(ModelBuilder modelBuilder)
        {
            // Index on NodeUtilization GlobalNodeId to speedup lookups
            modelBuilder.Entity<NodeUtilization>()
                .HasIndex(x => x.GlobalNodeId);

            // Index on NodePower GlobalNodeId to speedup lookups
            modelBuilder.Entity<NodePower>()
                .HasIndex(x => x.GlobalNodeId);

            // Index on NodeUtilization TimeStamp to speedup lookups
            modelBuilder.Entity<NodeUtilization>()
                .HasIndex(x => x.TimeStamp);

            // Index on NodePower TimeStamp to speedup lookups
            modelBuilder.Entity<NodePower>()
                .HasIndex(x => x.Timestamp);
        }
    }
}
