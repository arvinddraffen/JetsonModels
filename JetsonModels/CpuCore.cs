using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JetsonModels
{
    public class CpuCore
    {
        [Key]
        public uint CoreNumber { get; set; }

        /// <summary>
        /// Percentage of time the CPU is busy.
        /// </summary>
        public float UtilizationPercentage { get; set; }
    }
}
