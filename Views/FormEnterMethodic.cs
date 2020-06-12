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
        List<HumanModel> humanModels = new List<HumanModel>();

        public FormEnterMethodic()
        {
            InitializeComponent();

            if (cbHumanModels.Enabled != false) cbHumanModels.Enabled = false;
            DataAccess.GetHumanModelsList(humanModels);
            if (humanModels.Count>0)
            {
                cbHumanModels.Items.Clear();
                for (int i=0;i< humanModels.Count;i++)
                {
                    cbHumanModels.Items.Add(humanModels[i].name);
                }
                cbHumanModels.Enabled = true;
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DataAccess.AddToMethodicList(textBox1.Text, richTextBox1.Text, humanModels[cbHumanModels.SelectedIndex].id_human_model);
            this.Close();
        }
    }
}
