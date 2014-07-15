using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestSharpGL.VectorClass
{
    /************************************************************************/
    /* 顶点类                                                               */
    /************************************************************************/
    class Vertex
    {
        //设置属性默认值
        Color v_Color = Color.Black;
        public Color V_Color
        {
            get { return v_Color; }
            set { v_Color = value; }
        }
        Vector3D v_Position = new Vector3D(Vector3D.ZERO);

        public Vector3D V_Position 
        {
            get { return v_Position; }
            set { v_Position = value; }
        }
        public Vertex()
        {

        }

        public Vertex(Vertex vertex)
        {
            v_Position = vertex.v_Position;
            v_Color = vertex.V_Color;
        }

        public Vertex(Vector3D vec) 
        {
            v_Position = vec;
        }

        public Vertex(float x,float y ,float z)
        {
            v_Position.X = x;
            v_Position.Y = y;
            v_Position.Z = z;
        }

        public Vertex(float x, float y, float z,Color color)
        {
            v_Position.X = x;
            v_Position.Y = y;
            v_Position.Z = z;
            v_Color = color;
        }

        public Vertex(Vector3D vec, Color color) 
        {
            v_Color = color;
            v_Position = vec;
        }

        public object Clone()
        {
            Vertex v = new Vertex();
            v.v_Color = v_Color;
            v.v_Position = v_Position;

            return v;
        }
        //纹理属性
    }

}
