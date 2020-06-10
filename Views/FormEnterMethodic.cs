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
        private String meredianFrontFileName;
        private String meredianBackFileName;
        private String humanModelFrontFileName;
        private String humanModelBackFileName;

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
            DataAccess.AddNewMethodic(textBox1.Text, richTextBox1.Text,meredianFrontFileName, meredianBackFileName, humanModelFrontFileName, humanModelBackFileName);
            this.Close();
        }

        public void setFileNames(String meredianFrontFileName, String meredianBackFileName, String humanModelFrontFileName, String humanModelBackFileName)
        {
            this.meredianFrontFileName = meredianFrontFileName;
            this.meredianBackFileName = meredianBackFileName;
            this.humanModelFrontFileName = humanModelFrontFileName;
            this.humanModelBackFileName = humanModelBackFileName;
        }
    }
}
