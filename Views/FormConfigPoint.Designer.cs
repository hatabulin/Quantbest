namespace Quantium.Views
{
    partial class FormConfigPoint
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
            this.tbTime = new System.Windows.Forms.TextBox();
            this.tbPower = new System.Windows.Forms.TextBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new Quantium.RoundButton();
            this.roundButton1 = new Quantium.RoundButton();
            this.SuspendLayout();
            // 
            // tbTime
            // 
            this.tbTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbTime.Location = new System.Drawing.Point(91, 23);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(45, 21);
            this.tbTime.TabIndex = 5;
            // 
            // tbPower
            // 
            this.tbPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPower.Location = new System.Drawing.Point(91, 50);
            this.tbPower.Name = "tbPower";
            this.tbPower.Size = new System.Drawing.Size(45, 21);
            this.tbPower.TabIndex = 6;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTime.Location = new System.Drawing.Point(12, 23);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(52, 16);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "Время:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Мощность:";
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
            this.buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonOk.ForeColor = System.Drawing.Color.Blue;
            this.buttonOk.Location = new System.Drawing.Point(7, 92);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(73, 21);
            this.buttonOk.TabIndex = 32;
            this.buttonOk.Text = "Добавить";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
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
            this.roundButton1.Location = new System.Drawing.Point(86, 92);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(73, 21);
            this.roundButton1.TabIndex = 35;
            this.roundButton1.Text = "Отмена";
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // FormConfigPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(171, 130);
            this.ControlBox = false;
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.tbPower);
            this.Controls.Add(this.tbTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.Name = "FormConfigPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Конфигурация точки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.TextBox tbPower;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label1;
        private RoundButton buttonOk;
        private RoundButton roundButton1;
    }
}