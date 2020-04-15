using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace JetsonModels.Communication
{
    /// <summary>
    /// <see cref="NodeIdentityUpdate"/> defines the message sent from nodes to update
    /// node identity and environmental information.
    /// </summary>
    public class NodeIdentityUpdate
    {
        public int NodeId { get; set; }

        public int ClusterId { get; set; }

        public string NodeIPAddress { get; set; }

        public int NodeUpTimeSeconds { get; set; }

        public string OperatingSystem { get; set; }
    }
}
