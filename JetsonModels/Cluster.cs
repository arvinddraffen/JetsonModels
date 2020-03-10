using JetsonWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JetsonModels
{
    /// <summary>
    /// <see cref="Cluster"/> holds utilization stats for a particular cluster.
    /// </summary>
    public class Cluster
    {
        /// <summary>
        /// Gets or sets the Id of the cluster.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the collection of nodes which constitute the cluster.
        /// </summary>
        public virtual ICollection<Node> Nodes { get; set; }

        /// <summary>
        /// Gets or sets the collection of statistics from sreport.
        /// </summary>
        public virtual ICollection<SreportUtilization> SreportUtilizations { get; set; }
    }
}
