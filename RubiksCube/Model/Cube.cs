using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RubiksCube
{
    internal partial class Cube 
    {
        public Face FrontFace { get; private set; }
        public Face BackFace { get; private set; }

        public Face RightFace { get; private set; }
        public Face LeftFace { get; private set; }

        public Face TopFace { get; private set; }
        public Face BottomFace { get; private set; }
        
        public Cube()
        {
            Color c;
            c = Color.FromArgb(255, 255, 0, 0); // red
            FrontFace = new Face(c);
            c = Color.FromArgb(255, 255, 102, 0); // orange
            BackFace = new Face(c);

            c = Color.FromArgb(255, 0, 255, 0); // green
            RightFace = new Face(c);
            c = Color.FromArgb(255, 255, 255, 0); // yellow
            LeftFace = new Face(c);

            c = Color.FromArgb(255, 0, 0, 255); // blue
            TopFace = new Face(c);
            c = Color.FromArgb(255, 255, 0, 255); // green
            BottomFace = new Face(c);
        }

        public bool CubeCompleted()
        {
            if (!FrontFace.FaceCompleted()) return false;
            if (!FrontFace.FaceCompleted()) return false;

            if (!RightFace.FaceCompleted()) return false;
            if (!LeftFace.FaceCompleted()) return false;

            if (!TopFace.FaceCompleted()) return false;
            if (!BottomFace.FaceCompleted()) return false;

            return true;
        }

        public void MoveLeft(int row)
        {
            if (row == 0) RotateFace(TopFace, true);
            if (row == 2) RotateFace(BottomFace, true);

            Face temp = new Face(Color.FromRgb(0,0,0));
            for (int i = 0; i < 3; ++i) temp.SetPlateColor(row * 3 + i, FrontFace.GetPlate(row * 3 + i));

            for (int i = 0; i < 3; ++i) FrontFace.SetPlateColor(row * 3 + i, RightFace.GetPlate(row * 3 + i));
            for (int i = 0; i < 3; ++i) RightFace.SetPlateColor(row * 3 + i, BackFace.GetPlate(row * 3 + i));
            for (int i = 0; i < 3; ++i) BackFace.SetPlateColor(row * 3 + i,  LeftFace.GetPlate(row * 3 + i));
            for (int i = 0; i < 3; ++i) LeftFace.SetPlateColor(row * 3 + i,  temp.GetPlate(row * 3 + i));
        }

        public void MoveUp(int column)
        {
            if (column == 0) RotateFace(LeftFace, false);
            if (column == 2) RotateFace(RightFace, false);

            Face temp = new Face(Color.FromRgb(0, 0, 0));
            for (int i = 0; i < 3; ++i) temp.SetPlateColor(i * 3 + column, FrontFace.GetPlate(i * 3 + column));

            for (int i = 0; i < 3; ++i) FrontFace.SetPlateColor(i * 3 + column, BottomFace.GetPlate(i * 3 + column));
            for (int i = 0; i < 3; ++i) BottomFace.SetPlateColor(i * 3 + column, BackFace.GetPlate(i * 3 + column));
            for (int i = 0; i < 3; ++i) BackFace.SetPlateColor(i * 3 + column,  TopFace.GetPlate(i * 3 + column));
            for (int i = 0; i < 3; ++i) TopFace.SetPlateColor(i * 3 + column,  temp.GetPlate(i * 3 + column));
        }

        public void MoveRight(int row)
        {
            if (row == 0) RotateFace(TopFace, false);
            if (row == 2) RotateFace(BottomFace, false);

            Face temp = new Face(Color.FromRgb(0, 0, 0));
            for (int i = 0; i < 3; ++i) temp.SetPlateColor(row * 3 + i, FrontFace.GetPlate(row * 3 + i));

            for (int i = 0; i < 3; ++i) FrontFace.SetPlateColor(row * 3 + i, LeftFace.GetPlate(row * 3 + i));
            for (int i = 0; i < 3; ++i) LeftFace.SetPlateColor(row * 3 + i, BackFace.GetPlate(row * 3 + i));
            for (int i = 0; i < 3; ++i) BackFace.SetPlateColor(row * 3 + i, RightFace.GetPlate(row * 3 + i));
            for (int i = 0; i < 3; ++i) RightFace.SetPlateColor(row * 3 + i, temp.GetPlate(row * 3 + i));
        }

        public void MoveDown(int column)
        {
            if (column == 0) RotateFace(TopFace, false);
            if (column == 2) RotateFace(BottomFace, false);

            Face temp = new Face(Color.FromRgb(0, 0, 0));
            for (int i = 0; i < 3; ++i) temp.SetPlateColor(i * 3 + column, FrontFace.GetPlate(i * 3 + column));

            for (int i = 0; i < 3; ++i) FrontFace.SetPlateColor(i * 3 + column, TopFace.GetPlate(i * 3 + column));
            for (int i = 0; i < 3; ++i) TopFace.SetPlateColor(i * 3 + column, BackFace.GetPlate(i * 3 + column));
            for (int i = 0; i < 3; ++i) BackFace.SetPlateColor(i * 3 + column, BottomFace.GetPlate(i * 3 + column));
            for (int i = 0; i < 3; ++i) BottomFace.SetPlateColor(i * 3 + column, temp.GetPlate(i * 3 + column));
        }

        private void RotateFace(Face f, bool rotRight)
        {
            Face rotated = new Face();
            Brush[] brushes = new Brush[9];

            /*  [0,1,2,
                 3,4,5,
                 6,7,8] */

            if (rotRight)
            {
                brushes[4] = f.GetPlate(4);

                Brush temp1 = f.GetPlate(1);
                Brush temp2 = f.GetPlate(2);

                brushes[0] = f.GetPlate(6);
                brushes[1] = f.GetPlate(3);
                brushes[2] = f.GetPlate(0);

                brushes[3] = f.GetPlate(7);
                brushes[6] = f.GetPlate(8);

                brushes[7] = f.GetPlate(5);

                brushes[5] = temp1;
                brushes[8] = temp2;
            } else {
                brushes[4] = f.GetPlate(4);

                Brush temp1 = f.GetPlate(0);
                Brush temp2 = f.GetPlate(1);

                brushes[0] = f.GetPlate(2);
                brushes[1] = f.GetPlate(5);
                brushes[2] = f.GetPlate(8);

                brushes[5] = f.GetPlate(7);
                brushes[8] = f.GetPlate(6);

                brushes[7] = f.GetPlate(3);

                brushes[6] = temp1;
                brushes[3] = temp2;
            }

            for (int i = 0; i < 9; ++i) f.SetPlateColor(i, brushes[i]); 
        }

        public void Randomize ()
        {
            Random rnd = new Random();
            for (int i = 0; i < 400; ++i)
            {
                int x = rnd.Next(1, 4);
                int y = rnd.Next(1, 3); 

                switch (x)
                {
                    case 1: MoveDown(y);
                        break;
                    case 2: MoveUp(y);
                        break;
                    case 3: MoveLeft(y);
                        break;
                    case 4: MoveRight(y);
                        break;
                }
            }
        }
    }
}
