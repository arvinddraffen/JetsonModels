using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JetsonModels
{
    /// <summary>
    /// <see cref="Node"/> holds the data of a particular node in order to report utilization.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets or sets the Id of this <see cref="Node"/>.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the IP Address of this <see cref="Node"/>.
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the list containing sampled utilization statistics of this <see cref="Node"/>.
        /// </summary>
        public virtual ICollection<NodeUtilization> Utilization { get; set; }

        public virtual ICollection<NodePower> Power { get; set; }

        public virtual ICollection<CpuCore> Cores { get; set; }
    }
}
