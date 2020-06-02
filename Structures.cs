using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantium
{
    public struct DiseaseItem
    {
        public DiseaseItem(int channel, MeridianPoint meridianPoint)
        {
            myChannel = channel;
            myMeridianPoint = meridianPoint;
        }

        public int myChannel { get; }
        public MeridianPoint myMeridianPoint { get; }
    }

    public struct MeridianPoint
    {
        public MeridianPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }

        public override string ToString() => $"({X}, {Y})";
    }

    public struct LaserChannel
    {
        public LaserChannel(int levelPwm, decimal timeSeconds)
        {
            myLevelPwm = levelPwm;
            myTimeSeconds = timeSeconds;
        }
        public int myLevelPwm { get; set; }

        public decimal myTimeSeconds { get; set; }

    }

}
