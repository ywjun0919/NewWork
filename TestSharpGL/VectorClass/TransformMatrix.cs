using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSharpGL.VectorClass
{
    /************************************************************************/
    /* 变换矩阵类                                                           */
    /************************************************************************/
    class TransformMatrix
    {
        //平移变换矩阵

        //缩放变换矩阵
        
        //旋转变换矩阵
        
        //错切变换矩阵
        
        //对称变换矩阵
        
        //透视变化矩阵

        public static Matrix4D GetMPer(Vector3D prp)
        {
            Matrix4D newMatrix = new Matrix4D();

            newMatrix.m[0, 0] = 1.0f; newMatrix.m[0, 1] = 0.0f; newMatrix.m[0, 2] = 0.0f; newMatrix.m[0, 3] = 0.0f;
            newMatrix.m[1, 0] = 0.0f; newMatrix.m[1, 1] = 1.0f; newMatrix.m[1, 2] = 0.0f; newMatrix.m[1, 3] = 0.0f;
            newMatrix.m[2, 0] = 0.0f; newMatrix.m[2, 1] = 0.0f; newMatrix.m[2, 2] = 0.0f; newMatrix.m[2, 3] = 0.0f;
            newMatrix.m[3, 0] = 0.0f; newMatrix.m[3, 1] = 0.0f; newMatrix.m[3, 2] = - 1.0f/prp.Z; newMatrix.m[3, 3] = 1.0f;

            return newMatrix;
        }

        //public static Matrix3D Get2DTranslation()
        //{
            
        //}
    }
}
