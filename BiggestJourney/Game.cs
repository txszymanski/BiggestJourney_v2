using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggestJourney
{
    static class Game
    {

        public static List<NonMovingObject> nonMovingObjectList = new List<NonMovingObject>();
        public static List<MovingObject> movingObjectList = new List<MovingObject>();
        public static List<IObjects> objectList = new List<IObjects>();
        public static List<Enemy> enemyList = new List<Enemy>();
    }
}
