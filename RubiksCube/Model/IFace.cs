using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RubiksCube
{
    internal interface IFace
    {
        public Vector2 Dimension { get; }
        public bool FaceCompleted();
        public Color GetPlateColor(int i);
        public void SetPlateColor(int i, Color c);
    }
}
