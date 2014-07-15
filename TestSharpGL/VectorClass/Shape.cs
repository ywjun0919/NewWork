using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSharpGL.VectorClass
{
    enum ShapeMode{
        Triangle ,
        Rectangle
    }
    /************************************************************************/
    /* 形状类                                                               */
    /************************************************************************/

    class Shape
    {
        public Node m_node = new Node();

        public ShapeMode m_mode = ShapeMode.Triangle;

        public Shape() { }

        public Shape(Node node)
        {
            m_node = node;
        }

        public Shape(Node node, ShapeMode mode)
        {
            m_node = node;
            m_mode = mode; 
        }

        public bool Assert()
        {
            if (m_mode == ShapeMode.Triangle)
            {
            }
            //判断是否能组成一个三角形
            return true;
        }

    }

    /************************************************************************/
    /* 三角形类                                                         */
    /************************************************************************/
    class Triangle:Shape
    {

        public Vertex V1
        {
            get { return m_node.GetVertex(0); }
        }
        public Vertex V2
        {
            get { return m_node.GetVertex(1); }
        }
        public Vertex V3
        {
            get { return m_node.GetVertex(2); }
        }

        public Triangle(Vertex v1,Vertex v2,Vertex v3) 
        {
            m_node.Add(v1);
            m_node.Add(v2);
            m_node.Add(v3);
        }
        Vector3D N = new Vector3D();

        public Vector3D GetN()
        {
            Vector3D v1 = new Vector3D( V2.V_Position - V1.V_Position);
            Vector3D v2 = new Vector3D( V3.V_Position - V1.V_Position);
            Vector3D v = v1.CrossMultiply(v2);

            return v/v.Module();
        }
    }
}
