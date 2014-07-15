using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSharpGL.VectorClass
{
    class Light
    {

        public Light() { }
        public Light(LightMode mode)
        {
            m_Mode = mode;
        }

        /// <summary>
        ///  PointLight 为点光源
        ///  Directional 为平行光
        ///  Spot 为聚光灯
        /// </summary>
        public enum LightMode
        {
            PointLight,
            Directional,
            Spot
        };

        LightMode m_Mode = LightMode.PointLight;

        public LightMode Mode
        {
            get { return m_Mode; }
            set { m_Mode = value; }
        }
    }
}
