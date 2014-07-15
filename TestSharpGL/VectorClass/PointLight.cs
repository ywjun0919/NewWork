using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestSharpGL.VectorClass
{
    /// <summary>
    /// m_Position 光源在世界坐标系中的坐标
    /// m_Color 光照的颜色
    /// m_Intensity 光照的强度
    /// m_Range 光照的影响范围（暂时不考虑吧。。。应该是一个球形吧）
    /// </summary>
    class PointLight:Light
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PointLight():base(LightMode.PointLight)
        {
        }

        public PointLight(float position_X, float position_Y, float position_Z, int color_x, int color_y, int color_z, float intensity)
            : base(LightMode.PointLight)
        {
            m_Position.X = position_X;
            m_Position.Y = position_Y;
            m_Position.Z = position_Z;

            m_Color = Color.FromArgb(color_x,color_y,color_z);
            m_Intensity = intensity;
        }

        public PointLight(float position_X, float position_Y, float position_Z, Color color, float intensity)
            : base(LightMode.PointLight)
        {
            m_Position.X = position_X;
            m_Position.Y = position_Y;
            m_Position.Z = position_Z;

            m_Color = color;
            m_Intensity = intensity;
        }

        public PointLight(Vector3D position, Color color, float intensity)
            : base(LightMode.PointLight)
        {
            m_Position = position;
            m_Color = color;
            m_Intensity = intensity;
        }
        /// <summary>
        /// 属性
        /// </summary>
        private Vector3D m_Position = new Vector3D();
        private Color m_Color = Color.White;
        private float m_Intensity = 0.0f;

        public Vector3D PL_Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        public Color PL_Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public float PL_Intensity
        {
            get { return m_Intensity; }
            set { m_Intensity = value; }
        }
    }
}
