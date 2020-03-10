using System;
using System.Collections.Generic;
using System.Text;

namespace JetsonModels
{
    /// <summary>
    /// <see cref="NodeUtilization"/> holds the utilization statistics of the node at a particular point in time.
    /// </summary>
    public class NodeUtilization
    {
        /// <summary>
        /// Gets or sets the timestamp at which the statistics were obtained.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the CPU utilization of the node.
        /// </summary>
        public float CPUUtilization { get; set; }

        /// <summary>
        /// Gets or sets the memory utilization of the node.
        /// </summary>
        public float MemoryUtilization { get; set; }

        /// <summary>
        /// Gets or sets the power usage of the node.
        /// </summary>
        public float PowerUsage { get; set; }
    }
}
