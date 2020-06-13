using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantium.Model
{
    class MethodicModel
    {
        public string methodicName { get; set; }
        public string pointName { get; set; }
        public int pointX { get; set; }
        public int pointY { get; set; }
        public int channel { get; set; }
        public string side { get; set; }
        public int pointId { get; set; }
        public int pointTime { get; set; }
        public int pointPower { get; set; }
        public int humanModelId { get; set; }
        public int methodicId { get; set; }

        public MethodicModel()
        {
        }

        public MethodicModel(string methodicName, string pointName, int pointX, int pointY, int channel, string side, int pointId, int pointTime, int pointPower, int humanModelId, int methodicId)
        {
            this.methodicName = methodicName;
            this.pointName = pointName;
            this.pointX = pointX;
            this.pointY = pointY;
            this.channel = channel;
            this.side = side;
            this.pointId = pointId;
            this.pointTime = pointTime;
            this.pointPower = pointPower;
            this.humanModelId = humanModelId;
            this.methodicId = methodicId;
        }
    }
}
