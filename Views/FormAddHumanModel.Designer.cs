namespace Quantium.Views
{
    partial class FormAddHumanModel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbHumanBackFileName = new System.Windows.Forms.TextBox();
            this.tbMapBackFileName = new System.Windows.Forms.TextBox();
            this.tbHumanFrontFileName = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tbMapFrontFileName = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnOpenHumanModelBack = new System.Windows.Forms.Button();
            this.btnOpenMapBack = new System.Windows.Forms.Button();
            this.btnOpenHumanModelFront = new System.Windows.Forms.Button();
            this.btnOpenMapFront = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // tbHumanBackFileName
            // 
            this.tbHumanBackFileName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbHumanBackFileName.Enabled = false;
            this.tbHumanBackFileName.Location = new System.Drawing.Point(12, 260);
            this.tbHumanBackFileName.Name = "tbHumanBackFileName";
            this.tbHumanBackFileName.Size = new System.Drawing.Size(281, 20);
            this.tbHumanBackFileName.TabIndex = 52;
            // 
            // tbMapBackFileName
            // 
            this.tbMapBackFileName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbMapBackFileName.Enabled = false;
            this.tbMapBackFileName.Location = new System.Drawing.Point(12, 217);
            this.tbMapBackFileName.Name = "tbMapBackFileName";
            this.tbMapBackFileName.Size = new System.Drawing.Size(281, 20);
            this.tbMapBackFileName.TabIndex = 51;
            // 
            // tbHumanFrontFileName
            // 
            this.tbHumanFrontFileName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbHumanFrontFileName.Enabled = false;
            this.tbHumanFrontFileName.Location = new System.Drawing.Point(12, 174);
            this.tbHumanFrontFileName.Name = "tbHumanFrontFileName";
            this.tbHumanFrontFileName.Size = new System.Drawing.Size(281, 20);
            this.tbHumanFrontFileName.TabIndex = 49;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(12, 242);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(133, 15);
            this.label33.TabIndex = 50;
            this.label33.Text = "Файл задней модели:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMapFrontFileName
            // 
            this.tbMapFrontFileName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbMapFrontFileName.Enabled = false;
            this.tbMapFrontFileName.Location = new System.Drawing.Point(15, 131);
            this.tbMapFrontFileName.Name = "tbMapFrontFileName";
            this.tbMapFrontFileName.Size = new System.Drawing.Size(278, 20);
            this.tbMapFrontFileName.TabIndex = 46;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(12, 199);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(200, 15);
            this.label24.TabIndex = 47;
            this.label24.Text = "Файл задней карты мередианов:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(12, 156);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(230, 15);
            this.label32.TabIndex = 48;
            this.label32.Text = "Файл фронтальной модели человека:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(12, 113);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(240, 15);
            this.label21.TabIndex = 45;
            this.label21.Text = "Файл фронтальной карты мередианов:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOpenHumanModelBack
            // 
            this.btnOpenHumanModelBack.BackgroundImage = global::Quantium.Properties.Resources.open_folder;
            this.btnOpenHumanModelBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenHumanModelBack.Location = new System.Drawing.Point(299, 260);
            this.btnOpenHumanModelBack.Name = "btnOpenHumanModelBack";
            this.btnOpenHumanModelBack.Size = new System.Drawing.Size(26, 25);
            this.btnOpenHumanModelBack.TabIndex = 56;
            this.btnOpenHumanModelBack.UseVisualStyleBackColor = true;
            this.btnOpenHumanModelBack.Click += new System.EventHandler(this.btnOpenHumanModelBack_Click);
            // 
            // btnOpenMapBack
            // 
            this.btnOpenMapBack.BackgroundImage = global::Quantium.Properties.Resources.open_folder;
            this.btnOpenMapBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenMapBack.Location = new System.Drawing.Point(299, 214);
            this.btnOpenMapBack.Name = "btnOpenMapBack";
            this.btnOpenMapBack.Size = new System.Drawing.Size(26, 25);
            this.btnOpenMapBack.TabIndex = 54;
            this.btnOpenMapBack.UseVisualStyleBackColor = true;
            this.btnOpenMapBack.Click += new System.EventHandler(this.btnOpenMapBack_Click);
            // 
            // btnOpenHumanModelFront
            // 
            this.btnOpenHumanModelFront.BackgroundImage = global::Quantium.Properties.Resources.open_folder;
            this.btnOpenHumanModelFront.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenHumanModelFront.Location = new System.Drawing.Point(299, 171);
            this.btnOpenHumanModelFront.Name = "btnOpenHumanModelFront";
            this.btnOpenHumanModelFront.Size = new System.Drawing.Size(25, 25);
            this.btnOpenHumanModelFront.TabIndex = 55;
            this.btnOpenHumanModelFront.UseVisualStyleBackColor = true;
            this.btnOpenHumanModelFront.Click += new System.EventHandler(this.btnOpenHumanModelFront_Click);
            // 
            // btnOpenMapFront
            // 
            this.btnOpenMapFront.BackgroundImage = global::Quantium.Properties.Resources.open_folder;
            this.btnOpenMapFront.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenMapFront.Location = new System.Drawing.Point(299, 128);
            this.btnOpenMapFront.Name = "btnOpenMapFront";
            this.btnOpenMapFront.Size = new System.Drawing.Size(25, 25);
            this.btnOpenMapFront.TabIndex = 53;
            this.btnOpenMapFront.UseVisualStyleBackColor = true;
            this.btnOpenMapFront.Click += new System.EventHandler(this.btnOpenMapFront_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 16);
            this.label4.TabIndex = 57;
            this.label4.Text = "Введите название модели:";
            // 
            // tbName
            // 
            this.tbName.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tbName.Location = new System.Drawing.Point(15, 60);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(278, 20);
            this.tbName.TabIndex = 58;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            this.tbName.Leave += new System.EventHandler(this.tbName_Leave);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Enabled = false;
            this.btnConfirm.Location = new System.Drawing.Point(82, 304);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 59;
            this.btnConfirm.Text = "Сохранить";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(167, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 60;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Выберите файл мередианов";
            // 
            // FormAddHumanModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 338);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOpenHumanModelBack);
            this.Controls.Add(this.btnOpenMapBack);
            this.Controls.Add(this.btnOpenHumanModelFront);
            this.Controls.Add(this.btnOpenMapFront);
            this.Controls.Add(this.tbHumanBackFileName);
            this.Controls.Add(this.tbMapBackFileName);
            this.Controls.Add(this.tbHumanFrontFileName);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.tbMapFrontFileName);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "FormAddHumanModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление модели человека";
            this.Load += new System.EventHandler(this.FormAddHumanModel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbHumanBackFileName;
        private System.Windows.Forms.TextBox tbMapBackFileName;
        private System.Windows.Forms.TextBox tbHumanFrontFileName;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbMapFrontFileName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnOpenHumanModelBack;
        private System.Windows.Forms.Button btnOpenMapBack;
        private System.Windows.Forms.Button btnOpenHumanModelFront;
        private System.Windows.Forms.Button btnOpenMapFront;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}