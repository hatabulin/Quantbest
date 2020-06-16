using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quantium.Views
{
    public partial class FormAddHumanModel : Form
    {
        HumanModel _humanFilesModel = new HumanModel();

        //public FormAddHumanModel(object humanFilesModel)
        public FormAddHumanModel()
        {
//            _humanFilesModel = (HumanFilesModel)humanFilesModel;
            InitializeComponent();
        }

        private void FormAddHumanModel_Load(object sender, EventArgs e)
        {
/*
            btnOpenMapFront.Parent = tbMapFrontFileName;
            btnOpenMapFront.Dock = DockStyle.Right;
            btnOpenMapFront.BringToFront();
            tbMapFrontFileName.Controls.Add(btnOpenMapFront);

            btnOpenHumanModelFront.Parent = tbHumanFrontFileName;
            btnOpenHumanModelFront.Dock = DockStyle.Right;
            btnOpenHumanModelFront.BringToFront();
            tbHumanFrontFileName.Controls.Add(btnOpenHumanModelFront);
  */
        }

        private void btnOpenMapFront_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                _humanFilesModel.mapFrontPath = openFileDialog1.FileName;
                tbMapFrontFileName.Text = openFileDialog1.SafeFileName;
                CheckAllFields();
            }
            else
            {
                MessageBox.Show("Файл не выбран :(");
            }
        }
        private void btnOpenHumanModelFront_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                _humanFilesModel.bodyFrontPath = openFileDialog1.FileName;
                tbHumanFrontFileName.Text = openFileDialog1.SafeFileName;
                CheckAllFields();
                //                pictureBox1.Image = new Bitmap(humanModelFrontFileName);
            }
            else
            {
                MessageBox.Show("Файл не выбран :(");
            }
        }

        private void btnOpenMapBack_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                _humanFilesModel.mapBackPath= openFileDialog1.FileName;
                tbMapBackFileName.Text = openFileDialog1.SafeFileName;
                CheckAllFields();
            }
            else
            {
                MessageBox.Show("Файл не выбран :(");
            }
        }

        private void btnOpenHumanModelBack_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                _humanFilesModel.bodyBackPath = openFileDialog1.FileName;
                tbHumanBackFileName.Text = openFileDialog1.SafeFileName;
                CheckAllFields();
                //                pictureBox2.Image = new Bitmap(humanModelBackFileName);
            }
            else
            {
                MessageBox.Show("Файл не выбран :(");
            }
        }

        private void CheckAllFields()
        {
            if (tbName.Text != "" && tbHumanBackFileName.Text != "" && tbHumanFrontFileName.Text != "" && tbMapBackFileName.Text != "" && tbMapFrontFileName.Text != "")
                if (roundButton1.Enabled != true) roundButton1.Enabled = true; else if (roundButton1.Enabled != false) roundButton1.Enabled = false;
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            CheckAllFields();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            _humanFilesModel.name = tbName.Text;
            DataAccess.AddToHumanModelList(_humanFilesModel);
            Close();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
