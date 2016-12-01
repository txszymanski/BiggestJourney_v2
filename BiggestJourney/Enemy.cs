using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiggestJourney
{
    class Enemy : MovingObject, IObjects
    {
        //public int PositionX { get; set; }
        //public int PositionY { get; set; }
        public bool playerkilled { get; private set; }
        public Image ObjectImage { get; set; }
        
        public Enemy()
        {
            playerkilled = false;
        }

        public void updatePosition()
        {
            Grid.SetColumn(ObjectImage, PositionX);
            Grid.SetRow(ObjectImage, PositionY);
        }

        public void MoveToKill()
        {
            int distanceX = PositionX - Game.objectList[1].PositionX;
            int distanceY = PositionY - Game.objectList[1].PositionY;

            if (!(PositionX == 0 && PositionY == 0))
            {
                if (this is Bat)
                {
                    //if (!playerkilled)
                    //{
                    if (distanceX == -1 || distanceX == 0 || distanceX == 1)
                    {
                        if (distanceY == 0)
                            //{
                            //    playerkilled = true;
                            //}
                            if (distanceY == -1 || distanceY == 1 || distanceY == 0)
                                //{
                                //    playerkilled = true;
                                //}
                                if (distanceY > 1 && CanObjectMove(PositionX, PositionY - 1))
                                    Move(PositionX, PositionY - 1);
                        if (distanceY < -1 && CanObjectMove(PositionX, PositionY + 1))
                            Move(PositionX, PositionY + 1);

                    }
                    //}
                    //if (!playerkilled)
                    //{
                    if (distanceX < -1)
                    {
                        if (distanceY == 0 && CanObjectMove(PositionX + 1, PositionY))
                            Move(PositionX + 1, PositionY);
                        if (distanceY <= -1 && CanObjectMove(PositionX + 1, PositionY + 1))
                            Move(PositionX + 1, PositionY + 1);
                        if (distanceY > 0 && CanObjectMove(PositionX + 1, PositionY - 1))
                            Move(PositionX + 1, PositionY - 1);
                    }
                    if (distanceX > 1)
                    {
                        if (distanceY == 0 && CanObjectMove(PositionX - 1, PositionY))
                            Move(PositionX - 1, PositionY);
                        if (distanceY <= -1 && CanObjectMove(PositionX - 1, PositionY + 1))
                            Move(PositionX - 1, PositionY + 1);
                        if (distanceY > 0 && CanObjectMove(PositionX - 1, PositionY - 1))
                            Move(PositionX - 1, PositionY - 1);
                    }
                    //}
                }
            }
        }

        public bool IsPlayerKilled()
        {
            int distanceX = PositionX - Game.objectList[1].PositionX;
            int distanceY = PositionY - Game.objectList[1].PositionY;
            if ((distanceX > -2 && distanceX < 2) && (distanceY > -2 && distanceY < 2))
                return true;
            return false;
        }

        /*public void MoveToKill(Player player, List<Enemy> enemyList)
        {
            int distanceX = PositionX - player.PositionX;
            int distanceY = PositionY - player.PositionY;
            bool isPlayerKilled = false;
            if (this is EnemyBat)
            {
                if (!isPlayerKilled)
                {
                    if (distanceX == -1 || distanceX == 0 || distanceX == 1)
                    {
                        if (distanceY == 0)
                        {
                            player.PlayerKilled();
                            isPlayerKilled = true;
                        }
                        if (distanceY == -1 || distanceY == 1 || distanceY == 0)
                        {
                            player.PlayerKilled();
                            isPlayerKilled = true;
                        }
                        if (distanceY > 1)
                            if (isPlaceFreeForEnemy(PositionX - 1, PositionY - 1, player, enemyList)) Move(-1, -1);
                        if (distanceY < -1)
                            if (isPlaceFreeForEnemy(PositionX - 1, PositionY + 1, player, enemyList)) Move(-1, 1);

                    }
                }

                if (!isPlayerKilled)
                {
                    if (distanceX < -1)
                    {
                        if (distanceY == 0)
                            if (isPlaceFreeForEnemy(PositionX + 1, PositionY, player, enemyList)) Move(1, 0);
                        if (distanceY <= -1)
                            if (isPlaceFreeForEnemy(PositionX + 1, PositionY + 1, player, enemyList)) Move(1, 1);
                        if (distanceY > 0)
                            if (isPlaceFreeForEnemy(PositionX + 1, PositionY - 1, player, enemyList)) Move(1, -1);
                    }
                    if (distanceX > 1)
                    {
                        if (distanceY == 0)
                            if (isPlaceFreeForEnemy(PositionX - 1, PositionY, player, enemyList)) Move(-1, 0);
                        if (distanceY <= -1)
                            if (isPlaceFreeForEnemy(PositionX - 1, PositionY + 1, player, enemyList)) Move(-1, 1);
                        if (distanceY > 0)
                            if (isPlaceFreeForEnemy(PositionX - 1, PositionY + 1, player, enemyList)) Move(-1, -1);
                    }

                }
            }

            if (this is EnemyGhost)
            {
                if ((distanceX == -2 && distanceY == -2) || (distanceX == -2 && distanceY == 2) || (distanceX == 2 && distanceY == -2) || (distanceX == 2 && distanceY == 2))
                {
                    player.PlayerKilled();
                    isPlayerKilled = true;
                }
                if (!isPlayerKilled)
                {
                    if (distanceX < -1)
                    {
                        if (distanceY == 0)
                            if (isPlaceFreeForEnemy(PositionX + 1, PositionY + 1, player, enemyList)) Move(1, 1);
                        if (distanceY <= -1)
                            if (isPlaceFreeForEnemy(PositionX + 1, PositionY, player, enemyList)) Move(1, 0);
                        if (distanceY > 0)
                            if (isPlaceFreeForEnemy(PositionX + 1, PositionY, player, enemyList)) Move(1, 0);
                    }
                    if (distanceX > 1)
                    {
                        if (distanceY == 0)
                            if (isPlaceFreeForEnemy(PositionX - 1, PositionY + 1, player, enemyList)) Move(-1, 1);
                        if (distanceY <= -1)
                            if (isPlaceFreeForEnemy(PositionX - 1, PositionY, player, enemyList)) Move(-1, 0);
                        if (distanceY > 0)
                            if (isPlaceFreeForEnemy(PositionX - 1, PositionY, player, enemyList)) Move(-1, 0);
                    }

                    if (distanceX == -1 || distanceX == 0 || distanceX == 1)
                    {
                        if (distanceY == 0)
                            player.PlayerKilled();
                        if (distanceY == -1 || distanceY == 1 || distanceY == 0)
                            player.PlayerKilled();
                        if (distanceY > 1)
                            if (isPlaceFreeForEnemy(PositionX - 1, PositionY - 1, player, enemyList)) Move(-1, -1);
                        if (distanceY < -1)
                            if (isPlaceFreeForEnemy(PositionX - 1, PositionY + 1, player, enemyList)) Move(-1, 1);

                    }
                }

            }*/
    }
}
