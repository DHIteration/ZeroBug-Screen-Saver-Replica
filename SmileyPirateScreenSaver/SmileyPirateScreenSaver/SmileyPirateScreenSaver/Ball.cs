using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmileyPirate
{
    class Ball
    {

        private double m_Radius = 0;
        public double Radius
        {
            get { return this.m_Radius;  }
            set { this.m_Radius = value; }
        }

        private double m_X = 0;
        public double X
        {
            get { return this.m_X;  }
            set { this.m_X = value; }
        }

        private double m_Y = 0;
        public double Y
        {
            get { return this.m_Y;  }
            set { this.m_Y = value; }
        }


        private double m_Vx = 0;
        public double Vx
        {
            get { return this.m_Vx;  }
            set { this.m_Vx = value; }
        }


        private double m_Vy = 0;
        public double Vy
        {
            get { return this.m_Vy;  }
            set { this.m_Vy = value; }
        }


        private double m_Mass = 0;
        public double Mass
        {
            get { return this.m_Mass;  }
            set { this.m_Mass = value; }
        }


        private int m_Tag = 0;
        public int Tag
        {
            get { return this.m_Tag;  }
            set { this.m_Tag = value; }
        }


        private bool m_Grow = false;
        public bool Grow
        {
            get { return this.m_Grow;  }
            set { this.m_Grow = value; }
        }


        private int m_Direction = 0;
        public int Direction
        {
            get { return this.m_Direction;  }
            set { this.m_Direction = value; }
        }

    }

}
