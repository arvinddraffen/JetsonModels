using System;
using System.Collections.Generic;
using System.Text;

namespace JetsonModels
{
    /// <summary>
    /// <see cref="NodePower"/> contains the statistics for reporting power on a specific node.
    /// </summary>
    public class NodePower
    {
        /// <summary>
        /// Gets or sets the unique Id for this <see cref="NodePower"/>.
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Gets or sets the timestamp at which this sampling of power was obtained.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the current of the node, expressed in amps.
        /// </summary>
        public float Current { get; set; }

        /// <summary>
        /// Gets or sets the voltage of the node, expressed in volts.
        /// </summary>
        public float Voltage { get; set; }

        /// <summary>
        /// Gets or sets the power usage of the node, expressed in watts.
        /// </summary>
        public float Power { get; set; }

        public uint GlobalNodeId { get; set; }
    }
}
