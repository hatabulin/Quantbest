using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quantium
{
    public partial class FormEnterMethodic : Form
    {
        public FormEnterMethodic()
        {
            InitializeComponent();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DataAccess.AddMethodicName(textBox1.Text, richTextBox1.Text);
            this.Close();
        }
    }
}
