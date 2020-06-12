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
    public partial class FormAddPoint : Form
    {
        FormMain _form;
        int x, y;
        String _humanSide;
        int _humanModelId;

        public FormAddPoint(FormMain form, int humanModelId, int x, int y,String humanSide)
        {
            _form = form;
            this.x = x;
            this.y = y;
            _humanSide = humanSide;
            _humanModelId = humanModelId;

            InitializeComponent();
            comboBoxPointLink.SelectedIndex = 0;
            SetPointData(x, y, humanSide);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPointToTable();
            _form.DrawPoint(x,y,_humanSide);
            
            this.Close();
        }

        public void AddPointToTable()
        {
            PointModel pointModel = new PointModel(
                Convert.ToInt16(textBoxPointX.Text),
                Convert.ToInt16(textBoxPointY.Text),
                comboBoxPointLink.SelectedIndex,
                comboBoxPointSide.Text,
                textBoxPointName.Text,
                0,_humanModelId);
            DataAccess.AddToHumanPointsTable(pointModel);
        }

        private void FormAddPoint_Load(object sender, EventArgs e)
        {
            this.Region = new Region(
            CustomFormClass.RoundedRect(
            new Rectangle(0, 0, this.Width, this.Height)
                    , 10
                )
            );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
