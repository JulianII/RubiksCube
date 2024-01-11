using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RubiksCube
{
    internal partial class ViewModel : ObservableObject
    {

        [ObservableProperty]
        public Cube c;

        public ViewModel(Cube cube) 
        {
            C = cube;
            C.MoveUp(0);
        }

        [RelayCommand]
        public void MoveUp(string s)
        {
            C.MoveUp(int.Parse(s));
        }

        [RelayCommand]
        public void MoveDown(string s)
        {
            C.MoveDown(int.Parse(s));
        }

        [RelayCommand]
        public void MoveLeft(string s)
        {
            C.MoveLeft(int.Parse(s));
        }

        [RelayCommand]
        public void MoveRight(string s)
        {
            C.MoveRight(int.Parse(s));
        }

    }
}
