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
        List<int> listPointsId = new List<int>();
        List<PointModel> pointModels = new List<PointModel>();

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
//            DataAccess.PointsListId(listPointsId);
//            DataAccess.ReadPointsTable(pointModels);
            if (pointModels.Count>0)
            {
                for (int i=0;i< pointModels.Count;i++)
                {
                    comboBox1.Items.Add(pointModels[i].pointname);
                }
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            pointid = listPointsId[comboBox1.SelectedIndex];
//            DataAccess.AddPointToHumanTable(methodicId, pointid,Convert.ToInt32(nudTime.Value), Convert.ToInt32(nudPower.Value));
            this.Close();
        }
    }
}
