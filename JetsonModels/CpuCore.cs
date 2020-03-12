using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JetsonModels
{
    /// <summary>
    /// <see cref="CpuCore"/> holds the utilization statistics for a particular core within a node.
    /// </summary>
    public class CpuCore
    {
        /// <summary>
        /// Gets or sets the core number of the core within the node.
        /// </summary>
        [Key]
        public uint CoreNumber { get; set; }

        /// <summary>
        /// Gets or sets the percentage of time the core is busy.
        /// </summary>
        public float UtilizationPercentage { get; set; }
    }
}
