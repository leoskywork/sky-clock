using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigClock
{
    public class ClockSettingArgs
    {
        public float CurrentClockSize { get; set; }

        public string PreviewValue { get; set; }

        public ClockFace CurrentFace { get; set; }
    }

    public class ClockSettingChangeArgs : EventArgs
    {
        public float FontSize { get; set; }
    }
}
