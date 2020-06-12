using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_tac_toe_csharp
{
    //This holder class is for knowing each rectangle taken by which player
    class Holder
    {
        private Point location;

        private int state = 0;

        public void setLocation(Point point)
        {
            this.location = point;
        }

        public Point getLocation()
        {
            return this.location;
        }

        public void setState(int state)
        {
            this.state = state;
        }

        public int getState()
        {
            return this.state;
        }

    }
}
