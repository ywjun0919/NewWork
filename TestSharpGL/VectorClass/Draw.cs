using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestSharpGL.VectorClass
{
    /************************************************************************/
    /* 该类用于绘制图形                                                     */
    /************************************************************************/
    class Draw
    {
        #region 属性
        //视窗的矩形
        Bitmap _bmp;
        public  Shape m_shape = new Shape();
        private Graphics _graphics;
        private Color _color = Color.Black;
        private Coordinate coordinate;

        public Bitmap Bmp
        {
            get { return _bmp; }
            set { _bmp = value; }
        }
        public Graphics graphics
        {
            get { return _graphics; }
            set { _graphics = value; }
        }
        public Color color 
        {
            get { return _color; }
            set { _color = value; }
        }
        public void SetColor(int r, int g, int b)
        {
            color = Color.FromArgb(r, g, b);
        }
        
        #endregion

        #region 构造函数


        public Draw()
        {
        }

        public Draw(Bitmap bmp)
        {
            Bmp = bmp;
        }
        #endregion

        #region 方法
        /// <summary>
        /// 开始绘制
        /// </summary>
        /// <param name="g"></param>
        public void Begin(Graphics g) 
        {
            graphics = g;
            DrawCoordinates2D();
        }
        public void End() 
        {
            graphics.DrawImage(Bmp, new Rectangle(100, 0, 500, 600));
            //m_shape = null;//暂时这样
        }
        public void DrawPixel(Vector2D point)
        {
            Vector3D newVector = new Vector3D(point.X, point.Y, 1) * Common.TransformToNewCoordinate(coordinate);
            Bmp.SetPixel((int)newVector.X, (int)newVector.Y, color);
        }

        public void DrawPixel(Vector2D point,Color c) 
        {
            color = c;
            Vector3D newVector = new Vector3D(point.X, point.Y, 1) * Matrix3D.GetAxisXSymmetry() * Matrix3D.GetTrans(coordinate.Center.X, coordinate.Center.Y);
            Bmp.SetPixel((int)newVector.X, (int)newVector.Y, color);
        }

        public void DrawLineByDDA(Vector2D point1,Vector2D point2)
        {
            float x;
            float dy, dx, y, m;

            Vector2D new_Point1 = new Vector2D(point1);
            Vector2D new_Point2 = new Vector2D(point2);
            if (new_Point1.X > new_Point2.X)
            {
                new_Point1.SwapVector(new_Point2);
            }

            dx = new_Point2.X - new_Point1.X;
            dy = new_Point2.Y - new_Point1.Y;

            if (Math.Abs(dx - 0.0) < 0.000001)
            {
                float min = new_Point1.Y, max = new_Point2.Y;
                if (new_Point1.Y>new_Point2.Y)
                {
                    min = new_Point2.Y;
                    max = new_Point1.Y;
                }
                for (y = min; y <= max; ++y)
                {
                    DrawPixel(new Vector2D(new_Point1.X, y), color);
                }
            }
            else 
            {
                m = dy / dx;
                
                y = new_Point1.Y;
                float min = new_Point1.Y, max = new_Point2.Y;
                
                if (min>max)
                {
                    Common.swap(ref min, ref max);
                }

                for (x = new_Point1.X; x <= new_Point2.X; ++x)
                {
                    if (0 == m)
                    {
                        DrawPixel(new Vector2D(x, new_Point1.Y), color);
                    }
                    else
                    {
                        for (float i = 0; i < Math.Abs(m); ++i)
                        {
                            DrawPixel(new Vector2D(x, 0.5f + y + i), color);
                            if (0.5f + y + i < min || 0.5f + y + i > max)
                            {
                                break;
                            }
                        }
                        y += m;
                    } 
                }
            }
        }

        public void DrawSharp()
        {
            int size = m_shape.m_node.GetVertexNum();
            Vector3D prp = sceneManager.scene.GetCurCamera().VRP;//暂时这样
            List<Vector2D> vector_Buffer = new List<Vector2D>();
            for (int index = 0; index < size;++index )
            {
                Vertex Vertex = m_shape.m_node.GetVertex(index);

                Vector2D proVec = Common.ProjectTransform(prp, Vertex.V_Position);
                vector_Buffer.Add(proVec);
            }

            if (m_shape.m_mode == ShapeMode.Triangle)
            {
                for (int index = 0; index < vector_Buffer.Count;index +=3 )
                {
                    if (index %3 != 3)
                    {
                        DrawLineByDDA(vector_Buffer[index], vector_Buffer[index + 1]);
                        DrawLineByDDA(vector_Buffer[index+1], vector_Buffer[index + 2]);
                        DrawLineByDDA(vector_Buffer[index + 2], vector_Buffer[index]);
                    }
                }
            }
        }

        public void DrawCoordinates2D()
        {
            coordinate = new Coordinate(200, 200, 100, 100, 200, 200);
            color = Color.Yellow;
            DrawLineByDDA(new Vector2D( - coordinate.Left,0), new Vector2D( coordinate.Right, 0));
            DrawLineByDDA(new Vector2D(0,  - coordinate.Top), new Vector2D(0,coordinate.Bottom));
            color = Color.Blue;
            //color = Color.Blue;

            //Vector3D newVector = new Vector3D(10, 10, 1) * Matrix3D.GetAxisXSymmetry() * Matrix3D.GetTrans(coordinate.Center.X, coordinate.Center.Y);
            //int x = (int)newVector.X;
            //int y = (int)newVector.Y;

            //DrawPixel(new Vector2D(x, y));
            //DrawPixel(new Vector2D(x - 1, y));
            //DrawPixel(new Vector2D(x, y - 1));
            //DrawPixel(new Vector2D(x + 1, y));
            //DrawPixel(new Vector2D(x, 1));
        }
        
        //具有环境光的线条画线方法（需要与画线方法合并）
        SceneManager sceneManager =SceneManager.CreateSceneManager();

        public void DrawLineByDDA(Vertex point1, Vertex point2)
        {
            float x;
            float dy, dx, y, m;

            Vector2D new_Point1 = new Vector2D(point1.V_Position);
            Vector2D new_Point2 = new Vector2D(point2.V_Position);
            if (new_Point1.X > new_Point2.X)
            {
                new_Point1.SwapVector(new_Point2);
            }

            dx = new_Point2.X - new_Point1.X;
            dy = new_Point2.Y - new_Point1.Y;

            if (Math.Abs(dx - 0.0) < 0.000001)
            {
                float min = new_Point1.Y, max = new_Point2.Y;
                if (new_Point1.Y > new_Point2.Y)
                {
                    min = new_Point2.Y;
                    max = new_Point1.Y;
                }
                for (y = min; y <= max; ++y)
                {
                    Vector3D color1 = new Vector3D(point1.V_Color.R, point1.V_Color.G, point1.V_Color.B);
                    Vector3D color2 = new Vector3D(point2.V_Color.R, point2.V_Color.G, point2.V_Color.B);

                    Vector3D color3 = (y - new_Point2.Y) / (new_Point1.Y - new_Point2.Y) * color1 + (new_Point1.Y - y) / (new_Point1.Y - new_Point2.Y) * color2;

                    color = Color.FromArgb((int)color3.X, (int)color3.Y, (int)color3.Z);
                    DrawPixel(new Vector2D(new_Point1.X, y), color);
                }
            }
            else
            {
                m = dy / dx;

                y = new_Point1.Y;
                float min = new_Point1.Y, max = new_Point2.Y;

                if (min > max)
                {
                    Common.swap(ref min, ref max);
                }

                for (x = new_Point1.X; x <= new_Point2.X; ++x)
                {
                    if (0 == m)
                    {
                        Vector3D color1 = new Vector3D(point1.V_Color.R, point1.V_Color.G, point1.V_Color.B);
                        Vector3D color2 = new Vector3D(point2.V_Color.R, point2.V_Color.G, point2.V_Color.B);

                        Vector3D color3 = (new_Point2.X - x) / (new_Point2.X - new_Point1.X) * color1 + (x - new_Point1.X) / (new_Point2.X - new_Point1.X) * color2;

                        color = Color.FromArgb((int)color3.X, (int)color3.Y, (int)color3.Z);
                        DrawPixel(new Vector2D(x, new_Point1.Y), color);
                    }
                    else
                    {
                        for (float i = 0; i < Math.Abs(m); ++i)
                        {
                            Vector3D color1 = new Vector3D(point1.V_Color.R, point1.V_Color.G, point1.V_Color.B);
                            Vector3D color2 = new Vector3D(point2.V_Color.R, point2.V_Color.G, point2.V_Color.B);

                            Vector3D color3 = (y - new_Point2.Y) / (new_Point1.Y - new_Point2.Y) * color1 + (new_Point1.Y - y) / (new_Point1.Y - new_Point2.Y) * color2;

                            color = Color.FromArgb((int)color3.X, (int)color3.Y, (int)color3.Z);
                            DrawPixel(new Vector2D(x, 0.5f + y + i), color);
                            if (0.5f + y + i < min || 0.5f + y + i > max)
                            {
                                break;
                            }
                        }
                        y += m;
                    }
                }
            }
        }

        //画三角形
        public void DrawTriangle()
        {
            int size = m_shape.m_node.GetVertexNum();
            Vector3D prp = sceneManager.scene.GetCurCamera().VRP;//暂时这样
            List<Vertex> vertex_Buffer = new List<Vertex>();
            for (int index = 0; index < size; index+= 3)
            {
                if (index % 3 != 3)
                {
                    Triangle triangle = new Triangle(m_shape.m_node.GetVertex(index), m_shape.m_node.GetVertex(index + 1), m_shape.m_node.GetVertex(index + 2));

                    for (int i =0;i<3;++i)
                    {
                        Vertex v = triangle.m_node.GetVertex(i);
                        sceneManager.ScenceRender(ref v, triangle.GetN());
                        Vector2D proVec = Common.ProjectTransform(prp, v.V_Position);
                        vertex_Buffer.Add(new Vertex(proVec.X,proVec.Y,1,v.V_Color));
                    }
                  
                }
            }

            if (m_shape.m_mode == ShapeMode.Triangle)
            {
                for (int index = 0; index < vertex_Buffer.Count; index += 3)
                {
                    if (index % 3 != 3)
                    {
                        DrawLineByDDA(vertex_Buffer[index], vertex_Buffer[index + 1]);
                        DrawLineByDDA(vertex_Buffer[index + 1], vertex_Buffer[index + 2]);
                        DrawLineByDDA(vertex_Buffer[index + 2], vertex_Buffer[index]);
                    }
                }
            }
        }
        #endregion
        
    }
}
