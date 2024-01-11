using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RubiksCube
{
    internal partial class Face : ObservableObject
    {
        [ObservableProperty]
        private Brush[] plates;

        public Face(Color c)
        {
            Plates = new Brush[9];

            for (int i = 0; i < 9; ++i)
            {
                Plates[i] = new SolidColorBrush(c);
            }
        }

        public Brush GetPlate(int i)
        {
            if (i > Plates.Length) throw new ArgumentOutOfRangeException();

            return Plates[i];
        }

        public void SetPlateColor(int i, Brush b)
        {
            if (i > Plates.Length) throw new ArgumentOutOfRangeException();

            Plates[i] = b;
        }

        public bool FaceCompleted()
        {
            for(int i = 0; i < 8; ++i) 
            {
                if (Plates[i] != Plates[i+1]) return false;
            }
            return true;
        }
    }
}
