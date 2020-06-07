using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantium.Model
{
    class MethodicItemModel
    {
        public string name { get; set; }
        public string memo{ get; set; }
        public string mapFrontFileName { get; set; }
        public string mapBackFileName { get; set; }
        public string humanModelFrontFileName { get; set; }
        public string humanModelBackFileName { get; set; }

        public MethodicItemModel(string name, string memo, string mapFrontFileName, string mapBackFileName, string humanModelFrontFileName, string humanModelBackFileName)
        {
            this.name = name;
            this.memo = memo;
            this.mapFrontFileName = mapFrontFileName;
            this.mapBackFileName = mapBackFileName;
            this.humanModelFrontFileName = humanModelFrontFileName;
            this.humanModelBackFileName = humanModelBackFileName;
        }

        public MethodicItemModel()
        {
        }
    }
}
