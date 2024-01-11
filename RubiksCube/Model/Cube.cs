using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RubiksCube
{
    internal partial class Cube : ObservableObject
    {
        [ObservableProperty]
        public Face frontFace;
        public Face BackFace { get; private set; }

        public Face RightFace { get; private set; }
        public Face LeftFace { get; private set; }

        [ObservableProperty]
        public Face topFace;
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
            Face temp = FrontFace;

            for (int i = 0; i < 3; ++i) FrontFace.SetPlateColor(row * 3 + i, RightFace.GetPlate(row * 3 + i));
            for (int i = 0; i < 3; ++i) RightFace.SetPlateColor(row * 3 + i, BackFace.GetPlate(row * 3 + i));
            for (int i = 0; i < 3; ++i) BackFace.SetPlateColor(row * 3 + i,  LeftFace.GetPlate(row * 3 + i));
            for (int i = 0; i < 3; ++i) LeftFace.SetPlateColor(row * 3 + i,  temp.GetPlate(row * 3 + i));
        }

        public void MoveUp(int column)
        {
            Face temp = FrontFace;

            for (int i = 0; i < 3; ++i) FrontFace.SetPlateColor(column * 3 + i, BottomFace.GetPlate(column * 3 + i));
            for (int i = 0; i < 3; ++i) BottomFace.SetPlateColor(column * 3 + i, BackFace.GetPlate(column * 3 + i));
            for (int i = 0; i < 3; ++i) BackFace.SetPlateColor(column * 3 + i,  TopFace.GetPlate(column * 3 + i));
            for (int i = 0; i < 3; ++i) TopFace.SetPlateColor(column * 3 + i,  temp.GetPlate(column * 3 + i));
        }

        public void MoveRight(int row)
        {
            Face temp = FrontFace;

            for (int i = 0; i < 3; ++i) FrontFace.SetPlateColor(row * 3 + i, LeftFace.GetPlate(row * 3 + i));
            for (int i = 0; i < 3; ++i) LeftFace.SetPlateColor(row * 3 + i, BackFace.GetPlate(row * 3 + i));
            for (int i = 0; i < 3; ++i) BackFace.SetPlateColor(row * 3 + i, RightFace.GetPlate(row * 3 + i));
            for (int i = 0; i < 3; ++i) RightFace.SetPlateColor(row * 3 + i, temp.GetPlate(row * 3 + i));
        }

        public void MoveDown(int column)
        {
            Face temp = FrontFace;

            for (int i = 0; i < 3; ++i) FrontFace.SetPlateColor(column * 3 + i, TopFace.GetPlate(column * 3 + i));
            for (int i = 0; i < 3; ++i) TopFace.SetPlateColor(column * 3 + i, BackFace.GetPlate(column * 3 + i));
            for (int i = 0; i < 3; ++i) BackFace.SetPlateColor(column * 3 + i, BottomFace.GetPlate(column * 3 + i));
            for (int i = 0; i < 3; ++i) BottomFace.SetPlateColor(column * 3 + i, temp.GetPlate(column * 3 + i));
        }
    }
}
