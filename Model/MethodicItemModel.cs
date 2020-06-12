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
        public string memo { get; set; }

        public int humanModelId { get; set; }

        public int methodicId{ get; set; }

        public string humanModelName { get; set; }

        public MethodicItemModel(int methodicId, string name, string memo, int humanModelId, string humanModelName)
        {
            this.name = name;
            this.memo = memo;
            this.humanModelName = humanModelName;
            this.humanModelId = humanModelId;
            this.methodicId = methodicId;
        }

        public MethodicItemModel()
        {
        }
    }
}
