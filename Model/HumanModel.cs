using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantium
{
    class HumanModel
    {
        public HumanModel()
        {
        }

        public HumanModel(int id_human_model, string name, string mapFrontPath, string mapBackPath, string bodyFrontPath, string bodyBackPath)
        {
            this.id_human_model = id_human_model;
            this.name = name;
            this.mapFrontPath = mapFrontPath;
            this.mapBackPath = mapBackPath;
            this.bodyFrontPath = bodyFrontPath;
            this.bodyBackPath = bodyBackPath;
        }

        public int id_human_model { get; set; }
        public string name { get; set; }
        public string mapFrontPath { get; set; }
        public string mapBackPath { get; set; }
        public string bodyFrontPath { get; set; }
        public string bodyBackPath { get; set; }
    }
}
