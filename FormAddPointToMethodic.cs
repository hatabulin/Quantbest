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
    public partial class FormAddPointToMethodic : Form
    {
        int methodicId;
        int pointid;
        public FormAddPointToMethodic(int methodicId)
        {
            this.methodicId  = methodicId;
            InitializeComponent();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAddPointToMethodic_Activated(object sender, EventArgs e)
        {
            DataAccess.PointsList(comboBox1);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            pointid = comboBox1.SelectedIndex + 1;
            //DataAccess.AddPointToMethodic(methodicName,pointid);
            DataAccess.AddPointToMethodic(methodicId, pointid);
            this.Close();
        }
    }
}
