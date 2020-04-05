using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JetsonModels.Database
{
    /// <summary>
    /// <see cref="Cluster"/> holds utilization stats for a particular cluster.
    /// </summary>
    public class Cluster
    {
        /// <summary>
        /// Holds the possible types for the <see cref="Cluster"/>.
        /// </summary>
        public enum ClusterType
        {
            RaspberryPi,
            Jetson,
            Odroid,
            GenericX86,
            GenericARM,
            Other,
        }

        /// <summary>
        /// Gets or sets the Id of the cluster.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the <see cref="Cluster"/>.
        /// </summary>
        public string ClusterName { get; set; }

        /// <summary>
        /// Gets or sets the collection of nodes which constitute the cluster.
        /// </summary>
        public List<Node> Nodes { get; set; }

        /// <summary>
        /// Gets or sets the rate at which <see cref="Node"/>s in the <see cref="Cluster"/> produce new data.
        /// </summary>
        public TimeSpan RefreshRate { get; set; }

        /// <summary>
        /// Gets or sets the type of the <see cref="Cluster"/> as per types defined in <see cref="ClusterType"/>.
        /// </summary>
        public ClusterType Type { get; set; }
    }
}
