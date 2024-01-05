using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RubiksCube
{
    internal class Plate
    {
        private Color color;
        public Color Color { get { return color; } set { color = value; } }

        public Plate(Color c) { color = c; }
        public Plate(){ color = Color.FromArgb(255, 0, 0, 0); }

    }
}
