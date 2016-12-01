using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiggestJourney
{
    class  Player : MovingObject, IObjects
    {
        //public int PositionX { get; set; }
        //public int PositionY { get; set; }
        public Image ObjectImage { get; set; }
        public bool IsPlayerLived { get; set; }

        public Player(int x, int y, Image image)
        {
            PositionX = x;
            PositionY = y;
            ObjectImage = image;
            IsPlayerLived = true;
        }

        public void updatePosition()
        {
            Grid.SetColumn(ObjectImage, PositionX);
            Grid.SetRow(ObjectImage, PositionY);
        }

        public override bool CanObjectMove(int x, int y)
        {
            if (Game.objectList[0].PositionX == x && Game.objectList[0].PositionY == y)
                return true;

            foreach (IObjects item in Game.objectList)
            {
                if (item.PositionX == x && item.PositionY == y)
                    return false;
            }
            if (x < 1 || x > 9 || y < 1 || y > 9)
                return false;
            if (!((PositionX + 1 == x || PositionX - 1 == x || PositionX == x) && (PositionY + 1 == y || PositionY - 1 == y || PositionY == y)))
                return false;

            return true;
        }

        public bool CanObjectJump(int x, int y)
        {
            int distanceX = PositionX - x;
            int distanceY = PositionY - y;
            if (Game.objectList[0].PositionX == x && Game.objectList[0].PositionY == y)
                return true;

            foreach (IObjects item in Game.objectList)
            {
                if (item.PositionX == x && item.PositionY == y)
                    return false;
            }
            if (x < 1 || x > 9 || y < 1 || y > 9)
                return false;
            if (!(
                (distanceX>-3 && distanceX<3) && (distanceY>-3 && distanceY<3)
                ))
                return false;

            return true;

        }

    }
}
