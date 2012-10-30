using System.Collections.Generic;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace TPVTAC_WPF
{
    public class miMesa : Thumb
    {
        public List<LineGeometry> EndLines { get; private set; }
        public List<LineGeometry> StartLines { get; private set; }

        public miMesa(): base() 
        {
            StartLines = new List<LineGeometry>();
            EndLines = new List<LineGeometry>();
        }
    }
}
