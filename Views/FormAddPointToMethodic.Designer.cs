namespace Quantium
{
    partial class FormAddPointToMethodic
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.roundButton1 = new Quantium.RoundButton();
            this.buttonOk = new Quantium.RoundButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudPower = new System.Windows.Forms.NumericUpDown();
            this.nudTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(33, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(242, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(80, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Выберите точку";
            // 
            // roundButton1
            // 
            this.roundButton1.BackColor = System.Drawing.Color.Teal;
            this.roundButton1.BackColor2 = System.Drawing.Color.Silver;
            this.roundButton1.ButtonBorderColor = System.Drawing.Color.Black;
            this.roundButton1.ButtonHighlightColor = System.Drawing.Color.Orange;
            this.roundButton1.ButtonHighlightColor2 = System.Drawing.Color.OrangeRed;
            this.roundButton1.ButtonHighlightForeColor = System.Drawing.Color.Black;
            this.roundButton1.ButtonPressedColor = System.Drawing.Color.Red;
            this.roundButton1.ButtonPressedColor2 = System.Drawing.Color.Maroon;
            this.roundButton1.ButtonPressedForeColor = System.Drawing.Color.White;
            this.roundButton1.ButtonRoundRadius = 10;
            this.roundButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.roundButton1.ForeColor = System.Drawing.Color.Yellow;
            this.roundButton1.Location = new System.Drawing.Point(150, 121);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(84, 21);
            this.roundButton1.TabIndex = 33;
            this.roundButton1.Text = "Отмена";
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.Teal;
            this.buttonOk.BackColor2 = System.Drawing.Color.Silver;
            this.buttonOk.ButtonBorderColor = System.Drawing.Color.Black;
            this.buttonOk.ButtonHighlightColor = System.Drawing.Color.Orange;
            this.buttonOk.ButtonHighlightColor2 = System.Drawing.Color.OrangeRed;
            this.buttonOk.ButtonHighlightForeColor = System.Drawing.Color.Black;
            this.buttonOk.ButtonPressedColor = System.Drawing.Color.Red;
            this.buttonOk.ButtonPressedColor2 = System.Drawing.Color.Maroon;
            this.buttonOk.ButtonPressedForeColor = System.Drawing.Color.White;
            this.buttonOk.ButtonRoundRadius = 10;
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.ForeColor = System.Drawing.Color.Yellow;
            this.buttonOk.Location = new System.Drawing.Point(51, 121);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(84, 21);
            this.buttonOk.TabIndex = 32;
            this.buttonOk.Text = "Сохранить";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(139, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 37;
            this.label7.Text = "Мощность";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Время";
            // 
            // nudPower
            // 
            this.nudPower.Location = new System.Drawing.Point(226, 79);
            this.nudPower.Name = "nudPower";
            this.nudPower.Size = new System.Drawing.Size(60, 20);
            this.nudPower.TabIndex = 35;
            // 
            // nudTime
            // 
            this.nudTime.Location = new System.Drawing.Point(72, 79);
            this.nudTime.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudTime.Name = "nudTime";
            this.nudTime.Size = new System.Drawing.Size(60, 20);
            this.nudTime.TabIndex = 34;
            // 
            // FormAddPointToMethodic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 154);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudPower);
            this.Controls.Add(this.nudTime);
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAddPointToMethodic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление точки в методику";
            this.Activated += new System.EventHandler(this.FormAddPointToMethodic_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.nudPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private RoundButton roundButton1;
        private RoundButton buttonOk;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudPower;
        private System.Windows.Forms.NumericUpDown nudTime;
    }
}