using System;
using System.Collections.Generic;

namespace JetsonModels
{
    /// <summary>
    /// <see cref="NodeUtilization"/> holds the utilization statistics of the node at a particular point in time.
    /// </summary>
    public class NodeUtilization
    {
        /// <summary>
        /// Gets or sets a unique identifier for this <see cref="NodeUtilization"/> data point.
        /// </summary>
        public uint Id { get; set; }

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

        public uint GlobalNodeId { get; set; }
    }
}
