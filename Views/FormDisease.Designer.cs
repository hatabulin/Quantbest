namespace Quantium
{
    partial class FormDisease
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
            this.roundButton1 = new Quantium.RoundButton();
            this.buttonOk = new Quantium.RoundButton();
            this.label27 = new System.Windows.Forms.Label();
            this.cbDisease = new System.Windows.Forms.ComboBox();
            this.btnAddDisease = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.Gray;
            this.roundButton1.BackColor2 = System.Drawing.Color.LightGray;
            this.roundButton1.ButtonBorderColor = System.Drawing.Color.Black;
            this.roundButton1.ButtonHighlightColor = System.Drawing.Color.Orange;
            this.roundButton1.ButtonHighlightColor2 = System.Drawing.Color.OrangeRed;
            this.roundButton1.ButtonHighlightForeColor = System.Drawing.Color.Black;
            this.roundButton1.ButtonPressedColor = System.Drawing.Color.Red;
            this.roundButton1.ButtonPressedColor2 = System.Drawing.Color.Maroon;
            this.roundButton1.ButtonPressedForeColor = System.Drawing.Color.White;
            this.roundButton1.ButtonRoundRadius = 10;
            this.roundButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roundButton1.ForeColor = System.Drawing.Color.Blue;
            this.roundButton1.Location = new System.Drawing.Point(135, 80);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(84, 20);
            this.roundButton1.TabIndex = 35;
            this.roundButton1.Text = "Отмена";
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.Gray;
            this.buttonOk.BackColor2 = System.Drawing.Color.LightGray;
            this.buttonOk.ButtonBorderColor = System.Drawing.Color.Black;
            this.buttonOk.ButtonHighlightColor = System.Drawing.Color.Orange;
            this.buttonOk.ButtonHighlightColor2 = System.Drawing.Color.OrangeRed;
            this.buttonOk.ButtonHighlightForeColor = System.Drawing.Color.Black;
            this.buttonOk.ButtonPressedColor = System.Drawing.Color.Red;
            this.buttonOk.ButtonPressedColor2 = System.Drawing.Color.Maroon;
            this.buttonOk.ButtonPressedForeColor = System.Drawing.Color.White;
            this.buttonOk.ButtonRoundRadius = 10;
            this.buttonOk.Enabled = false;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.ForeColor = System.Drawing.Color.Blue;
            this.buttonOk.Location = new System.Drawing.Point(45, 80);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(84, 20);
            this.buttonOk.TabIndex = 34;
            this.buttonOk.Text = "Выбрать";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(12, 11);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(146, 21);
            this.label27.TabIndex = 32;
            this.label27.Text = "Название Болезни:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbDisease
            // 
            this.cbDisease.Enabled = false;
            this.cbDisease.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbDisease.FormattingEnabled = true;
            this.cbDisease.Location = new System.Drawing.Point(12, 35);
            this.cbDisease.Name = "cbDisease";
            this.cbDisease.Size = new System.Drawing.Size(212, 24);
            this.cbDisease.TabIndex = 36;
            // 
            // btnAddDisease
            // 
            this.btnAddDisease.BackgroundImage = global::Quantium.Properties.Resources.ic_add;
            this.btnAddDisease.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddDisease.Location = new System.Drawing.Point(230, 35);
            this.btnAddDisease.Name = "btnAddDisease";
            this.btnAddDisease.Size = new System.Drawing.Size(23, 23);
            this.btnAddDisease.TabIndex = 40;
            this.btnAddDisease.UseVisualStyleBackColor = true;
            this.btnAddDisease.Click += new System.EventHandler(this.btnAddDisease_Click);
            // 
            // FormDisease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(261, 112);
            this.ControlBox = false;
            this.Controls.Add(this.btnAddDisease);
            this.Controls.Add(this.cbDisease);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label27);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FormDisease";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создать болезнь";
            this.ResumeLayout(false);

        }

        #endregion

        private RoundButton roundButton1;
        private RoundButton buttonOk;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cbDisease;
        private System.Windows.Forms.Button btnAddDisease;
    }
}