using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestSharpGL.VectorClass;
using System.Drawing;

namespace TestSharpGL
{
    /// <summary>
    /// 该类用于场景中物体的添加，如摄像机，光源（为了简化先设置光源，再补充）
    /// </summary>
    class Scene
    {
        //添加光源
        List<Light> m_Light = new List<Light>();
        //添加摄像机

        List<Camera> m_Camera = new List<Camera>();

        //添加图形

        public Scene() { }

        public void LightAdd( Light light)
        {
            m_Light.Add(light);
        }

        public void CameraAdd(Camera camera)
        {
            m_Camera.Add(camera);
        }

        //暂时一个光照
        int camera_Index = 0;
        int light_Index = 0;
        public Camera GetCurCamera()
        {
            return m_Camera[camera_Index];
        }

        public Light GetCurLight()
        {
            return m_Light[light_Index];
        }

        public List<Light> SceneLight
        {
            get { return m_Light; }
        }

        public List<Camera> SceneCamera
        {
            get { return m_Camera; }
        }
    }

    /// <summary>
    /// 对场景进行管理
    /// </summary>
    class SceneManager
    {
        private static SceneManager instance;
        private SceneManager(){}
        
        public static SceneManager CreateSceneManager()
        {
            if (null == instance)
            {
                instance = new SceneManager();
            }
            return instance;
        }

        Scene m_scene = new Scene();

        //添加光照

        public Scene scene
        {
            get { return m_scene; }
        }

        //根据光源、摄像机对点进行渲染
        public void ScenceRender(ref Vertex vertex, Vector3D N)
        {
            if (m_scene.SceneLight.Count<=0)
            {
                return;
            }

            List<Light> light = m_scene.SceneLight;

            List<Vector3D> Ip = new List<Vector3D>();
            List<Vector3D> L = new List<Vector3D>();
            Camera camera = m_scene.GetCurCamera();
            for (int index =0 ;index<light.Count;++index)
            {
                PointLight temp_Light = (PointLight)light[index];
                Color light_Color = temp_Light.PL_Color;
                Ip.Add(new Vector3D(light_Color.R,light_Color.G,light_Color.B));

                L.Add(new Vector3D(temp_Light.PL_Position - vertex.V_Position));

            }

            Vector3D Ia = new Vector3D(Color.White.R, Color.White.G, Color.White.B);
            Vector3D Ka = new Vector3D(0.3f, 0.7f, 0.0f);
            Vector3D Kd = new Vector3D(0.4f, 0.4f, 0.2f);
            Vector3D Ks = new Vector3D(0.0f, 0.0f, 1f);
            Vector3D V = new Vector3D(vertex.V_Position - camera.VRP);

            Vector3D v = Common.GetBrightness(Ia, Ip, Ka, Kd, Ks, L, N, V);

            vertex.V_Color = Color.FromArgb((int)Math.Abs(v.X), (int)Math.Abs(v.Y), (int)(int)Math.Abs(v.Z));
        }
    }
}
