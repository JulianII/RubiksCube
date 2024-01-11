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
using System.Collections.ObjectModel;

namespace RubiksCube
{
    internal partial class Face : ObservableObject
    {

        [ObservableProperty]
        public ObservableCollection<Brush> plates;

        public Face(Color c)
        {
            Plates = new ObservableCollection<Brush>();

            for (int i = 0; i < 9; ++i)
            {
                Plates.Add(new SolidColorBrush(c));
            }
        }

        public Brush GetPlate(int i)
        {
            if (i > Plates.Count) throw new ArgumentOutOfRangeException();

            return Plates[i];
        }

        public void SetPlateColor(int i, Brush b)
        {
            if (i > Plates.Count) throw new ArgumentOutOfRangeException();

            Plates[i] = b;
        }

        public bool FaceCompleted()
        {
            for (int i = 0; i < 8; ++i)
            {
                if (Plates[i] != Plates[i + 1]) return false;
            }
            return true;
        }
    }
}
