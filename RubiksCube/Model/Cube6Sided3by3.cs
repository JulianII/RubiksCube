using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RubiksCube
{
    internal class Cube6Sided3by3 : ICube
    {
        public string test;

        public IFace[] Faces { get; }

        public IFace FrontFace { get; private set; }
        public IFace BackFace { get; private set; }

        public IFace RightFace { get; private set; }
        public IFace LeftFace { get; private set; }

        public IFace TopFace { get; private set; }
        public IFace BottomFace { get; private set; }

        public Cube6Sided3by3 (Plate p)
        {
            test = "Hier steht was";

            p = new Plate(Color.FromArgb(255, 255, 0, 0)); // red
            FrontFace = new Face3by3(p); 
            BackFace = new Face3by3(p); 

            p = new Plate(Color.FromArgb(255, 0, 255, 0)); // green
            RightFace = new Face3by3(p); 
            LeftFace = new Face3by3(p); 

            p = new Plate(Color.FromArgb(255, 0, 0, 255)); // blue
            TopFace = new Face3by3(p); 
            BottomFace = new Face3by3(p); 
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
            IFace temp = FrontFace;

            for (int i = 0; i < 3; ++i) FrontFace.SetPlateColor(row * 3 + i, RightFace.GetPlateColor(row * 3 + i));
            for (int i = 0; i < 3; ++i) RightFace.SetPlateColor(row * 3 + i, BackFace.GetPlateColor(row * 3 + i));
            for (int i = 0; i < 3; ++i) BackFace.SetPlateColor(row * 3 + i,  LeftFace.GetPlateColor(row * 3 + i));
            for (int i = 0; i < 3; ++i) LeftFace.SetPlateColor(row * 3 + i,  temp.GetPlateColor(row * 3 + i));
        }

        public void MoveUp(int column)
        {
            IFace temp = FrontFace;

            for (int i = 0; i < 3; ++i) FrontFace.SetPlateColor(column * 3 + i, BottomFace.GetPlateColor(column * 3 + i));
            for (int i = 0; i < 3; ++i) BottomFace.SetPlateColor(column * 3 + i, BackFace.GetPlateColor(column * 3 + i));
            for (int i = 0; i < 3; ++i) BackFace.SetPlateColor(column * 3 + i,  TopFace.GetPlateColor(column * 3 + i));
            for (int i = 0; i < 3; ++i) TopFace.SetPlateColor(column * 3 + i,  temp.GetPlateColor(column * 3 + i));
        }

        public void MoveRight(int row)
        {
            IFace temp = FrontFace;

            for (int i = 0; i < 3; ++i) FrontFace.SetPlateColor(row * 3 + i, LeftFace.GetPlateColor(row * 3 + i));
            for (int i = 0; i < 3; ++i) LeftFace.SetPlateColor(row * 3 + i, BackFace.GetPlateColor(row * 3 + i));
            for (int i = 0; i < 3; ++i) BackFace.SetPlateColor(row * 3 + i, RightFace.GetPlateColor(row * 3 + i));
            for (int i = 0; i < 3; ++i) RightFace.SetPlateColor(row * 3 + i, temp.GetPlateColor(row * 3 + i));
        }

        public void MoveDown(int column)
        {
            IFace temp = FrontFace;

            for (int i = 0; i < 3; ++i) FrontFace.SetPlateColor(column * 3 + i, TopFace.GetPlateColor(column * 3 + i));
            for (int i = 0; i < 3; ++i) TopFace.SetPlateColor(column * 3 + i, BackFace.GetPlateColor(column * 3 + i));
            for (int i = 0; i < 3; ++i) BackFace.SetPlateColor(column * 3 + i, BottomFace.GetPlateColor(column * 3 + i));
            for (int i = 0; i < 3; ++i) BottomFace.SetPlateColor(column * 3 + i, temp.GetPlateColor(column * 3 + i));
        }
    }
}
