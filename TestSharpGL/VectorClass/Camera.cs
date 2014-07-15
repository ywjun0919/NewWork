using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSharpGL.VectorClass
{
    class Camera
    {
        Vector3D vrp = new Vector3D();
        public Vector3D VRP
        {
            get { return vrp; }
            set { vrp = value; }
        }
    }
}
