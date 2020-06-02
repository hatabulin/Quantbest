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
        Form1 form;
        int x, y;
        String humanSide;

        public FormAddPoint(Form1 form, int x, int y,String humanSide)
        {
            this.form = form;
            this.x = x;
            this.y = y;
            this.humanSide = humanSide;

            InitializeComponent();
            comboBoxPointLink.SelectedIndex = 0;
            setCoord(x, y, humanSide);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPointToTable();
            form.DrawPoint(x,y,humanSide);
            
            this.Close();
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
