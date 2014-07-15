using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace TestSharpGL.VectorClass
{
    class Matrix3D
    {
        public static Matrix3D ZERO =new Matrix3D (0,0,0,0,0,0,0,0,0);

        float[,] m = new float[3,3];
        public Matrix3D() { }
        public Matrix3D(float f00, float f01, float f02,
                    float f10, float f11, float f12,
                    float f20, float f21, float f22)
        {
            m[0, 0] = f00;
            m[0, 1] = f01;
            m[0, 2] = f02;
            m[1, 0] = f10;
            m[1, 1] = f11;
            m[1, 2] = f12;
            m[2, 0] = f20;
            m[2, 1] = f21;
            m[2, 2] = f22;
        }
        public Matrix3D(  float[,] newMatrix)
        {
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    m[i, j] = newMatrix[i, j];
                }
            }
        }



        void swap(ref Matrix3D other)
        {
            Common.swap(ref m[0, 0], ref other.m[0, 0]);
            Common.swap(ref m[0, 1], ref other.m[0, 1]);
            Common.swap(ref m[0, 2], ref other.m[0, 2]);
            Common.swap(ref m[1, 0], ref other.m[1, 0]);
            Common.swap(ref m[1, 1], ref other.m[1, 1]);
            Common.swap(ref m[1, 2], ref other.m[1, 2]);
            Common.swap(ref m[2, 0], ref other.m[2, 0]);
            Common.swap(ref m[2, 1], ref other.m[2, 1]);
            Common.swap(ref m[2, 2], ref other.m[2, 2]);
        }

        /************************************************************************/
        /* 矩阵相加                                                             */
        /************************************************************************/
        public static Matrix3D operator+(Matrix3D first,Matrix3D second)
        {
            Matrix3D mSum = new Matrix3D();
            for (int iRow = 0; iRow < 3; iRow++)
            {
                for (int iCol = 0; iCol < 3; iCol++)
                {
                    mSum.m[iRow, iCol] = first.m[iRow,iCol] +
                        second.m[iRow,iCol];
                }
            }
            return mSum;
        }

        /************************************************************************/
        /* 矩阵相减                                                             */
        /************************************************************************/
        public static Matrix3D operator -(Matrix3D first, Matrix3D second)
        {
            Matrix3D mSum = new Matrix3D();
            for (int iRow = 0; iRow < 3; iRow++)
            {
                for (int iCol = 0; iCol < 3; iCol++)
                {
                    mSum.m[iRow, iCol] = first.m[iRow, iCol] -
                        second.m[iRow, iCol];
                }
            }
            return mSum;
        }

        /************************************************************************/
        /* 矩阵相乘                                                             */
        /************************************************************************/

        public static Matrix3D operator *(Matrix3D first, Matrix3D second)
        {
            Matrix3D mSum = new Matrix3D();
            for (int iRow = 0; iRow < 3; iRow++)
            {
                for (int iCol = 0; iCol < 3; iCol++)
                {
                    mSum.m[iRow, iCol] = first.m[iRow, iCol]*
                        second.m[iRow, iCol];
                }
            }
            return mSum;
        }

        /************************************************************************/
        /*矩阵转置                                                              */
        /************************************************************************/
        public bool Inverse() 
        {
            return false;
        }
        /************************************************************************/
        /* 向量与矩阵的乘法（左乘）                                                     */
        /************************************************************************/
        public static Vector3D operator *(Vector3D newPoint, Matrix3D newMatrix)
        {
            Vector3D vProd = new Vector3D();
            for (int iRow = 0; iRow < 3; iRow++)
            {
                vProd.Point[iRow] =
                    newMatrix.m[iRow, 0] * newPoint.Point[0] +
                    newMatrix.m[iRow, 1] * newPoint.Point[1] +
                    newMatrix.m[iRow, 2] * newPoint.Point[2];  
            }
            return vProd;
        }

        /************************************************************************/
        /*矩阵数乘                                                              */
        /************************************************************************/
        public static Matrix3D operator *(float ka, Matrix3D rkMatrix)
        {
            Matrix3D mSum = new Matrix3D();
            for (int iRow = 0; iRow < 3; iRow++)
            {
                for (int iCol = 0; iCol < 3; iCol++)
                {
                    mSum.m[iRow, iCol] = 
                        ka * rkMatrix.m[iRow, iCol];
                }
            }
            return mSum;
        }

        /************************************************************************/
        /* 矩阵深拷贝                                                           */
        /************************************************************************/
        public object Clone()
        {
            Matrix3D newMatrix = new Matrix3D();
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    newMatrix.m[i, j] = this.m[i, j];
                }
            }
            return newMatrix;
        }
        /************************************************************************/
        /* 获取平移变换矩阵                                                     */
        /************************************************************************/
        public static Matrix3D GetTrans(float t_x, float t_y)
        {
            Matrix3D newMatrix = new Matrix3D();

            newMatrix.m[0, 0] = 1.0f; newMatrix.m[0, 1] = 0.0f; newMatrix.m[0, 2] = t_x; 
            newMatrix.m[1, 0] = 0.0f; newMatrix.m[1, 1] = 1.0f; newMatrix.m[1, 2] = t_y; 
            newMatrix.m[2, 0] = 0.0f; newMatrix.m[2, 1] = 0.0f; newMatrix.m[2, 2] = 1.0f;

            return newMatrix;
        }

        /************************************************************************/
        /* 获取旋转变换矩阵                                                     */
        /************************************************************************/
        public static Matrix3D GetRotation(double theta)
        {
            Matrix3D newMatrix = new Matrix3D();
            double radian = theta * Math.PI / 180;

            float cos = (float)Math.Cos(radian);
            float sin = (float)Math.Sin(radian);

            newMatrix.m[0, 0] = cos; newMatrix.m[0, 1] = -sin; newMatrix.m[0, 2] = 0;
            newMatrix.m[1, 0] = sin; newMatrix.m[1, 1] = cos; newMatrix.m[1, 2] = 0;
            newMatrix.m[2, 0] = 0.0f; newMatrix.m[2, 1] = 0.0f; newMatrix.m[2, 2] = 1.0f;

            return newMatrix;
        }

        /************************************************************************/
        /* 获取缩放变换矩阵                                                     */
        /************************************************************************/
        public static Matrix3D GetScale(float s_x,float s_y)
        {
            Matrix3D newMatrix = new Matrix3D();
         
            newMatrix.m[0, 0] = s_x; newMatrix.m[0, 1] = 0; newMatrix.m[0, 2] = 0;
            newMatrix.m[1, 0] = 0; newMatrix.m[1, 1] = s_y; newMatrix.m[1, 2] = 0;
            newMatrix.m[2, 0] = 0.0f; newMatrix.m[2, 1] = 0.0f; newMatrix.m[2, 2] = 1.0f;

            return newMatrix;
        }

        /************************************************************************/
        /* 关于x轴对称                                                    */
        /************************************************************************/

        public static Matrix3D GetAxisXSymmetry()
        {
            Matrix3D newMatrix = new Matrix3D();

            newMatrix.m[0, 0] = 1; newMatrix.m[0, 1] = 0; newMatrix.m[0, 2] = 0;
            newMatrix.m[1, 0] = 0; newMatrix.m[1, 1] = -1; newMatrix.m[1, 2] = 0;
            newMatrix.m[2, 0] = 0.0f; newMatrix.m[2, 1] = 0.0f; newMatrix.m[2, 2] = 1.0f;

            return newMatrix;
        }
    }
}
