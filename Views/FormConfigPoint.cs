using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quantium.Views
{
    public partial class FormConfigPoint : Form
    {
        private PointModel pointModel = new PointModel();

        public FormConfigPoint(object pointModel)
        {
            this.pointModel = (PointModel) pointModel;
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            pointModel.time = Convert.ToInt32(tbTime.Text);
            pointModel.power= Convert.ToInt32(tbPower.Text);
            DataAccess.AddToMainPointsTable(pointModel);
            Close();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
