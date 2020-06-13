using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantium
{
    class PointModel
    {
        public int id_point { get; set; }
        public int id_human_model { get; set; }
        public int id_methodic { get; set; }
        public string pointname { get; set; }
        public string side { get; set; }
        public int channel { get; set; }
        public int coordX { get; set; }
        public int coordY { get; set; }
        public int time { get; set; }
        public int power { get; set; }

        public PointModel()
        {
        }

        public PointModel(int coordX, int coordY, int channel, int time, int power,string side, string pointname,  int id_point, int id_human_model, int id_methodic)
        {
            this.coordX = coordX;
            this.coordY = coordY;
            this.pointname = pointname;
            this.channel = channel;
            this.side = side;
            this.id_point = id_point;
            this.id_human_model = id_human_model;
            this.time = time;
            this.power = power;
            this.id_methodic = id_methodic;
        }
    }
}
