using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSharpGL.VectorClass
{
    class Matrix4D
    {

        #region 属性
        public static Matrix4D ZERO = new Matrix4D(
        0, 0, 0, 0,
        0, 0, 0, 0,
        0, 0, 0, 0,
        0, 0, 0, 0 );

        public float[,] m=new float[4,4];
        #endregion

        #region 构造函数
        public Matrix4D() { }
        public Matrix4D(Matrix4D newMatrix4) { }
        public Matrix4D(
            float m00, float m01, float m02, float m03,
            float m10, float m11, float m12, float m13,
            float m20, float m21, float m22, float m23,
            float m30, float m31, float m32, float m33 )
        {
            m[0,0] = m00;
            m[0,1] = m01;
            m[0,2] = m02;
            m[0,3] = m03;
            m[1,0] = m10;
            m[1,1] = m11;
            m[1,2] = m12;
            m[1,3] = m13;
            m[2,0] = m20;
            m[2,1] = m21;
            m[2,2] = m22;
            m[2,3] = m23;
            m[3,0] = m30;
            m[3,1] = m31;
            m[3,2] = m32;
            m[3,3] = m33;
            
        }
        #endregion

        #region 方法
        /************************************************************************/
        /* 矩阵交换                                                             */
        /************************************************************************/
        public Matrix4D Swap(ref Matrix4D other)
        {
            Matrix4D newMatrix = new Matrix4D();

            Common.swap(ref m[0, 0], ref other.m[0, 0]);
            Common.swap(ref m[0, 1], ref other.m[0, 1]);
            Common.swap(ref m[0, 2], ref other.m[0, 2]);
            Common.swap(ref m[0, 3], ref other.m[0, 3]);
            Common.swap(ref m[1, 0], ref other.m[1, 0]);
            Common.swap(ref m[1, 1], ref other.m[1, 1]);
            Common.swap(ref m[1, 2], ref other.m[1, 2]);
            Common.swap(ref m[1, 3], ref other.m[1, 3]);
            Common.swap(ref m[2, 0], ref other.m[2, 0]);
            Common.swap(ref m[2, 1], ref other.m[2, 1]);
            Common.swap(ref m[2, 2], ref other.m[2, 2]);
            Common.swap(ref m[2, 3], ref  other.m[2, 3]);
            Common.swap(ref m[3, 0], ref other.m[3, 0]);
            Common.swap(ref m[3, 1], ref other.m[3, 1]);
            Common.swap(ref m[3, 2], ref other.m[3, 2]);
            Common.swap(ref m[3, 3], ref other.m[3, 3]);

            return newMatrix;
        }
        
        /************************************************************************/
        /* 矩阵相加                                                             */
        /************************************************************************/
        public static Matrix4D operator +(Matrix4D first, Matrix4D second)
        {
            Matrix4D newMatrix = new Matrix4D();

            newMatrix.m[0, 0] = first.m[0, 0] + second.m[0, 0];
            newMatrix.m[0, 1] = first.m[0, 1] + second.m[0, 1];
            newMatrix.m[0, 2] = first.m[0, 2] + second.m[0, 2];
            newMatrix.m[0, 3] = first.m[0, 3] + second.m[0, 3];

            newMatrix.m[1, 0] = first.m[1, 0] + second.m[1, 0];
            newMatrix.m[1, 1] = first.m[1, 1] + second.m[1, 1];
            newMatrix.m[1, 2] = first.m[1, 2] + second.m[1, 2];
            newMatrix.m[1, 3] = first.m[1, 3] + second.m[1, 3];

            newMatrix.m[2, 0] = first.m[2, 0] + second.m[2, 0];
            newMatrix.m[2, 1] = first.m[2, 1] + second.m[2, 1];
            newMatrix.m[2, 2] = first.m[2, 2] + second.m[2, 2];
            newMatrix.m[2, 3] = first.m[2, 3] + second.m[2, 3];

            newMatrix.m[3, 0] = first.m[3, 0] + second.m[3, 0];
            newMatrix.m[3, 1] = first.m[3, 1] + second.m[3, 1];
            newMatrix.m[3, 2] = first.m[3, 2] + second.m[3, 2];
            newMatrix.m[3, 3] = first.m[3, 3] + second.m[3, 3];

            return newMatrix;
        }

        /************************************************************************/
        /* 矩阵相减                                                             */
        /************************************************************************/
        public static Matrix4D operator -(Matrix4D first, Matrix4D second) 
        {
            Matrix4D newMatrix = new Matrix4D();

            newMatrix.m[0, 0] = first.m[0, 0] - second.m[0, 0];
            newMatrix.m[0, 1] = first.m[0, 1] - second.m[0, 1];
            newMatrix.m[0, 2] = first.m[0, 2] - second.m[0, 2];
            newMatrix.m[0, 3] = first.m[0, 3] - second.m[0, 3];

            newMatrix.m[1, 0] = first.m[1, 0] - second.m[1, 0];
            newMatrix.m[1, 1] = first.m[1, 1] - second.m[1, 1];
            newMatrix.m[1, 2] = first.m[1, 2] - second.m[1, 2];
            newMatrix.m[1, 3] = first.m[1, 3] - second.m[1, 3];

            newMatrix.m[2, 0] = first.m[2, 0] - second.m[2, 0];
            newMatrix.m[2, 1] = first.m[2, 1] - second.m[2, 1];
            newMatrix.m[2, 2] = first.m[2, 2] - second.m[2, 2];
            newMatrix.m[2, 3] = first.m[2, 3] - second.m[2, 3];

            newMatrix.m[3, 0] = first.m[3, 0] - second.m[3, 0];
            newMatrix.m[3, 1] = first.m[3, 1] - second.m[3, 1];
            newMatrix.m[3, 2] = first.m[3, 2] - second.m[3, 2];
            newMatrix.m[3, 3] = first.m[3, 3] - second.m[3, 3];

            return newMatrix;
        }

        /************************************************************************/
        /* 矩阵相乘                                                            */
        /************************************************************************/
        public static Matrix4D operator *(Matrix4D first, Matrix4D second)
        {
            Matrix4D newMatrix = new Matrix4D();

            for ( int iRow = 0; iRow < 4; iRow++)
            {
                for (int iCol = 0; iCol < 4; iCol++)
                {
                    newMatrix.m[iRow, iCol] = first.m[iRow, 0] * second.m[0, iCol] + first.m[iRow, 1] * second.m[1, iCol] + first.m[iRow, 2] * second.m[2, iCol] + first.m[iRow, 3] * second.m[3, iCol];
                }
            }

            return newMatrix;
        }
        /************************************************************************/
        /* 向量与矩阵的乘法  Vector transformation using '*'.                   */
        /************************************************************************/

        public static Vector3D operator *(Vector3D v, Matrix4D m1)
        {
            Vector3D newV = new Vector3D();

            float fInvW = 1.0f / (m1.m[3, 0] * v.X + m1.m[3, 1] * v.Y + m1.m[3, 2] * v.Z + m1.m[3, 3]);
            for (int iRow = 0; iRow < 3; iRow++)
            {
                newV.Point[iRow] = (v.Point[0] * m1.m[iRow, 0] + v.Point[1] * m1.m[iRow, 1] + v.Point[2] * m1.m[iRow, 2] + m1.m[iRow, 3]);
            }

            return newV;
        }

        //右乘
        public static Vector4D operator *(Vector4D v, Matrix4D m1)
        {
            return new Vector4D(
             m1.m[0,0] * v.X + m1.m[0,1] * v.Y + m1.m[0,2] * v.Z + m1.m[0,3] * v.W,
             m1.m[1,0] * v.X + m1.m[1,1] * v.Y + m1.m[1,2] * v.Z + m1.m[1,3] * v.W,
             m1.m[2,0] * v.X + m1.m[2,1] * v.Y + m1.m[2,2] * v.Z + m1.m[2,3] * v.W,
             m1.m[3,0] * v.X + m1.m[3,1] * v.Y + m1.m[3,2] * v.Z + m1.m[3,3] * v.W
             );
        }
        /************************************************************************/
        /* 矩阵的数乘                                                     */
        /************************************************************************/
        public static Matrix4D operator *(float scalar, Matrix4D m1) 
        {
            return new Matrix4D(
                scalar*m1.m[0,0], scalar*m1.m[0,1], scalar*m1.m[0,2], scalar*m1.m[0,3],
                scalar*m1.m[1,0], scalar*m1.m[1,1], scalar*m1.m[1,2], scalar*m1.m[1,3],
                scalar*m1.m[2,0], scalar*m1.m[2,1], scalar*m1.m[2,2], scalar*m1.m[2,3],
                scalar*m1.m[3,0], scalar*m1.m[3,1], scalar*m1.m[3,2], scalar*m1.m[3,3]);
        }
        /************************************************************************/
        /* 转置                                                                 */
        /************************************************************************/
        public Matrix4D transpose()
        {
            return new Matrix4D(m[0, 0], m[1, 0], m[2, 0], m[3, 0],
                           m[0, 1], m[1, 1], m[2, 1], m[3, 1],
                           m[0, 2], m[1, 2], m[2, 2], m[3, 2],
                           m[0, 3], m[1, 3], m[2, 3], m[3, 3]);
        }

        /************************************************************************/
        /* 获取缩放变换矩阵                                                         */
        /************************************************************************/
        public static Matrix4D GetScale(float s_x, float s_y, float s_z)
        {
            Matrix4D newMatrix = new Matrix4D() ;

            newMatrix.m[0, 0] = s_x; newMatrix.m[0, 1] = 0.0f; newMatrix.m[0, 2] = 0.0f; newMatrix.m[0, 3] = 0.0f;
            newMatrix.m[1, 0] = 0.0f; newMatrix.m[1, 1] = s_y; newMatrix.m[1, 2] = 0.0f; newMatrix.m[1, 3] = 0.0f;
            newMatrix.m[2, 0] = 0.0f; newMatrix.m[2, 1] = 0.0f; newMatrix.m[2, 2] = s_z; newMatrix.m[2, 3] = 0.0f;
            newMatrix.m[3, 0] = 0.0f; newMatrix.m[3, 1] = 0.0f; newMatrix.m[3, 2] = 0.0f; newMatrix.m[3, 3] = 1.0f;

            return newMatrix;
        }

        public static Matrix4D GetScale(ref Vector3D v)
        {
            Matrix4D newMatrix = new Matrix4D();

            newMatrix.m[0, 0] = v.X; newMatrix.m[0, 1] = 0.0f; newMatrix.m[0, 2] = 0.0f; newMatrix.m[0, 3] = 0.0f;
            newMatrix.m[1, 0] = 0.0f; newMatrix.m[1, 1] = v.Y; newMatrix.m[1, 2] = 0.0f; newMatrix.m[1, 3] = 0.0f;
            newMatrix.m[2, 0] = 0.0f; newMatrix.m[2, 1] = 0.0f; newMatrix.m[2, 2] = v.Z; newMatrix.m[2, 3] = 0.0f;
            newMatrix.m[3, 0] = 0.0f; newMatrix.m[3, 1] = 0.0f; newMatrix.m[3, 2] = 0.0f; newMatrix.m[3, 3] = 1.0f;

            return newMatrix;
        }

        /************************************************************************/
        /* 获取平移变换矩阵                                                     */
        /************************************************************************/
        public static Matrix4D GetTrans(float t_x, float t_y, float t_z)
        {
            Matrix4D newMatrix = new Matrix4D();

            newMatrix.m[0, 0] = 1.0f; newMatrix.m[0, 1] = 0.0f; newMatrix.m[0, 2] = 0.0f; newMatrix.m[0, 3] = t_x;
            newMatrix.m[1, 0] = 0.0f; newMatrix.m[1, 1] = 1.0f; newMatrix.m[1, 2] = 0.0f; newMatrix.m[1, 3] = t_y;
            newMatrix.m[2, 0] = 0.0f; newMatrix.m[2, 1] = 0.0f; newMatrix.m[2, 2] = 1.0f; newMatrix.m[2, 3] = t_z;
            newMatrix.m[3, 0] = 0.0f; newMatrix.m[3, 1] = 0.0f; newMatrix.m[3, 2] = 0.0f; newMatrix.m[3, 3] = 1.0f;

            return newMatrix;
        }

        public static Matrix4D GetTrans(ref Vector3D v)
        {
            Matrix4D newMatrix = new Matrix4D();

            newMatrix.m[0, 0] = 1.0f; newMatrix.m[0, 1] = 0.0f; newMatrix.m[0, 2] = 0.0f; newMatrix.m[0, 3] = v.X;
            newMatrix.m[1, 0] = 0.0f; newMatrix.m[1, 1] = 1.0f; newMatrix.m[1, 2] = 0.0f; newMatrix.m[1, 3] = v.Y;
            newMatrix.m[2, 0] = 0.0f; newMatrix.m[2, 1] = 0.0f; newMatrix.m[2, 2] = 1.0f; newMatrix.m[2, 3] = v.Z;
            newMatrix.m[3, 0] = 0.0f; newMatrix.m[3, 1] = 0.0f; newMatrix.m[3, 2] = 0.0f; newMatrix.m[3, 3] = 1.0f;

            return newMatrix;
        }

        /************************************************************************/
        /* 获取绕x轴的旋转变化矩阵                                              */
        /************************************************************************/
        public static Matrix4D GetXAxisRotation(double theta) 
        {
            Matrix4D newMatrix = new Matrix4D();

            double radian = theta * Math.PI/180;

            float cos = (float)Math.Cos(radian);
            float sin = (float)Math.Sin(radian);

            newMatrix.m[0, 0] = 1.0f; newMatrix.m[0, 1] = 0.0f; newMatrix.m[0, 2] = 0.0f; newMatrix.m[0, 3] = 0.0f;
            newMatrix.m[1, 0] = 0.0f; newMatrix.m[1, 1] = cos; newMatrix.m[1, 2] = -sin; newMatrix.m[1, 3] = 0.0f;
            newMatrix.m[2, 0] = 0.0f; newMatrix.m[2, 1] = sin; newMatrix.m[2, 2] = cos; newMatrix.m[2, 3] = 0.0f;
            newMatrix.m[3, 0] = 0.0f; newMatrix.m[3, 1] = 0.0f; newMatrix.m[3, 2] = 0.0f; newMatrix.m[3, 3] = 1.0f;

            return newMatrix;
        }

        /************************************************************************/
        /* 获取绕y轴的旋转变化矩阵                                              */
        /************************************************************************/
        public static Matrix4D GetYAxisRotation(double theta)
        {
            Matrix4D newMatrix = new Matrix4D();

            double radian = theta * Math.PI / 180;

            float cos = (float)Math.Cos(radian);
            float sin = (float)Math.Sin(radian);

            newMatrix.m[0, 0] = cos; newMatrix.m[0, 1] = 0.0f; newMatrix.m[0, 2] = sin; newMatrix.m[0, 3] = 0.0f;
            newMatrix.m[1, 0] = 0.0f; newMatrix.m[1, 1] = 1; newMatrix.m[1, 2] = 0.0f; newMatrix.m[1, 3] = 0.0f;
            newMatrix.m[2, 0] = -sin; newMatrix.m[2, 1] = 0.0f; newMatrix.m[2, 2] = cos; newMatrix.m[2, 3] = 0.0f;
            newMatrix.m[3, 0] = 0.0f; newMatrix.m[3, 1] = 0.0f; newMatrix.m[3, 2] = 0.0f; newMatrix.m[3, 3] = 1.0f;

            return newMatrix;
        }

        /************************************************************************/
        /* 获取绕z轴的旋转变化矩阵                                              */
        /************************************************************************/
        public static Matrix4D GetZAxisRotation(double theta)
        {
            Matrix4D newMatrix = new Matrix4D();

            double radian = theta * Math.PI / 180;

            float cos = (float)Math.Cos(radian);
            float sin = (float)Math.Sin(radian);

            newMatrix.m[0, 0] = cos; newMatrix.m[0, 1] = -sin; newMatrix.m[0, 2] = 0.0f; newMatrix.m[0, 3] = 0;
            newMatrix.m[1, 0] = sin; newMatrix.m[1, 1] = cos; newMatrix.m[1, 2] = 0.0f; newMatrix.m[1, 3] = 0;
            newMatrix.m[2, 0] = 0.0f; newMatrix.m[2, 1] = 0.0f; newMatrix.m[2, 2] = 1; newMatrix.m[2, 3] = 0;
            newMatrix.m[3, 0] = 0.0f; newMatrix.m[3, 1] = 0.0f; newMatrix.m[3, 2] = 0.0f; newMatrix.m[3, 3] = 1.0f;

            return newMatrix;
        }

        /************************************************************************/
        /* 矩阵求逆                                                                     */
        /************************************************************************/
        public Matrix4D inverse()
        {
            float m00 = m[0,0], m01 = m[0,1], m02 = m[0,2], m03 = m[0,3];
            float m10 = m[1,0], m11 = m[1,1], m12 = m[1,2], m13 = m[1,3];
            float m20 = m[2,0], m21 = m[2,1], m22 = m[2,2], m23 = m[2,3];
            float m30 = m[3,0], m31 = m[3,1], m32 = m[3,2], m33 = m[3,3];

            float v0 = m20 * m31 - m21 * m30;
            float v1 = m20 * m32 - m22 * m30;
            float v2 = m20 * m33 - m23 * m30;
            float v3 = m21 * m32 - m22 * m31;
            float v4 = m21 * m33 - m23 * m31;
            float v5 = m22 * m33 - m23 * m32;

            float t00 = +(v5 * m11 - v4 * m12 + v3 * m13);
            float t10 = -(v5 * m10 - v2 * m12 + v1 * m13);
            float t20 = +(v4 * m10 - v2 * m11 + v0 * m13);
            float t30 = -(v3 * m10 - v1 * m11 + v0 * m12);

            float invDet = 1 / (t00 * m00 + t10 * m01 + t20 * m02 + t30 * m03);

            float d00 = t00 * invDet;
            float d10 = t10 * invDet;
            float d20 = t20 * invDet;
            float d30 = t30 * invDet;

            float d01 = -(v5 * m01 - v4 * m02 + v3 * m03) * invDet;
            float d11 = +(v5 * m00 - v2 * m02 + v1 * m03) * invDet;
            float d21 = -(v4 * m00 - v2 * m01 + v0 * m03) * invDet;
            float d31 = +(v3 * m00 - v1 * m01 + v0 * m02) * invDet;

            v0 = m10 * m31 - m11 * m30;
            v1 = m10 * m32 - m12 * m30;
            v2 = m10 * m33 - m13 * m30;
            v3 = m11 * m32 - m12 * m31;
            v4 = m11 * m33 - m13 * m31;
            v5 = m12 * m33 - m13 * m32;

            float d02 = +(v5 * m01 - v4 * m02 + v3 * m03) * invDet;
            float d12 = -(v5 * m00 - v2 * m02 + v1 * m03) * invDet;
            float d22 = +(v4 * m00 - v2 * m01 + v0 * m03) * invDet;
            float d32 = -(v3 * m00 - v1 * m01 + v0 * m02) * invDet;

            v0 = m21 * m10 - m20 * m11;
            v1 = m22 * m10 - m20 * m12;
            v2 = m23 * m10 - m20 * m13;
            v3 = m22 * m11 - m21 * m12;
            v4 = m23 * m11 - m21 * m13;
            v5 = m23 * m12 - m22 * m13;

            float d03 = -(v5 * m01 - v4 * m02 + v3 * m03) * invDet;
            float d13 = +(v5 * m00 - v2 * m02 + v1 * m03) * invDet;
            float d23 = -(v4 * m00 - v2 * m01 + v0 * m03) * invDet;
            float d33 = +(v3 * m00 - v1 * m01 + v0 * m02) * invDet;

            return new Matrix4D(
                d00, d01, d02, d03,
                d10, d11, d12, d13,
                d20, d21, d22, d23,
                d30, d31, d32, d33);
        }
        #endregion

    }

    
}
