using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JetsonModels
{
    /// <summary>
    /// <see cref="Node"/> holds the data of a particular node in order to report utilization.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Gets or sets the Id of the node.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the IP Address of the node.
        /// </summary>
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the list containing sampled utilization statistics of the node.
        /// </summary>
        public virtual ICollection<NodeUtilization> NodeUtilizations { get; set; }
    }
}
