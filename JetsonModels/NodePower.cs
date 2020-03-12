using System;
using System.Collections.Generic;
using System.Text;

namespace JetsonModels
{
    public class NodePower
    {
        public uint Id { get; set; }        // change for all to uint

        public DateTime Timestamp { get; set; }

        public float Current { get; set; }

        public float Voltage { get; set; }
    }
}
