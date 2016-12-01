using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiggestJourney
{
    abstract class MovingObject
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public virtual bool CanObjectMove(int x, int y)
        {
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

        public void Move(int x, int y)
        {
            PositionX = x;
            PositionY = y;
        }
    }
}
//public int PositionX { get; set; }
//public int PositionY { get; set; }
////public Image MovingObjectImage { get; set; }

//public MovingObject(int x, int y)
//{
//    PositionX = x;
//    PositionY = y;
//}


//public MoveStatus AbleToMove(int moveX, int moveY, List<MovingObject> movingObjectList, MovingObject movingObject, Exit exit)
//{
//    bool test = false;
//    foreach (MovingObject otherObjects in movingObjectList)
//    {
//        if ((otherObjects.PositionX == moveX) && (otherObjects.PositionY == moveY))
//            return MoveStatus.NoMove;
//    }
//    //if (PositionX - moveX > 1 || PositionX - moveX < -1 || PositionY - moveY > 1 || PositionY - moveX < -1)
//    //    return false;
//    if (!((PositionX == moveX || PositionX + 1 == moveX || PositionX - 1 == moveX) && (PositionY == moveY || PositionY + 1 == moveY || PositionY - 1 == moveY)))
//        return MoveStatus.NoMove;

//    if (moveX < 1 || moveX > 9 || moveY < 1 || moveY > 9)
//        return MoveStatus.NoMove;
//    if (moveX == exit.PositionX && moveY == exit.PositionY)
//        return MoveStatus.NextRound;
//    movingObject.PositionX = moveX;
//    movingObject.PositionY = moveY;

//    foreach (MovingObject objectToKill in movingObjectList)
//    {
//        if (objectToKill is Enemy)
//        {
//            if ((objectToKill.PositionX == moveX || objectToKill.PositionX + 1 == moveX || objectToKill.PositionX - 1 == moveX)
//                && (objectToKill.PositionY == moveY || objectToKill.PositionY + 1 == moveY || objectToKill.PositionY - 1 == moveY))
//            {
//                objectToKill.PositionX = 0;
//                objectToKill.PositionY = 0;
//                test = true;
//            }

//        }

//    }
//    if (test == true) return MoveStatus.KillEnemy;
//    return MoveStatus.YesMove;
//}

//public void UpdateMovingObjectPosition(Image nImage)
//{
//    Grid.SetColumn(nImage, PositionX);
//    Grid.SetRow(nImage, PositionY);
//}