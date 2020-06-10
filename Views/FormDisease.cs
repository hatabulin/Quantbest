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
    public partial class FormDisease : Form
    {
        public FormDisease(int methodicId)
        {
            InitializeComponent();
        }

        private void btnAddDisease_Click(object sender, EventArgs e)
        {

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DataAccess.AddDisease(cbDisease.Text);
        }
    }
}
