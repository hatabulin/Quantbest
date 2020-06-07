using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantium
{
    class PointModel
    {
        public PointModel()
        {
        }

        public PointModel(int coordX, int coordY, int channel, string side, string pointname,  int id)
        {
            this.coordX = coordX;
            this.coordY = coordY;
            this.pointname = pointname;
            this.channel = channel;
            this.side = side;
            this.id = id;
        }

        public int id { get; set; }
        public string pointname { get; set; }
        public string side { get; set; }
        public int channel { get; set; }
        public int coordX { get; set; }
        public int coordY { get; set; }
    }
}
