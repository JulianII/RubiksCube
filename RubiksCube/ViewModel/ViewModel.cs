using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using RubiksCube.Model;

namespace RubiksCube
{
    internal partial class ViewModel : ObservableObject
    {
        [ObservableProperty]
        private Cube c;

        private bool cubeCompleted = false;

        private SaveManager sm = new SaveManager();

        public ViewModel(Cube cube) 
        {
            C = cube;
            c = sm.Load();
        }

        [RelayCommand]
        public void MoveUp(string s)
        {
            if(!cubeCompleted) C.MoveUp(int.Parse(s));
            cubeCompleted = c.CubeCompleted();
        }

        [RelayCommand]
        public void MoveDown(string s)
        {
            if (!cubeCompleted) C.MoveDown(int.Parse(s));
            cubeCompleted = c.CubeCompleted();
        }

        [RelayCommand]
        public void MoveLeft(string s)
        {
            if (!cubeCompleted) C.MoveLeft(int.Parse(s));
            cubeCompleted = c.CubeCompleted();
        }

        [RelayCommand]
        public void MoveRight(string s)
        {
            if (!cubeCompleted) C.MoveRight(int.Parse(s));
            cubeCompleted = c.CubeCompleted();
        }

        [RelayCommand]
        public void Randomize()
        {
            C.Randomize();
            cubeCompleted = c.CubeCompleted();
        }

        [RelayCommand]
        public void Save()
        {
            sm.Save(C);
            cubeCompleted = c.CubeCompleted();
        }

        [RelayCommand]
        public void Load()
        {
            C = sm.Load();
            cubeCompleted = c.CubeCompleted();
        }


    }
}
