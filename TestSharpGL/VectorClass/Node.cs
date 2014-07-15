using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSharpGL.VectorClass
{
    /************************************************************************/
    /* 该类实现对Vertex的管理                                                */
    /************************************************************************/
    class Node
    {
        public Node()
        {

        }

        public Node(Node node)
        {
            for (int i = 0; i < node.GetVertexNum();++i )
            {
                n_Vertexs.Add(new Vertex(node.GetVertex(i)));
            }
        }

        List<Vertex> n_Vertexs = new List<Vertex>();

        public List<Vertex> Vertexs
        {
            get { return n_Vertexs; }
        }

        //增加一个顶点
        public void Add( Vertex v)
        {
            n_Vertexs.Add(new Vertex(v.V_Position));
        }

        //删除指定位置的顶点
        public void Delete(int index)
        {
            n_Vertexs.RemoveAt(index);
        }

        //返回顶点的个数

        public int GetVertexNum()
        {
            return n_Vertexs.Count;
        }

        public Vertex GetVertex(int index)
        {
            return n_Vertexs[index];
        }
    }
}
