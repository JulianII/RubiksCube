using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCube
{
    internal interface ICube
    {
        public bool CubeCompleted();
        public void MoveLeft(int i);
        public void MoveUp(int i);
        public IFace[] Faces { get; }

    }
}
