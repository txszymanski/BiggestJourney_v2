using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiggestJourney
{
    class Exit : IObjects
    {

        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Image ObjectImage { get; set; }

        public Exit(int x, int y, Image image)
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


        //public void UpdateExitPosition(Image exitImage)
        //{
        //    Grid.SetColumn(exitImage, PositionX);
        //    Grid.SetRow(exitImage, PositionY);
        //}
    }
}
