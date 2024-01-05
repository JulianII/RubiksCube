using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RubiksCube
{
    internal partial class ViewModel : ObservableObject
    {
        [ObservableProperty]
        public ICube c;

        public ViewModel(ICube cube) 
        {
            c = cube;
            c.MoveLeft(0);          
        }
    }
}
