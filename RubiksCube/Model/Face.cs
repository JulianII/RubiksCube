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
using System.Diagnostics;

namespace RubiksCube
{
    internal partial class Face : ObservableObject
    {

        [ObservableProperty]
        private ObservableCollection<Brush> plates;

        public Face(Color c)
        {
            Plates = new ObservableCollection<Brush>();

            for (int i = 0; i < 9; ++i)
            {
                Plates.Add(new SolidColorBrush(c));
            }
        }

        public Face()
        {
            Plates = new ObservableCollection<Brush>();

            for (int i = 0; i < 9; ++i)
            {
                Plates.Add(new SolidColorBrush(Color.FromArgb(255,255,255,255)));
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
                // Compare string value of brushes and its neighbour
                if ("" + (SolidColorBrush) Plates[i] != "" + (SolidColorBrush) Plates[i + 1]) return false;
            }
            return true;
        }
    }
}
