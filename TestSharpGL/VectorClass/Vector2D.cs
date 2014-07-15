using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSharpGL.VectorClass
{
    class Vector2D:Vector
    {
       #region 默认构造函数
        public Vector2D(): base(2)
        {

        }
        public Vector2D(Vector v) : base(2) 
        {
            this.X = v.Point[0];
            this.Y = v.Point[1];
        }
        public Vector2D(float x, float y):base(2)
        {
            this.X = x;
            this.Y = y;
        }
        public Vector2D(Vector2D vector)
            : base(2)
        {
            this.X = vector.X;
            this.Y = vector.Y;
        }
        #endregion

        #region 方法
        public float CrossMultiply(Vector2D vector)
        {
            return X * vector.Y - Y * vector.X;
        }

        public void SwapVector(Vector2D other) 
        {
            X = X + other.X;
            other.X = X - other.X;
            X = X - other.X;

            Y = Y + other.Y;
            other.Y = Y - other.Y;
            Y = Y - other.Y;
        }
        #endregion

        #region 成员变量
        public float X
        {
            get { return point[0]; }
            set { point[0] = value; }
        }
        public float Y
        {
            get { return point[1]; }
            set { point[1] = value; }
        }
      
        #endregion

    }
}
