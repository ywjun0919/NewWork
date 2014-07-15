using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSharpGL.VectorClass
{
    class Common
    {
        enum ProjectMode{
            Perspective,
            Parallel
        };

        public static void swap(ref float a, ref float b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }

        /************************************************************************/
        /* 该函数用于进行投影变换 ,prp 表示投影参考点,Q表示要投影的点，
         *默认为透视投影                                                        */
        /************************************************************************/
        public static Vector2D ProjectTransform(Vector3D prp,Vector3D Q)
        {
            Matrix4D projectMatrix = TransformMatrix.GetMPer(prp);

            Vector4D new_prp = new Vector4D(Q.X,Q.Y,Q.Z,1);
            Vector4D res =  new_prp * projectMatrix;
            return new Vector2D(res.X / res.W, res.Y / res.W);
        }

        public static Matrix3D TransformToNewCoordinate(Coordinate Coordinate)
        {
            return Matrix3D.GetAxisXSymmetry() * Matrix3D.GetTrans(Coordinate.Center.X, Coordinate.Center.Y);
        }

        /// <summary> 漫反射和环境光,获取色彩
        ///   漫反射和环境光求取亮度(暂时放于此处，且如何能产生色彩呢)  需要加入衰减函数(f(d))   
        ///   Ia 表示环境光的颜色（R,G,B）
        ///   Ip 表示光源的颜色，表示可以有多个光源
        ///   Ka 表示物体表面的环境光反射系数
        ///   Kd 表示物体表面的漫反射系数
        ///   Ks 表示物体表面的镜面反射系数
        ///   L为物体上的点到光源的向量，N为物体表面的法向量，V为物体上的点到视点的向量
        /// </summary>
        public static Vector3D GetBrightness(Vector3D Ia, List<Vector3D> Ip, Vector3D Ka, Vector3D Kd, Vector3D Ks, List<Vector3D> L, Vector3D N, Vector V)
        {
            if (Ip.Count != L.Count)
            {
                Console.WriteLine("参数错误！");
                return Vector3D.ZERO;
            }

            int size = Ip.Count;

            //I返回最后观察到的颜色值，ka * Ia 表示环境光
            Vector3D I = new Vector3D(Ka * Ia) ;

            //需要单独的参数传入，暂时不传入
            Vector3D CDecay = new Vector3D(1,0.01f,0.00001f);

            for (int i = 0; i < size; ++i )
            {
                Vector3D H = new Vector3D((L[i] + V) / 2.0f);

                float d = L[i].Module();
                float f = DecayFunction(d, CDecay.X, CDecay.Y, CDecay.Z);
                I = I + f * Ip[i] * (L[i].DotMultiply(N) * Kd / L[i].Module() + H.DotMultiply(N) * Ks / H.Module());
            }
            return I;
        }

        /************************************************************************/
        /* 衰减函数，其中C0,C1,C2的值用以控制f(d)变化的快慢，常数项C0防止f(d)变化过大*/
        /* f(d)的最大值为1，d表示物体距离光源的距离                               */
        /************************************************************************/
        public static float DecayFunction(float d,float C0,float C1, float C2)
        {
            float fd = 1.0f/(C0 + C1* d + C2 * d * d);
            return fd < 1 ? fd : 1;
        }
    }
}
