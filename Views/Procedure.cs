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
    public partial class Procedure : Form
    {
        List<HumanModel> humanModels = new List<HumanModel>();
        public Procedure()
        {
            InitializeComponent();
            DateTime dt = DateTime.Now;
            data.Text = dt.ToString(("MM.dd.yyyy"));
            string dt2;
            dt2 = dt.ToString("MM.dd.yyyy HH:mm");
            dt2 = dt2.Substring(11,dt2.Length-11); // Оставляем только время
            time1.Text = dt2;
            
            if (cbHumanModels.Enabled != false) cbHumanModels.Enabled = false;
            DataAccess.GetHumanModelsList(humanModels);
            if (humanModels.Count > 0)
            {
                cbHumanModels.Items.Clear();
                for (int i = 0; i < humanModels.Count; i++)
                {
                    cbHumanModels.Items.Add(humanModels[i].name);
                }
                cbHumanModels.Enabled = true;
            }

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // DataAccess.AddToMethodicList(textBox1.Text, richTextBox1.Text, humanModels[cbHumanModels.SelectedIndex].id_human_model);
            string familia = surname.Text;
            Boolean isexistSurname;
            isexistSurname = DataAccess.isUserExists(surname.Text, name.Text);
            if  (isexistSurname=true)
             {
                MessageBox.Show("Этот клиент " + surname.Text  + " " +name.Text + " и процедура " + textBox10.Text+   "уже есть введите другую N процедуры");

            }

            else
            {
                DataAccess.AddProcedureForMan(surname.Text, name.Text, oxy1.Text, richTextBox1.Text, humanModels[cbHumanModels.SelectedIndex].id_human_model);
                this.Close();
            }
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void btnAddMethodic_Click(object sender, EventArgs e)
        {
            Procedure formProcedure = new Procedure();
            formProcedure.ShowDialog();
            formProcedure.Dispose();
            // UpdateMethodicViews(0, true);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cbHumanModels_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void surname_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
