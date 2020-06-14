using System;

namespace Quantium
{
    partial class FormAddPoint
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

        public void SetPointData(int x, int y, string side)
        {
            this.textBoxPointX.Text = x.ToString();
            this.textBoxPointY.Text = y.ToString();

            if (side == FormMain.SIDE_FRONT) this.comboBoxPointSide.SelectedIndex = 0; else this.comboBoxPointSide.SelectedIndex = 1;
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPointX = new System.Windows.Forms.TextBox();
            this.textBoxPointY = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxPointSide = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPointLink = new System.Windows.Forms.ComboBox();
            this.textBoxPointName = new System.Windows.Forms.TextBox();
            this.btnConfirm = new Quantium.RoundButton();
            this.btnCancel = new Quantium.RoundButton();
            this.buttonOk = new Quantium.RoundButton();
            this.roundButton1 = new Quantium.RoundButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(92, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "X=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Y=";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(11, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Название точки:";
            // 
            // textBoxPointX
            // 
            this.textBoxPointX.Enabled = false;
            this.textBoxPointX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPointX.Location = new System.Drawing.Point(38, 37);
            this.textBoxPointX.Name = "textBoxPointX";
            this.textBoxPointX.Size = new System.Drawing.Size(45, 21);
            this.textBoxPointX.TabIndex = 4;
            // 
            // textBoxPointY
            // 
            this.textBoxPointY.Enabled = false;
            this.textBoxPointY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPointY.Location = new System.Drawing.Point(120, 37);
            this.textBoxPointY.Name = "textBoxPointY";
            this.textBoxPointY.Size = new System.Drawing.Size(49, 21);
            this.textBoxPointY.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPointY);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxPointX);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxPointSide);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(31, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 64);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Координаты точки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(203, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Размещение:";
            // 
            // comboBoxPointSide
            // 
            this.comboBoxPointSide.Enabled = false;
            this.comboBoxPointSide.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxPointSide.FormattingEnabled = true;
            this.comboBoxPointSide.Items.AddRange(new object[] {
            "Front",
            "Back"});
            this.comboBoxPointSide.Location = new System.Drawing.Point(206, 35);
            this.comboBoxPointSide.Name = "comboBoxPointSide";
            this.comboBoxPointSide.Size = new System.Drawing.Size(78, 23);
            this.comboBoxPointSide.TabIndex = 10;
            this.comboBoxPointSide.Text = "Front";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(183, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Привязка точки";
            // 
            // cbPointLink
            // 
            this.cbPointLink.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbPointLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPointLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPointLink.FormattingEnabled = true;
            this.cbPointLink.Items.AddRange(new object[] {
            "Channel 1",
            "Channel 2",
            "Channel 3",
            "Channel 4",
            "Channel 5",
            "Channel 6",
            "Channel 7",
            "Channel 8",
            "Channel 9",
            "Channel 10"});
            this.cbPointLink.Location = new System.Drawing.Point(186, 84);
            this.cbPointLink.Name = "cbPointLink";
            this.cbPointLink.Size = new System.Drawing.Size(161, 23);
            this.cbPointLink.TabIndex = 9;
            this.cbPointLink.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbPointLink_DrawItem);
            this.cbPointLink.SelectedValueChanged += new System.EventHandler(this.cbPointLink_SelectedValueChanged);
            // 
            // textBoxPointName
            // 
            this.textBoxPointName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPointName.Location = new System.Drawing.Point(12, 85);
            this.textBoxPointName.Name = "textBoxPointName";
            this.textBoxPointName.Size = new System.Drawing.Size(163, 22);
            this.textBoxPointName.TabIndex = 12;
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor2 = System.Drawing.Color.Empty;
            this.btnConfirm.ButtonBorderColor = System.Drawing.Color.Empty;
            this.btnConfirm.ButtonHighlightColor = System.Drawing.Color.Empty;
            this.btnConfirm.ButtonHighlightColor2 = System.Drawing.Color.Empty;
            this.btnConfirm.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnConfirm.ButtonPressedColor = System.Drawing.Color.Empty;
            this.btnConfirm.ButtonPressedColor2 = System.Drawing.Color.Empty;
            this.btnConfirm.ButtonPressedForeColor = System.Drawing.Color.Empty;
            this.btnConfirm.ButtonRoundRadius = 0;
            this.btnConfirm.Location = new System.Drawing.Point(0, 0);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(0, 0);
            this.btnConfirm.TabIndex = 33;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.BackColor2 = System.Drawing.Color.Empty;
            this.btnCancel.ButtonBorderColor = System.Drawing.Color.Empty;
            this.btnCancel.ButtonHighlightColor = System.Drawing.Color.Empty;
            this.btnCancel.ButtonHighlightColor2 = System.Drawing.Color.Empty;
            this.btnCancel.ButtonHighlightForeColor = System.Drawing.Color.Empty;
            this.btnCancel.ButtonPressedColor = System.Drawing.Color.Empty;
            this.btnCancel.ButtonPressedColor2 = System.Drawing.Color.Empty;
            this.btnCancel.ButtonPressedForeColor = System.Drawing.Color.Empty;
            this.btnCancel.ButtonRoundRadius = 0;
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(0, 0);
            this.btnCancel.TabIndex = 32;
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
            this.buttonOk.Location = new System.Drawing.Point(91, 132);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(84, 21);
            this.buttonOk.TabIndex = 31;
            this.buttonOk.Text = "Сохранить";
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
            this.roundButton1.Location = new System.Drawing.Point(186, 132);
            this.roundButton1.Name = "roundButton1";
            this.roundButton1.Size = new System.Drawing.Size(84, 21);
            this.roundButton1.TabIndex = 34;
            this.roundButton1.Text = "Отмена";
            this.roundButton1.Click += new System.EventHandler(this.roundButton1_Click);
            // 
            // FormAddPoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 165);
            this.ControlBox = false;
            this.Controls.Add(this.roundButton1);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.textBoxPointName);
            this.Controls.Add(this.cbPointLink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить точку в базу";
            this.Load += new System.EventHandler(this.FormAddPoint_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPointX;
        private System.Windows.Forms.TextBox textBoxPointY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPointLink;
        private System.Windows.Forms.ComboBox comboBoxPointSide;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPointName;
        private Quantium.RoundButton btnConfirm;
        private Quantium.RoundButton btnCancel;
        private RoundButton buttonOk;
        private RoundButton roundButton1;
    }
}