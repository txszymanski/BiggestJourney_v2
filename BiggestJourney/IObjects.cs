using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BiggestJourney
{
    interface IObjects
    {
        int PositionX { get; set; }
        int PositionY { get; set; }
        Image ObjectImage { get; set; }
        void updatePosition();
    }
}
