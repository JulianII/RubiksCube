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
    internal partial class Face : INotifyPropertyChanged
    {

        private Brush[] plates;
        public Brush[] Plates
        {
            get { return plates; }
            set
            {
                plates = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Plates)));
            }
        }

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
            NotifyPropertyChanged();
        }

        public bool FaceCompleted()
        {
            for (int i = 0; i < 8; ++i)
            {
                if (Plates[i] != Plates[i + 1]) return false;
            }
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
