using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestSharpGL.VectorClass
{
    class Coordinate
    {
        Vector2D m_Center = new Vector2D();

        public Vector2D Center 
        {
            get { return m_Center; }
            set { m_Center = value; }
        }

        int m_bottom = 0;
        public int Bottom
        {
            get { return m_bottom; }
            set { m_bottom = value; }
        }

        int m_top = 0;
        public int Top
        {
            get { return m_top; }
            set { m_top = value; }
        }

        int m_left = 0;
        public int Left
        {
            get { return m_left; }
            set { m_left = value; }
        }

        int m_right = 0;
        public int Right
        {
            get { return m_right; }
            set { m_right = value; }
        }

        public Coordinate()
        {

        }

        public Coordinate(float x, float y, int bottom, int top, int left, int right)
        {
            m_Center.X = x;
            m_Center.Y = y;
            m_bottom = bottom;
            m_left = left;
            m_right = right;
            m_top = top;
        }
    }
}
