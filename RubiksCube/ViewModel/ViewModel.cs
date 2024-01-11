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
        public void MoveUp()
        {
            C.MoveUp(0);
            Debug.WriteLine($"FrontFace Plate 0: {C.FrontFace.Plates[0]}");
        }

    }
}
