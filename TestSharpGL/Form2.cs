using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TestSharpGL.VectorClass;

namespace TestSharpGL
{
    public partial class Form2 : Form
    {
        Bitmap bmp;
       
        uint state = 2;

        Node node = new Node();

        SceneManager sceneManager = SceneManager.CreateSceneManager();

        void StateChange(uint newState)
        {
            state = newState;
        }
        public Form2()
        {
            InitializeComponent();

           // this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Camera camera = new Camera();

            //设置照相机的参考点
            camera.VRP = new Vector3D(0, 0, -200);
           
            sceneManager.scene.CameraAdd(camera);

            bmp = new Bitmap(1000, 1000);

            //draw = new Draw(bmp);

            node.Add(new Vertex(0.0f, 50.0f, 0.0f));
            node.Add(new Vertex(-50.0f, -50.0f, 50.0f));
            node.Add(new Vertex(50.0f, -50.0f, 50.0f));

            node.Add(new Vertex(0.0f, 50.0f, 0.0f));
            node.Add(new Vertex(50.0f, -50.0f, 50.0f));
            node.Add(new Vertex(50.0f, -50.0f, -50.0f));

            node.Add(new Vertex(0.0f, 50.0f, 0.0f));
            node.Add(new Vertex(50.0f, -50.0f, -50.0f));
            node.Add(new Vertex(-50.0f, -50.0f, -50.0f));

            node.Add(new Vertex(0.0f, 50.0f, 0.0f));
            node.Add(new Vertex(-50.0f, -50.0f, -50.0f));
            node.Add(new Vertex(-50.0f, -50.0f, 50.0f));
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            ////显示图片

            //float x = (this.ClientRectangle.Width - 100) / 2;
            //float y = (this.ClientRectangle.Height) / 2;

            //bmp.SetPixel((int)x, (int)y, Color.Blue);
            //bmp.SetPixel((int)x, (int)y + 1, Color.Blue);
            //bmp.SetPixel((int)x + 1, (int)y + 1, Color.Blue);
            //bmp.SetPixel((int)x + 1, (int)y, Color.Blue);
            //bmp.SetPixel((int)x - 1, (int)y - 1, Color.Blue);
            //bmp.SetPixel((int)x - 1, (int)y, Color.Blue);

            //graphics.DrawImage(bmp, new Rectangle(100, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));
            bmp = new Bitmap(1000, 1000);
            Draw draw = new Draw(bmp);
            draw.Begin(graphics);
            draw.DrawCoordinates2D();
            draw.End();
            if (0 == state) 
            {
                Line1(graphics);
            }
            else if (1 == state)
            {
                Line2(graphics);
            }
            else if (2 == state  )
            {
                DrawTriangle( graphics);
            }
            else if (3 == state)
            {
                int i =0;
               // while(i<10)
                {
                   // this.Refresh();
                    this.SetStyle(ControlStyles.ResizeRedraw |
              ControlStyles.OptimizedDoubleBuffer |
              ControlStyles.AllPaintingInWmPaint, true);
                    this.UpdateStyles();
                    bmp = new Bitmap(1000, 1000);
                    draw = new Draw(bmp);
                    draw.Begin(graphics);
                    draw.DrawCoordinates2D();
                    draw.End();
                    Rotation(graphics,i+5);
                    
                }
            }
        }

        private void LineTest_Click(object sender, EventArgs e)
        {
            StateChange(1);
            this.Refresh();
        }

        public void Line1(Graphics graphics) 
        {
            Draw draw = new Draw(bmp);
            draw = new Draw(bmp);
            draw.Begin(graphics);
            draw.color = Color.Red;
            Vector2D v2 = new Vector2D(10, 20);
            Vector2D v1 = new Vector2D(50, 80);
            draw.DrawLineByDDA(v1, v2);
            draw.End();
        }

        public void Line2(Graphics graphics)
        {
            Draw draw = new Draw(bmp);
            draw.Begin(graphics);
            draw.color = Color.Red;
            Vector2D v2 = new Vector2D(100, 20);
            Vector2D v1 = new Vector2D(50, 80);
            draw.DrawLineByDDA(v1, v2);
            draw.End();
        }

        public void Rotation(Graphics graphics, double theta)
        {
            
           // System.Threading.Thread.Sleep(1000);
            bmp = new Bitmap(1000, 1000);
            Draw draw = new Draw(bmp);
            //Node new_Node = new Node(node);
            
            for (int i = 0; i < node.GetVertexNum();++i )
            {
                node.Vertexs[i].V_Position = node.Vertexs[i].V_Position * Matrix4D.GetYAxisRotation(theta);
            }

            draw.Begin(graphics);

            Vector3D v1 = new Vector3D(1, 2, 3);
            Vector3D v2 = new Vector3D(3, 2, 3);
            List<Vector3D> list_vector = new List<Vector3D>();
            list_vector.Add(v1);
            list_vector.Add(v2);

            draw.m_shape.m_node = node;
            draw.DrawTriangle();
            draw.End();
        }

        private void button_Triangle_Click(object sender, EventArgs e)
        {
            StateChange(2);
            this.Refresh();
        }

        protected void DrawTriangle(Graphics graphics)
        {
            Draw draw = new Draw(bmp);
            draw = new Draw(bmp);
            draw.Begin(graphics);
         //   draw.color = Color.Red;

            Vector3D v1 = new Vector3D(1, 2, 3);
            Vector3D v2 = new Vector3D(3, 2, 3);
            List<Vector3D> list_vector = new List<Vector3D>();
            list_vector.Add(v1);
            list_vector.Add(v2);

            draw.m_shape.m_node = node;

            //draw.m_shape.m_node.Add(new Vertex(0.0f, 50.0f, 0.0f));
            //draw.m_shape.m_node.Add(new Vertex(-50.0f, -50.0f, 50.0f));
            //draw.m_shape.m_node.Add(new Vertex(50.0f, -50.0f, 50.0f));

            //draw.m_shape.m_node.Add(new Vertex(0.0f, 50.0f, 0.0f));
            //draw.m_shape.m_node.Add(new Vertex(50.0f, -50.0f, 50.0f));
            //draw.m_shape.m_node.Add(new Vertex(50.0f, -50.0f, -50.0f));

            //draw.m_shape.m_node.Add(new Vertex(0.0f, 50.0f, 0.0f));
            //draw.m_shape.m_node.Add(new Vertex(50.0f, -50.0f, -50.0f));
            //draw.m_shape.m_node.Add(new Vertex(-50.0f, -50.0f, -50.0f));

            //draw.m_shape.m_node.Add(new Vertex(0.0f, 50.0f, 0.0f));
            //draw.m_shape.m_node.Add(new Vertex(-50.0f, -50.0f, -50.0f));
            //draw.m_shape.m_node.Add(new Vertex(-50.0f, -50.0f, 50.0f));

            draw.DrawTriangle();
            draw.End();
        }

        private void button_Light_Click(object sender, EventArgs e)
        {
            PointLight light = new PointLight(0, 300, -100, Color.Blue, 10);
            sceneManager.scene.LightAdd(light);
            StateChange(2);
            this.Refresh();
        }

        private void button_Rotation_Click(object sender, EventArgs e)
        {
            StateChange(3);
            this.Refresh();
        }

    }

}
