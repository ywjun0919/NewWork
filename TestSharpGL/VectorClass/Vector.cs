using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSharpGL.VectorClass
{
    public class Vector:ICloneable
    {
        //将类型定义为 typedef Float float;C#是否只能用类或结构体来实现
        //坐标系上的点
        protected List<float> point = new List<float>();
        public List<float> Point 
        {
            get { return point; }
            set { point = value; }
        }
        //维数
        protected int _dim = 0;
        #region 构造函数
        public Vector() { }
        public Vector(Vector v) { }
        public Vector(int dim)
        {
            _dim = dim;
            if (dim <= 0)
            {
                Console.WriteLine("Dim must more than zero! ");
                return;
            }
            for (int i = 0; i < _dim; ++i)
            {
                point.Add(0);
            }
        }
        #endregion

        #region 向量变换
        public void Translation() { }
        public void Rotate() { }
        public void Scale() { }
        #endregion 

        #region 运算符重载

        //加法重载
        public static Vector operator +(Vector first, Vector second)
        {
            Vector res = new Vector();
           
            int size = first._dim;
            res._dim = size;
            for (int index = 0; index < size;++index )
            {
                res.point.Add(first.point[index] + second.point[index]);
            }
            return res;
        }
        //减法重载
        public static Vector operator -(Vector first, Vector second)
        {
            Vector res = new Vector();
           
            int size = first._dim;
            res._dim = size;
            for (int index = 0; index < size; ++index)
            {
                res.point.Add(first.point[index] - second.point[index]);
            }
            return res;
        }

        //乘法重载
        public static Vector operator *(float fscale, Vector vector)
        {
            int size = vector._dim;
            for (int index =0;index<size;++index)
            {
                vector.point[index] = fscale * vector.point[index];
            }
            return vector;
        }

        public static Vector operator *(Vector first, Vector second)
        {
            Vector res = new Vector();
          
            int size = first._dim;
            res._dim = size;
            for (int index = 0;index<size;++index)
            {
                res.point.Add(first.point[index] * second.point[index]);
            }
            return res;
        }
        //除法重载
        public static Vector operator /( Vector vector,float fscale)
        {
            int size = vector._dim;
            for (int index = 0; index < size; ++index)
            {
                vector.point[index] = vector.point[index]/fscale ;
            }
            return vector;
        }

        public static Vector operator /(Vector first, Vector second)
        {
            Vector res = new Vector();

            int size = first._dim;
            res._dim = size;
            for (int index = 0; index < size; ++index)
            {
                res.point.Add(first.point[index] / second.point[index]);
            }
            return res;
        }

        #endregion
        //点乘

        public float DotMultiply(Vector vector)
        {
            int size = _dim;
            float res = 0;
            for (int index = 0; index < size; ++index)
            {
                res += this.point[index] * vector.point[index];
            }
            return res;
        }
        //叉乘

        public Vector CrossMultiply(Vector vector)
        {
            return new Vector();
        }
        
        //模
        public float Module()
        {
            return (float) Math.Sqrt(DotMultiply(this));
        }
        //深克隆
        public object Clone()
        {
            Vector newVector = new Vector();

            newVector._dim = this._dim;
            for (int index = 0; index < _dim; ++index)
            {
                newVector.point.Add(this.point[index]);
            }

            return newVector;
        }
    }
}
