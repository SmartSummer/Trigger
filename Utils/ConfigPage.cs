using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TriggerBigImage
{
    public class ConfigPage
    {

        public long MaxWidth { get; set; }
        public long MaxHeight { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string ImageCount { get; set; }
        public string OffsetX { get; set; }
        public string OffsetY { get; set; }
        public string ExposeTime { get; set; }
        public bool save { get; set; }
    }
}
