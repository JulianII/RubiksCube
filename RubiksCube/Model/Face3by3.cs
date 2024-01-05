using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RubiksCube
{
    internal class Face3by3 : IFace
    {

        public Vector2 Dimension { get; }

        private Plate[] plates;
        public Face3by3(Plate p)
        {
            Dimension = new Vector2(3, 3);

            plates = new Plate[9];

            for (int i = 0; i < 9; ++i)
            {
                plates[i] = new Plate(p.Color);
            }
        }

        public Color GetPlateColor(int i)
        {
            if (i > plates.Length) throw new ArgumentOutOfRangeException();

            return plates[i].Color;
        }

        public void SetPlateColor(int i, Color c)
        {
            if (i > plates.Length) throw new ArgumentOutOfRangeException();

            plates[i].Color = c;
        }

        public bool FaceCompleted()
        {
            for(int i = 0; i < 8; ++i) 
            {
                if (plates[i] != plates[i+1]) return false;
            }
            return true;
        }
    }
}
