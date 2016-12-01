using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiggestJourney
{
    class NonMovingObject : IObjects
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Image ObjectImage { get; set; }

        public NonMovingObject(int x, int y, Image image)
        {
            PositionX = x;
            PositionY = y;
            ObjectImage = image;
        }

        public void updatePosition()
        {
            Grid.SetColumn(ObjectImage, PositionX);
            Grid.SetRow(ObjectImage, PositionY);
        }
    }
}
