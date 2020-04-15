using System;
using System.Collections.Generic;
using System.Text;
using JetsonModels.Database;

namespace JetsonModels.Communication
{
    /// <summary>
    /// <see cref="NodeUtilizationUpdate"/> defines the message used to encapsulate utilization statistic
    /// updates from each node within a cluster.
    /// </summary>
    public class NodeUtilizationUpdate
    {
        public int NodeId { get; set; }

        public int ClusterId { get; set; }

        /// <summary>
        /// Gets or sets the timestamp at which the statistics were obtained.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the list of cores which constitute this <see cref="Node"/>.
        /// </summary>
        public virtual ICollection<CpuCore> Cores { get; set; }

        /// <summary>
        /// Gets or sets the total memory available on this <see cref="Node"/>, expressed in megabytes.
        /// </summary>
        public uint MemoryAvailable { get; set; }

        /// <summary>
        /// Gets or sets the total memory used on this <see cref="Node"/>, expressed in megabytes.
        /// </summary>
        public uint MemoryUsed { get; set; }
    }
}
