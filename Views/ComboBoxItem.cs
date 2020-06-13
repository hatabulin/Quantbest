using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quantium.Views
{
/*    class ComboBoxItem
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public bool Selectable { get; set; }
    }
    */
    class ComboBoxItem
    {
        public string Text;
        public ComboBoxItem(string text)
        {
            this.Text = text;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
