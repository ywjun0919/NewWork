using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSharpGL.VectorClass
{
    public class Vector3D : Vector
    {
        public readonly static Vector3D ZERO =new Vector3D(0,0,0);
        #region 默认构造函数
        public Vector3D(): base(3)
        {

        }
        public Vector3D(Vector v) : base(3) 
        {
            this.X = v.Point[0];
            this.Y = v.Point[1];
            this.Z = v.Point[2];
        }
        public Vector3D(float x, float y, float z):base(3)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public Vector3D(Vector3D vector):base(3)
        {
            this.X = vector.X;
            this.Y = vector.Y;
            this.Z = vector.Z;
        }
        #endregion

        #region 方法
        /************************************************************************/
        /* 向量叉乘（用于求取法向量，叉乘是右手系，是否转换为左手系）           */
        /************************************************************************/
        public Vector3D CrossMultiply(Vector3D vector)
        {
            return new Vector3D(
                X * vector.Z - Z * vector.Y,
                Z * vector.X - X * vector.Z,
                X * vector.Y - Y * vector.X);
        }

       
        //向量相乘
        public Vector3D DotMultiply(Vector3D vector)
        {
            return new Vector3D(this * vector);
        }



        public static Vector3D operator *(float fscale, Vector3D vector)
        {
            return new Vector3D(
                fscale * vector.X,
                fscale * vector.Y,
                fscale * vector.Z
                );
        }

        public static Vector3D operator *(Vector3D vector,float fscale)
        {
            return new Vector3D(
                fscale * vector.X,
                fscale * vector.Y,
                fscale * vector.Z
                );
        }

        public static Vector3D operator *(Vector3D first, Vector3D second)
        {
            return new Vector3D(
                first.X * second.X,
                first.Y * second.Y,
                first.Z * second.Z
                );
        }


        public static Vector3D operator +(Vector3D first, Vector3D second)
        {
            return new Vector3D(
                first.X + second.X,
                first.Y + second.Y,
                first.Z + second.Z
                );
        }

        public static Vector3D operator /(Vector3D vector, float fscale)
        {
            return new Vector3D(
              vector.X /fscale ,
              vector.Y / fscale,
              vector.Z / fscale
              );
        }
        //深克隆
        public object Clone()
        {
            Vector3D newVector = new Vector3D();

            newVector.X = X;
            newVector.Y = Y;
            newVector.Z = Z;

            return newVector;
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
        public float Z
        {
            get { return point[2]; }
            set { point[2] = value; }
        }
        #endregion
    }
}
