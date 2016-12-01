using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiggestJourney
{
    class Bat : Enemy
    {
        public Bat(int x, int y, Image image)
        {
            PositionX = x;
            PositionY = y;
            ObjectImage = image;
        }
    }
}
