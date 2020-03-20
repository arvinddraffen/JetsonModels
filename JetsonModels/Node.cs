using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JetsonModels
{
    /// <summary>
    /// <see cref="Node"/> holds the data of a particular node in order to report utilization.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets or sets a globally unique identifier for this <see cref="Node"/>.
        /// This identifier can uniquely identifies <see cref="Node"/>s across all <see cref="Cluster"/>s.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint GlobalId { get; set; }

        /// <summary>
        /// Gets or sets the Id of this <see cref="Node"/> within it's <see cref="Cluster"/>.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the IP Address of this <see cref="Node"/>.
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the list containing sampled utilization statistics of this <see cref="Node"/>.
        /// </summary>
        public virtual ICollection<NodeUtilization> Utilization { get; set; }

        /// <summary>
        /// Gets or sets the list containing sampled power statistics of this <see cref="Node"/>.
        /// </summary>
        public virtual ICollection<NodePower> Power { get; set; }
    }
}
