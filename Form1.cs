using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Resources;
using Microsoft.Data.Sqlite;
using System.IO;
using PCLStorage;
using System.IO.Packaging;
using System.Data.SQLite;
using System.Configuration;
using Dapper;
using System.Linq;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Quantium
{
    public partial class Form1 : Form
    {
        private const String TEST_STRING_ON_ALL = "cfg:ch00=ff,ch01=ff,ch02:ff,ch03:ff,ch04:ff,ch05:ff,ch06:ff,ch07:ff,ch08:ff,ch09:ff";
        private const String TEST_STRING_OFF_ALL = "cfg:ch00=00,ch01=00,ch02=00,ch03=00,ch04=00,ch05=00,ch06=00,ch07=00,ch08=00,ch09=00";
        private const String TEXT_CONNECT = "OPEN";
        private const String TEXT_DISCONNECT = "CLOSE";
        private const int pointRadius = 10;
        
        private const int CHANNEL_0 = 0, CHANNEL_1 = 1, CHANNEL_2 = 2, CHANNEL_3 = 3, CHANNEL_4 = 4, CHANNEL_5 = 5, CHANNEL_6 = 6, CHANNEL_7 = 7, CHANNEL_8 = 8, CHANNEL_9 = 9;

        public const String SIDE_FRONT = "Front";
        public const String SIDE_BACK = "Back";

        static float currentAlphaValue = 0.45f;
        private string meredianFrontFileName, meredianBackFileName;
        private string humanModelFrontFileName, humanModelBackFileName;
        private readonly List<Brush> colorsBrush = new List<Brush> { Brushes.Red, Brushes.Green, Brushes.Yellow, Brushes.White, Brushes.Blue, Brushes.Black };
        private const byte RED = 0;
        private const byte GREEN = 1;
        private const byte YELLOW = 2;
        private const byte WHITE = 3;
        private const byte BLUE = 3;
        private const byte BLACK = 3;

        private string[] ports;

        private List<PointModel> pointModels = new List<PointModel>();
        ToolTip ttip = new ToolTip();

        public static LaserChannel[] laserChannel = { 
            new LaserChannel(0,10), new LaserChannel(100, 10), new LaserChannel(50, 10), new LaserChannel(255, 10), new LaserChannel(128, 10), 
            new LaserChannel(100, 10), new LaserChannel(10, 10), new LaserChannel(30, 10), new LaserChannel(40, 15), new LaserChannel(100, 20)};

        FormEnterMethodic formMethodic = new FormEnterMethodic();
        FormAddPointToMethodic formAddPointToMethodic;

        public Form1()
        {
            InitializeComponent();
            DataAccess.CreateTables();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            comboBoxComPort.Items.Clear();
            comboBoxComPort.Items.AddRange(SerialPort.GetPortNames());
            if (comboBoxComPort.Items.Count != 0)
            {
                ports = SerialPort.GetPortNames();
                comboBoxComPort.SelectedIndex = comboBoxComPort.Items.Count - 1;
                comboBoxDisease.SelectedIndex = 0;
                comboBoxDiseaseType.SelectedIndex = 0;
            }
            FillValuesToControls();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Region = new Region(
                CustomFormClass.RoundedRect(
                    new Rectangle(0, 0, this.Width, this.Height)
                    , 10
                )
            );
        }

        public void VisibleTablePointsEmpty(bool visible)
        {
            label31.Visible = visible;
        }
        void FillValuesToControls()
        {
            numericUpDownLaser1.Value = laserChannel[0].myLevelPwm;
            numericUpDownLaser2.Value = laserChannel[1].myLevelPwm;
            numericUpDownLaser3.Value = laserChannel[2].myLevelPwm;
            numericUpDownLaser4.Value = laserChannel[3].myLevelPwm;
            numericUpDownLaser5.Value = laserChannel[4].myLevelPwm;
            numericUpDownLaser6.Value = laserChannel[5].myLevelPwm;
            numericUpDownLaser7.Value = laserChannel[6].myLevelPwm;
            numericUpDownLaser8.Value = laserChannel[7].myLevelPwm;
            numericUpDownLaser9.Value = laserChannel[8].myLevelPwm;
            numericUpDownLaser10.Value = laserChannel[9].myLevelPwm;

            trackBarLaser1.Value = laserChannel[0].myLevelPwm;
            trackBarLaser2.Value = laserChannel[1].myLevelPwm;
            trackBarLaser3.Value = laserChannel[2].myLevelPwm;
            trackBarLaser4.Value = laserChannel[3].myLevelPwm;
            trackBarLaser5.Value = laserChannel[4].myLevelPwm;
            trackBarLaser6.Value = laserChannel[5].myLevelPwm;
            trackBarLaser7.Value = laserChannel[6].myLevelPwm;
            trackBarLaser8.Value = laserChannel[7].myLevelPwm;
            trackBarLaser9.Value = laserChannel[8].myLevelPwm;
            trackBarLaser10.Value = laserChannel[9].myLevelPwm;

            numericUpDownTime1.Value = laserChannel[0].myTimeSeconds;
            numericUpDownTime2.Value = laserChannel[1].myTimeSeconds;
            numericUpDownTime3.Value = laserChannel[2].myTimeSeconds;
            numericUpDownTime4.Value = laserChannel[3].myTimeSeconds;
            numericUpDownTime5.Value = laserChannel[4].myTimeSeconds;
            numericUpDownTime6.Value = laserChannel[5].myTimeSeconds;
            numericUpDownTime7.Value = laserChannel[6].myTimeSeconds;
            numericUpDownTime8.Value = laserChannel[7].myTimeSeconds;
            numericUpDownTime9.Value = laserChannel[8].myTimeSeconds;
            numericUpDownTime10.Value = laserChannel[9].myTimeSeconds;
        }

        private void SendValueToSerial(int channelNumber, int value)
        {
            string str = "cfg:ch" + channelNumber.ToString("X2") + "=" + value.ToString("X2");
            serialPort1.WriteLine(str);
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            if (buttonConnect.Text != TEXT_DISCONNECT)
            {
                if (comboBoxComPort.SelectedIndex > -1)
                {
                    try
                    {
                        serialPort1.PortName = ports[comboBoxComPort.SelectedIndex];
                        serialPort1.Open();
                        serialPort1.WriteLine(TEST_STRING_ON_ALL);
                        System.Threading.Thread.Sleep(100);
                        serialPort1.WriteLine(TEST_STRING_OFF_ALL);
                        groupBoxPwmPower.Enabled = true;
                        buttonConnect.Text = TEXT_DISCONNECT;
                    }
                    catch
                    {
                        serialPort1.Close();
                        MessageBox.Show("Port open error, or already opened !");
                    }
                }
            }
            else
            {
                try
                {
                    serialPort1.Close();
                    groupBoxPwmPower.Enabled = false;
                    buttonConnect.Text = TEXT_CONNECT;
                } 
                catch
                {
                    MessageBox.Show("Serial port error !");
                }
            }
        }
        private void checkBoxShowMapImages_CheckedChanged(object sender, EventArgs e)
        {
            Bitmap bitmap;
            if (checkBoxShowMapImages.Checked)
            {
                if (meredianFrontFileName != null && meredianBackFileName != null && humanModelFrontFileName != null && humanModelBackFileName != null)
                {
                    bitmap = AlphaBlending(new Bitmap(humanModelFrontFileName), new Bitmap(meredianFrontFileName), currentAlphaValue);
                    pictureBox1.Image = bitmap;

                    bitmap = AlphaBlending(new Bitmap(humanModelBackFileName), new Bitmap(meredianBackFileName), currentAlphaValue);
                    pictureBox2.Image = bitmap;

                    vScrollBar1.Enabled = true;
                }
                else
                {
                    checkBoxShowMapImages.Checked = false;
                    MessageBox.Show("Сначала выберите файлы !");
                }
            }
            else 
            { 
                if (humanModelFrontFileName!=null && humanModelBackFileName!=null)
                {
                    pictureBox1.Image = new Bitmap(humanModelFrontFileName);
                    pictureBox2.Image = new Bitmap(humanModelBackFileName);
                }
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Bitmap bitmap;
            if (checkBoxShowMapImages.Checked)
            {
                if (meredianFrontFileName != null && meredianBackFileName != null)
                {
                    currentAlphaValue = (float)(vScrollBar1.Minimum + vScrollBar1.Maximum - vScrollBar1.Value) / 100;
                    if (humanModelFrontFileName != null) bitmap = new Bitmap(humanModelFrontFileName);
                    else bitmap = new Bitmap(Properties.Resources.no_file);
                    bitmap = AlphaBlending(bitmap, new Bitmap(meredianFrontFileName), currentAlphaValue);
                    pictureBox1.Image = bitmap;

                    if (humanModelBackFileName != null) bitmap = new Bitmap(humanModelBackFileName);
                    else bitmap = new Bitmap(Properties.Resources.no_file);

                    bitmap = AlphaBlending(bitmap, new Bitmap(meredianBackFileName), currentAlphaValue);
                    pictureBox2.Image = bitmap;
                }
                else
                {
                    checkBoxShowMapImages.Checked = false;
                    MessageBox.Show("Сначала выберите файл !");
                }
            }
            else
            {
                if (humanModelFrontFileName != null && humanModelBackFileName != null)
                {
                    pictureBox1.Image = new Bitmap(humanModelFrontFileName);
                    pictureBox2.Image = new Bitmap(humanModelBackFileName);
                }
            }
        }

        private void tabPagePoints_Enter(object sender, EventArgs e)
        {
            DataAccess.ReadPointsTable(dataGridViewPoints, this, pointModels);
            DrawHumanPictures();
            DrawPointsFromList(pointModels, colorsBrush[RED]);
        }

        private void tabPageMethodic_Enter(object sender, EventArgs e)
        {
            DataAccess.ReadMethodicListTable(comboBoxMethodicList, this);
        }
        private void tabPagePoints_Leave(object sender, EventArgs e)
        {
            DrawHumanPictures();
        }

        private void tabPageMethodic_Leave(object sender, EventArgs e)
        {
            DrawHumanPictures();
        }
        private void buttonAddNewMethodic_Click(object sender, EventArgs e)
        {
            formMethodic.ShowDialog();
            DataAccess.ReadMethodicListTable(comboBoxMethodicList, this);
        }

        private void comboBoxMethodicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataAccess.ReadMethodicTable(comboBoxPointsList, comboBoxMethodicList.SelectedIndex+1, pointModels);
            toolTip1.ToolTipTitle = comboBoxMethodicList.Text;
            DrawHumanPictures();
            FlashPointsFromList(pointModels);
        }

        private async void buttonAddPointToMethodic_Click(object sender, EventArgs e)
        {
            formAddPointToMethodic = new FormAddPointToMethodic(comboBoxMethodicList.SelectedIndex + 1);
            formAddPointToMethodic.ShowDialog();
            formAddPointToMethodic.Dispose();
            await Task.Delay(1);

            DataAccess.ReadMethodicTable(comboBoxPointsList, comboBoxMethodicList.SelectedIndex + 1, pointModels);
            DrawHumanPictures();
            FlashPointsFromList(pointModels);
        }
        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            double ratio = 1.0 * pictureBox1.Width / pictureBox1.Image.Width;
            if (e.Button == MouseButtons.Left)
            {
                int i = CheckPositionOnPoint(e, SIDE_FRONT);
                if (i<0)
                {
                    FormAddPoint form = new FormAddPoint(this, (int)(int)(e.X / ratio), (int)(e.Y / ratio), SIDE_FRONT);
                    form.ShowDialog();
                    form.Dispose();
                }
            } else
            {
                int pointId = CheckPositionOnPoint(e, SIDE_FRONT);
                if (pointId > -1)
                {
                    DataAccess.selectedPointId = pointModels[pointId].id;
                    contextMenuStripPoint.Show(Cursor.Position);
                }
            }
        }

        private void PictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            double ratio = 1.0 * pictureBox1.Width / pictureBox1.Image.Width;
            if (e.Button == MouseButtons.Left)
            {
                int i = CheckPositionOnPoint(e, SIDE_FRONT);
                if (i<0)
                {
                    FormAddPoint form = new FormAddPoint(this, (int)(int)(e.X / ratio), (int)(e.Y / ratio), SIDE_BACK);
                    form.ShowDialog();
                    form.Dispose();
                }
            }
            else
            {
                int pointId = CheckPositionOnPoint(e, SIDE_BACK);
                if (pointId > -1) {
                    DataAccess.selectedPointId = pointModels[pointId].id;
                    contextMenuStripPoint.Show(Cursor.Position);
                }
            }
        }

        private async void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataAccess.RemoveRecordFromMethodicTable();
            await Task.Delay(1);
            DataAccess.UpdatePointsModel(pointModels);
            DrawHumanPictures();
            FlashPointsFromList(pointModels);
        }


        private void TrackBarLaser_Scroll(object sender, EventArgs e)
        {
            int index_value = GetIndexFromTrackBarLaser(sender);

            SendValueToSerial(index_value, (sender as TrackBar).Value);

            switch (index_value) {
                case 0: numericUpDownLaser1.Value = (sender as TrackBar).Value; break;
                case 1: numericUpDownLaser2.Value = (sender as TrackBar).Value; break;
                case 2: numericUpDownLaser3.Value = (sender as TrackBar).Value; break;
                case 3: numericUpDownLaser4.Value = (sender as TrackBar).Value; break;
                case 4: numericUpDownLaser5.Value = (sender as TrackBar).Value; break;
                case 5: numericUpDownLaser6.Value = (sender as TrackBar).Value; break;
                case 6: numericUpDownLaser7.Value = (sender as TrackBar).Value; break;
                case 7: numericUpDownLaser8.Value = (sender as TrackBar).Value; break;
                case 8: numericUpDownLaser9.Value = (sender as TrackBar).Value; break;
                case 9: numericUpDownLaser10.Value = (sender as TrackBar).Value; break;
            }
        }

        private int GetIndexFromTrackBarLaser(object sender)
        {
            int index_value = 0;
            if (sender == trackBarLaser1) index_value = 0;
            else if (sender == trackBarLaser2) index_value = 1;
            else if (sender == trackBarLaser3) index_value = 2;
            else if (sender == trackBarLaser4) index_value = 3;
            else if (sender == trackBarLaser5) index_value = 4;
            else if (sender == trackBarLaser6) index_value = 5;
            else if (sender == trackBarLaser7) index_value = 6;
            else if (sender == trackBarLaser8) index_value = 7;
            else if (sender == trackBarLaser9) index_value = 8;
            else if (sender == trackBarLaser10) index_value = 9;
            return index_value;
        }

        private int CheckPositionOnPoint(MouseEventArgs e, String side)
        {
            int x = e.X;
            int y = e.Y;
            for (int i = 0; i < pointModels.Count; i++)
            {
                if (x > (pointModels[i].coordX - pointRadius) &&
                    x < (pointModels[i].coordX + pointRadius + 1) &&
                    y > (pointModels[i].coordY - pointRadius - 1) &&
                    y < (pointModels[i].coordY + pointRadius + 1) &&
                    pointModels[i].side == side) return i;
            }
            return -1;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int i = CheckPositionOnPoint(e, SIDE_FRONT);
            if (i>-1) ttip.Show(pointModels[i].pointname,pictureBox1);
            else ttip.Hide(pictureBox1);
        }

        private void buttonOpenMapFront_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                meredianFrontFileName = openFileDialog1.FileName;
                lblFrontMapFileName.Text = openFileDialog1.SafeFileName;
            }
            else
            {
                MessageBox.Show("Файл не выбран :(");
            }
        }
        private void buttonOpenMapBack_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                meredianBackFileName = openFileDialog1.FileName;
                lblBackMapFileName.Text = openFileDialog1.SafeFileName;
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
                humanModelBackFileName = openFileDialog1.FileName;
                lblBackModelFileName.Text = openFileDialog1.SafeFileName;
                pictureBox2.Image = new Bitmap(humanModelBackFileName);
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
                humanModelFrontFileName = openFileDialog1.FileName;
                lblFrontModelFileName.Text = openFileDialog1.SafeFileName;
                pictureBox1.Image = new Bitmap(humanModelFrontFileName);
            }
            else
            {
                MessageBox.Show("Файл не выбран :(");
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            int i = CheckPositionOnPoint(e, SIDE_BACK);
            if (i > -1) ttip.Show(pointModels[i].pointname, pictureBox2);
            else ttip.Hide(pictureBox2);
        }

        private void NumericUpDownLaser_ValueChanged(object sender, EventArgs e)
        {
            int index = 0;
            if (sender == numericUpDownLaser1) trackBarLaser1.Value = 0;
            else if (sender == numericUpDownLaser1) index = 1;
            else if (sender == numericUpDownLaser2) index = 2;
            else if (sender == numericUpDownLaser3) index = 3;
            else if (sender == numericUpDownLaser4) index = 4;
            else if (sender == numericUpDownLaser5) index = 5;
            else if (sender == numericUpDownLaser6) index = 6;
            else if (sender == numericUpDownLaser7) index = 7;
            else if (sender == numericUpDownLaser8) index = 8;
            else if (sender == numericUpDownLaser9) index = 9;

            //laserChannel[index].myLevelPwm = .Value;
        }

        private void ComboBoxTimeLaser1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            ComboBox currComboBox = (ComboBox)sender;

            currComboBox.SelectedIndex = e.Index;
            string text = currComboBox.Items[e.Index].ToString();
            int textInteger = Convert.ToInt32(text);

            Brush brush;
            if (textInteger > 15)
            {
                brush = Brushes.Red;
            }
            else if (textInteger > 10 )
            {
                brush = Brushes.Blue;
            }
            else
            {
                brush = Brushes.Green;
            }
            e.Graphics.DrawString(text, currComboBox.Font, brush, e.Bounds.X, e.Bounds.Y);
        }

        private void NumericUpDownTime_ValueChanged(object sender, EventArgs e)
        {
            int index = 0;
            if (sender == numericUpDownTime1) index = 0;
            else if (sender == numericUpDownTime2) index = 1;
            else if (sender == numericUpDownTime3) index = 2;
            else if (sender == numericUpDownTime4) index = 3;
            else if (sender == numericUpDownTime5) index = 4;
            else if (sender == numericUpDownTime6) index = 5;
            else if (sender == numericUpDownTime7) index = 6;
            else if (sender == numericUpDownTime8) index = 7;
            else if (sender == numericUpDownTime9) index = 8;
            else if (sender == numericUpDownTime10) index = 9;

            laserChannel[index].myTimeSeconds = (sender as NumericUpDown).Value;
        }

        public  void DrawPoint(int x, int y,String sideHuman)
        {
            PictureBox pictureBox;
            if (sideHuman != SIDE_BACK) pictureBox = pictureBox1; else pictureBox = pictureBox2;

            Bitmap bmp = new Bitmap(pictureBox.Image, pictureBox.Image.Size.Width, pictureBox.Image.Size.Height);
            bmp.SetResolution(pictureBox.Image.HorizontalResolution, pictureBox.Image.VerticalResolution);
            bmp.GetPixel(x, y);

            using (var gr = Graphics.FromImage(pictureBox.Image))
                gr.FillEllipse(Brushes.Green, x, y, pointRadius, pointRadius);
            pictureBox.Invalidate();
        }

        private void DrawPointsFromList(List<PointModel> pointModels, Brush color)
        {
            for (int i = 0; i < pointModels.Count; i++)
            {
                if (pointModels[i].side == SIDE_FRONT)
                {
                    using (var gr = Graphics.FromImage(pictureBox1.Image))
                        gr.FillEllipse(color, pointModels[i].coordX, pointModels[i].coordY, pointRadius, pointRadius);
                    pictureBox1.Invalidate();
                }
                else
                {
                    using (var gr = Graphics.FromImage(pictureBox2.Image))
                        gr.FillEllipse(color, pointModels[i].coordX, pointModels[i].coordY, pointRadius, pointRadius);
                    pictureBox2.Invalidate();
                }
            }
        }

        private async void FlashPointsFromList(List<PointModel> pointModels)
        {
            int x = 5;
            int j;
            while (x>0)
            {
                x--;
                j = colorsBrush.Count;
                while (j>0)
                {
                    j--;
                    for (int i = 0; i < pointModels.Count; i++)
                    {
                        if (pointModels[i].side == SIDE_FRONT)
                        {
                            using (var gr = Graphics.FromImage(pictureBox1.Image))
                                gr.FillEllipse(colorsBrush[j], pointModels[i].coordX, pointModels[i].coordY, pointRadius, pointRadius);
                            pictureBox1.Invalidate();
                        }
                        else
                        {
                            using (var gr = Graphics.FromImage(pictureBox2.Image))
                                gr.FillEllipse(colorsBrush[j], pointModels[i].coordX, pointModels[i].coordY, pointRadius, pointRadius);
                            pictureBox2.Invalidate();
                        }
                        await Task.Delay(1);
                    }
                }
            }
        }

        private void DrawHumanPictures()
        {
            if (humanModelFrontFileName != null && humanModelBackFileName != null)
            {
                pictureBox1.Image = new Bitmap(humanModelFrontFileName);
                pictureBox2.Image = new Bitmap(humanModelBackFileName);
            }
            pictureBox1.Update();
            pictureBox2.Invalidate();
        }

        Bitmap AlphaBlending(Image firstBitmap, Image secondBitmap, float alphaPercent)
        {
            if (alphaPercent < 0f || alphaPercent > 1f)
                throw new ArgumentOutOfRangeException();

            if (firstBitmap == null || secondBitmap == null)
                throw new NullReferenceException();

            Bitmap bmp = new Bitmap(
                Math.Max(firstBitmap.Width, secondBitmap.Width),
                Math.Max(firstBitmap.Height, secondBitmap.Height)
                );

            var colorMatrix = new ColorMatrix(
                new float[][] {
                    new float[] { 1.0f, 0.0f, 0.0f, 0.0f, 0.0f },
                    new float[] { 0.0f, 1.0f, 0.0f, 0.0f, 0.0f },
                    new float[] { 0.0f, 0.0f, 1.0f, 0.0f, 0.0f },
                    new float[] { 0.0f, 0.0f, 0.0f, alphaPercent, 0.0f },
                    new float[] { 0.0f, 0.0f, 0.0f, 0.0f, 1.0f }
                }
            );

            using (var imgAttr = new ImageAttributes())
            {
                imgAttr.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                using (var g = Graphics.FromImage(bmp))
                {
                    g.DrawImage(firstBitmap, 0, 0, firstBitmap.Width, firstBitmap.Height);
                    g.DrawImage(secondBitmap,
                        new Rectangle(0, 0, secondBitmap.Width, secondBitmap.Height),
                        0, 0, secondBitmap.Width, secondBitmap.Height,GraphicsUnit.Pixel,imgAttr);
                }
            }

            return bmp;
        }

        unsafe Bitmap AlphaBlendingUnsafe(Bitmap firstBitmap, Bitmap secondBitmap, byte alphaPercent)
        {
            if (firstBitmap == null || secondBitmap == null)
                throw new NullReferenceException();

            if (firstBitmap.PixelFormat != PixelFormat.Format24bppRgb || secondBitmap.PixelFormat != PixelFormat.Format24bppRgb)

                throw new ArgumentException();

            var rect = new Rectangle(0, 0, Math.Min(firstBitmap.Width, secondBitmap.Width), Math.Min(firstBitmap.Height, secondBitmap.Height));

            Bitmap bmp = new Bitmap(
                rect.Width,
                rect.Height,
                PixelFormat.Format24bppRgb
                );

            var bd = bmp.LockBits(rect, ImageLockMode.WriteOnly, bmp.PixelFormat);
            var bd0 = firstBitmap.LockBits(rect, ImageLockMode.ReadOnly, firstBitmap.PixelFormat);
            var bd1 = secondBitmap.LockBits(rect, ImageLockMode.ReadOnly, secondBitmap.PixelFormat);

            byte* pBmp = (byte*)bd.Scan0;
            byte* pX = (byte*)bd0.Scan0;
            byte* pY = (byte*)bd1.Scan0;

            byte* pEnd = pBmp + bd.Stride * bd.Height;

            while (pBmp != pEnd)
            {
                *pBmp = (byte)(*pX * (255 - alphaPercent) / 255 + *pY * alphaPercent / 255);
                *(pBmp + 1) = (byte)(*(pX + 1) * (255 - alphaPercent) / 255 + *(pY + 1) * alphaPercent / 255);
                *(pBmp + 2) = (byte)(*(pX + 2) * (255 - alphaPercent) / 255 + *(pY + 2) * alphaPercent / 255);

                pBmp += 3;
                pX += 3;
                pY += 3;
            }

            bmp.UnlockBits(bd);
            firstBitmap.UnlockBits(bd0);
            secondBitmap.UnlockBits(bd1);
            return bmp;
        }
    }
}
