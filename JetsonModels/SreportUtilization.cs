using System;
using System.ComponentModel.DataAnnotations;

namespace JetsonWeb.Models
{
    /// <summary>
    /// <see cref="SreportUtilization"></see> model.
    /// </summary>
    /// <remarks>
    /// Contents based on default report contents as listed in: https://slurm.schedmd.com/sreport.html.
    /// </remarks>
    public class SreportUtilization
    {
        /// <summary>
        /// Gets or sets the unique primary key for the utilization report retrieved.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the cluster for which the utilization report is generated.
        /// </summary>
        public string Cluster { get; set; }

        /// <summary>
        /// Gets or sets the time (as a percentage) nodes were in use with active jobs or an active reservation.
        /// </summary>
        public float Allocated { get; set; }

        /// <summary>
        /// Gets or sets the time (as a percentage) that nodes were marked Down or time that clurmctld was not responding.
        /// (assuming TrackSlurmctldDown is set in slurmdbd.conf).
        /// </summary>
        public float Down { get; set; }

        /// <summary>
        /// Gets or sets the time (as a percentage) that nodes were in use by a reservation created with the MAINT.
        /// flag but not the IGNORE_JOBS flag.
        /// </summary>
        public float PlannedDown { get; set; }

        /// <summary>
        /// Gets or sets the time (as a percentage) where nodes had no active jobs or reservations.
        /// </summary>
        public float Idle { get; set; }

        /// <summary>
        /// Gets or sets the time (as a percentage) that a node spent idle with eligible jobs in the queue that were unable
        /// to start due to time or size constraints.
        /// </summary>
        public float Reserved { get; set; }

        /// <summary>
        /// Gets or sets the total time (as a percentage) reported by all fields in the utilization report.
        /// </summary>
        public float Reported { get; set; }

        /// <summary>
        /// Gets or sets the start time of the report in DateTime format.
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Gets or sets the end time of the report in DateTime format.
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
    }
}
