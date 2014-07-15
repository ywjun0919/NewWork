using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSharpGL.VectorClass
{
    class Vector4D:Vector
    {
        #region 默认构造函数

        public Vector4D() : base(4) { }
        public Vector4D(Vector v):base(4)
        {
            X = v.Point[0];
            Y = v.Point[1];
            Z = v.Point[2];
            W = v.Point[3];
        }
        public Vector4D(Vector4D v): base(4) 
        {
            this.X = v.X;
            this.Y = v.Y;
            this.Z = v.Z;
            this.W = v.W;
        }
        public Vector4D(float x, float y, float z, float w): base(4)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }
        
        #endregion

        #region 属性
        public float X 
        {
            get { return Point[0]; }
            set { Point[0] = value; }
        }
        public float Y
        {
            get { return Point[1]; }
            set { Point[1] = value; }
        }
        public float Z
        {
            get { return Point[2]; }
            set { Point[2] = value; }
        }
        public float W
        {
            get { return Point[3]; }
            set { Point[3] = value; }
        }
        #endregion

    }
}
