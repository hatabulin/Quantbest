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
using Quantium.Model;
using Quantium.Views;

namespace Quantium
{
    public partial class FormMain : Form
    {
        private const byte RED = 0;
        private const byte GREEN = 1;
        private const byte YELLOW = 2;
        private const byte WHITE = 3;
        private const byte BLUE = 3;
        private const byte BLACK = 3;

        public const String SIDE_FRONT = "Front";
        public const String SIDE_BACK = "Back";

        public static LaserChannel[] laserChannel = {
            new LaserChannel(0,10), new LaserChannel(100, 10), new LaserChannel(50, 10), new LaserChannel(255, 10), new LaserChannel(128, 10),
            new LaserChannel(100, 10), new LaserChannel(10, 10), new LaserChannel(30, 10), new LaserChannel(40, 15), new LaserChannel(100, 20)};
        private string[] ports;
        private const String TEST_STRING_ON_ALL = "cfg:ch00=ff,ch01=ff,ch02:ff,ch03:ff,ch04:ff,ch05:ff,ch06:ff,ch07:ff,ch08:ff,ch09:ff";
        private const String TEST_STRING_OFF_ALL = "cfg:ch00=00,ch01=00,ch02=00,ch03=00,ch04=00,ch05=00,ch06=00,ch07=00,ch08=00,ch09=00";
        private const String TEXT_CONNECT = "OPEN";
        private const String TEXT_DISCONNECT = "CLOSE";

        private int timerProcedureCounter = 0;
        private const int pointRadius = 10;
        static float currentAlphaValue = 0.45f;
        private string mapFrontFileName, mapBackFileName;
        private string humanModelFrontFileName, humanModelBackFileName;
        private readonly List<Brush> colorsBrush = new List<Brush> { Brushes.Red, Brushes.Green, Brushes.Yellow, Brushes.White, Brushes.Blue, Brushes.Black };

        private List<PointModel> selectedPointModels = new List<PointModel>();
        private List<PointModel> humanPointModels = new List<PointModel>();
        private List<MethodicModel> methodicModels = new List<MethodicModel>();
        private List<MethodicItemModel> methodicItemModels = new List<MethodicItemModel>();
        private List<HumanModel> humanModels = new List<HumanModel>();
        
        ToolTip ttip = new ToolTip();

//        FormAddPointToMethodic formAddPointToMethodic;
//        FormDisease formDisease;

        public FormMain()
        {
            InitializeComponent();
            DataAccess.CreateTables();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            cbComPort.Items.Clear();
            cbComPort.Items.AddRange(SerialPort.GetPortNames());
            if (cbComPort.Items.Count != 0)
            {
                ports = SerialPort.GetPortNames();
                cbComPort.SelectedIndex = cbComPort.Items.Count - 1;
                cbDisease.SelectedIndex = 0;
                cbDiseaseType.SelectedIndex = 0;
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
        void FillValuesToControls()
        {
            nudLaser1.Value = laserChannel[0].myLevelPwm;
            nudLaser2.Value = laserChannel[1].myLevelPwm;
            nudLaser3.Value = laserChannel[2].myLevelPwm;
            nudLaser4.Value = laserChannel[3].myLevelPwm;
            nudLaser5.Value = laserChannel[4].myLevelPwm;
            nudLaser6.Value = laserChannel[5].myLevelPwm;
            nudLaser7.Value = laserChannel[6].myLevelPwm;
            nudLaser8.Value = laserChannel[7].myLevelPwm;
            nudLaser9.Value = laserChannel[8].myLevelPwm;
            nudLaser10.Value = laserChannel[9].myLevelPwm;

            tbLaser1.Value = laserChannel[0].myLevelPwm;
            tbLaser2.Value = laserChannel[1].myLevelPwm;
            tbLaser3.Value = laserChannel[2].myLevelPwm;
            tbLaser4.Value = laserChannel[3].myLevelPwm;
            tbLaser5.Value = laserChannel[4].myLevelPwm;
            tbLaser6.Value = laserChannel[5].myLevelPwm;
            tbLaser7.Value = laserChannel[6].myLevelPwm;
            tbLaser8.Value = laserChannel[7].myLevelPwm;
            tbLaser9.Value = laserChannel[8].myLevelPwm;
            tbLaser10.Value = laserChannel[9].myLevelPwm;

            tabControl1.SelectedIndex = 2; // 0 - Driver settings tabpage, 1 - Human models tabpage, 2 - Methodic tabPage, 3 - Disease tabpage
        }
        private void SendValueToSerial(int channelNumber, int value)
        {
            string str = $"cfg:ch{channelNumber:X2}={value:X2}";
            serialPort1.WriteLine(str);
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (buttonConnect.Text != TEXT_DISCONNECT)
            {
                if (cbComPort.SelectedIndex > -1)
                {
                    try
                    {
                        serialPort1.PortName = ports[cbComPort.SelectedIndex];
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
        private void cbShowMapImages_CheckedChanged(object sender, EventArgs e)
        {
            Bitmap bitmap;
            if (cbShowMapImages.Checked)
            {
                if (mapFrontFileName != null && mapBackFileName != null && humanModelFrontFileName != null && humanModelBackFileName != null)
                {
                    bitmap = AlphaBlending(new Bitmap(humanModelFrontFileName), new Bitmap(mapFrontFileName), currentAlphaValue);
                    pictureBox1.Image = bitmap;

                    bitmap = AlphaBlending(new Bitmap(humanModelBackFileName), new Bitmap(mapBackFileName), currentAlphaValue);
                    pictureBox2.Image = bitmap;
                    vScrollBar1.Enabled = true;
                }
                else
                {
                    cbShowMapImages.Checked = false;
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
            if (cbShowMapImages.Checked)
            {
                if (mapFrontFileName != null && mapBackFileName != null)
                {
                    currentAlphaValue = (float)(vScrollBar1.Minimum + vScrollBar1.Maximum - vScrollBar1.Value) / 100;
                    bitmap = humanModelFrontFileName != null ? new Bitmap(humanModelFrontFileName) : new Bitmap(Properties.Resources.no_file);
                    bitmap = AlphaBlending(bitmap, new Bitmap(mapFrontFileName), currentAlphaValue);
                    pictureBox1.Image = bitmap;

                    bitmap = humanModelBackFileName == null ? new Bitmap(Properties.Resources.no_file) : new Bitmap(humanModelBackFileName);
                    bitmap = AlphaBlending(bitmap, new Bitmap(mapBackFileName), currentAlphaValue);
                    pictureBox2.Image = bitmap;
                }
                else
                {
                    cbShowMapImages.Checked = false;
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
        private void tpPoints_Enter(object sender, EventArgs e)
        {
            DrawHumanPictures();
            DrawPointsFromList(humanPointModels, colorsBrush[RED]);
        }
        private async void buttonAddPointToMethodic_Click(object sender, EventArgs e)
        {
            FormAddPointToMethodic formAddPointToMethodic = new FormAddPointToMethodic(cbMethodicList.SelectedIndex + 1);
            formAddPointToMethodic.ShowDialog();
            formAddPointToMethodic.Dispose();
            await Task.Delay(1);

            DrawHumanPictures();
            FlashPointsFromList(humanPointModels);
        }
        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) CheckAndAddPoint(SIDE_FRONT, e);
        }
        private void PictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (tabControl1.SelectedIndex == 1) CheckAndAddPoint(SIDE_BACK, e);
        }
        void CheckAndAddPoint(string side, MouseEventArgs e)
        {
            double ratio = 1.0 * pictureBox1.Width / pictureBox1.Image.Width;
            if (e.Button == MouseButtons.Left)
            {
                int i = CheckPositionOnPoint(e, side);
                if (i < 0)
                {
                    FormAddPoint form = new FormAddPoint(this, humanModels[cbHumanModel.SelectedIndex].id_human_model, (int)(int)(e.X / ratio), (int)(e.Y / ratio), side);
                    form.ShowDialog();
                    form.Dispose();
                }
            }
            else
            {
                int pointId = CheckPositionOnPoint(e, side);
                if (pointId > -1)
                {
                    DataAccess.selectedPointId = humanPointModels[pointId].id_point;
                    contextMenuStripPoint.Show(Cursor.Position);
                }
            }
        }
        private async void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DataAccess.RemoveRecordFromMethodicTable();
            await Task.Delay(1);
            DrawHumanPictures();
            FlashPointsFromList(humanPointModels);
        }
        private void TrackBarLaser_Scroll(object sender, EventArgs e)
        {
            int index_value = GetIndexFromTrackBarLaser(sender);

            SendValueToSerial(index_value, (sender as TrackBar).Value);
/*
            switch (index_value)
            {
                case 0: nudLaser1.Value = (sender as TrackBar).Value; break;
                case 1: nudLaser2.Value = (sender as TrackBar).Value; break;
                case 2: nudLaser3.Value = (sender as TrackBar).Value; break;
                case 3: nudLaser4.Value = (sender as TrackBar).Value; break;
                case 4: nudLaser5.Value = (sender as TrackBar).Value; break;
                case 5: nudLaser6.Value = (sender as TrackBar).Value; break;
                case 6: nudLaser7.Value = (sender as TrackBar).Value; break;
                case 7: nudLaser8.Value = (sender as TrackBar).Value; break;
                case 8: nudLaser9.Value = (sender as TrackBar).Value; break;
                case 9: nudLaser10.Value = (sender as TrackBar).Value; break;
            }
  */      }
        private int GetIndexFromTrackBarLaser(object sender)
        {
            int index_value = 0;
            if (sender == tbLaser1) index_value = 0;
            else if (sender == tbLaser2) index_value = 1;
            else if (sender == tbLaser3) index_value = 2;
            else if (sender == tbLaser4) index_value = 3;
            else if (sender == tbLaser5) index_value = 4;
            else if (sender == tbLaser6) index_value = 5;
            else if (sender == tbLaser7) index_value = 6;
            else if (sender == tbLaser8) index_value = 7;
            else if (sender == tbLaser9) index_value = 8;
            else if (sender == tbLaser10) 
                index_value = 9;
            return index_value;
        }
        private int CheckPositionOnPoint(MouseEventArgs e, String side)
        {
            int x = e.X;
            int y = e.Y;
            for (int i = 0; i < humanPointModels.Count; i++)
            {
                if (x > (humanPointModels[i].coordX - pointRadius) &&
                    x < (humanPointModels[i].coordX + pointRadius + 1) &&
                    y > (humanPointModels[i].coordY - pointRadius - 1) &&
                    y < (humanPointModels[i].coordY + pointRadius + 1) &&
                    humanPointModels[i].side == side) return i;
            }
            return -1;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int i = CheckPositionOnPoint(e, SIDE_FRONT);
            if (i>-1) ttip.Show(humanPointModels[i].pointname,pictureBox1);
            else ttip.Hide(pictureBox1);
        }
        private void ChangeFilePathPictures(string mapFrontFileName, string mapBackFileName, string humanFrontFileName, string humanBackFileName)
        {
            this.humanModelFrontFileName = humanFrontFileName;
            this.humanModelBackFileName = humanBackFileName;
            this.mapFrontFileName = mapFrontFileName;
            this.mapBackFileName = mapBackFileName;

            if (humanModelBackFileName != null)
            {
                pictureBox2.Image = new Bitmap(humanModelBackFileName);
            }
            
            if (humanModelFrontFileName != null)
            {
                pictureBox1.Image = new Bitmap(humanModelFrontFileName);
            }

            cbShowMapImages.Checked = false;
        }
        private async void btnAddDisease_Click(object sender, EventArgs e)
        {
            int methodicId = cbMethodicList.SelectedIndex + 1;
            await Task.Delay(1);

            FormDisease formDisease = new FormDisease(methodicId);
            formDisease.ShowDialog();
            formDisease.Dispose();
        }
        private void cbMethodicList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateMethodicViews(cbMethodicList.SelectedIndex, false);
        }
        private void tabPageMethodic_Enter(object sender, EventArgs e)
        {
            UpdateMethodicViews(cbMethodicList.SelectedIndex, true);
        }
        private void UpdateMethodicViews(int index, bool reload)
        {
            cbShowMapImages.Checked = false;
            lbHumanPoints.Items.Clear();

            if (reload)
            {
                DataAccess.ReadMethodicListTable(methodicItemModels);
                cbMethodicList.Items.Clear();
                if (methodicItemModels.Count > 0)
                {
                    for (int i = 0; i < methodicItemModels.Count; i++)
                    {
                        cbMethodicList.Items.Add(methodicItemModels[i].name);
                    }
                    index = 0;
                    cbMethodicList.SelectedIndex = index;
                }
            }

            if (index >= 0)
            {
                ChangeFilePathPictures(methodicItemModels[index].mapFrontFileName, methodicItemModels[index].mapBackFileName, methodicItemModels[index].bodyFrontFileName, methodicItemModels[index].bodyBackFileName);
                tbHumanModel.Text = methodicItemModels[index].humanModelName;
                rtbMethodicMemo.Text = methodicItemModels[index].memo;

                DataAccess.GetPointsFromHumanTable(humanPointModels, methodicItemModels[index].humanModelId);
                if (humanPointModels.Count > 0)
                {
                    foreach (PointModel v in humanPointModels) lbHumanPoints.Items.Add(v.pointname);
                }

                // Создаем список точек выдернутый с основной таблици методик.
                toolTip1.ToolTipTitle = cbMethodicList.Text;
                UpdateSelectedPointsListbox(methodicItemModels[index].methodicId);
            }
            // Создаем список точек выдернутый с используемой модели в таблице списка методик.
        }
        private void UpdateSelectedPointsListbox(int methodicId)
        {
            lbSelectedPoints.Items.Clear();
            DataAccess.GetPointsFromMainTable(selectedPointModels, methodicId);
            if (selectedPointModels.Count > 0)
            {
                for (int i = 0; i < selectedPointModels.Count; i++) lbSelectedPoints.Items.Add(selectedPointModels[i].pointname);
                FlashPointsFromList(selectedPointModels);
            }
        }
        private void UpdateHumanModelViews(int index, bool reload)
        {
            lbPoints.Items.Clear();
            if (reload)
            {
                DataAccess.GetHumanModelsList(humanModels);
                cbHumanModel.Items.Clear();
                if (humanModels.Count > 0)
                {
                    for (int i = 0; i < humanModels.Count; i++)
                    {
                        cbHumanModel.Items.Add(humanModels[i].name);
                    }
                    index = 0;
                }
            }

            if (humanModels.Count > 0)
            {
                // Создаем список точек выдернутый с используемой модели в таблице списка методик.
                cbHumanModel.Enabled = true;
                DataAccess.GetPointsFromHumanTable(humanPointModels, humanModels[index].id_human_model);
                if (humanPointModels.Count > 0)
                {
                    for (int i = 0; i < humanPointModels.Count; i++)
                    {
                        lbPoints.Items.Add(humanPointModels[i].pointname);
                    }
                }

                ChangeFilePathPictures(humanModels[index].mapFrontPath, humanModels[index].mapBackPath, humanModels[index].bodyFrontPath, humanModels[index].bodyBackPath);
                FlashPointsFromList(humanPointModels);

                cbHumanModel.Text = humanModels[index].name;
                cbHumanModel.Enabled = true;
                tbMapFrontFileName.Text = humanModels[index].mapFrontPath;
                tbMapBackFileName.Text = humanModels[index].mapBackPath;
                tbHumanFrontFileName.Text = humanModels[index].bodyFrontPath;
                tbHumanBackFileName.Text = humanModels[index].bodyBackPath;
            }
            else cbHumanModel.Enabled = false;
        }
        private void cbHumanModel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            UpdateHumanModelViews(cbHumanModel.SelectedIndex, false);
        }

        private void btnAddPoint_Click(object sender, EventArgs e)
        {
            CopyHumanPointWithAdditionalData(lbHumanPoints.SelectedIndex, cbMethodicList.SelectedIndex);
            UpdateSelectedPointsListbox(methodicItemModels[cbMethodicList.SelectedIndex].methodicId);
        }
        private void lbHumanPoints_DoubleClick(object sender, EventArgs e)
        {
            CopyHumanPointWithAdditionalData(lbHumanPoints.SelectedIndex, cbMethodicList.SelectedIndex);
            UpdateSelectedPointsListbox(methodicItemModels[cbMethodicList.SelectedIndex].methodicId);
        }
        private void CopyHumanPointWithAdditionalData(int humanPointsIndex, int methodicIndex)
        {
            humanPointModels[humanPointsIndex].id_methodic = methodicItemModels[methodicIndex].methodicId;
            FormConfigPoint formConfigPoint = new FormConfigPoint(humanPointModels[lbHumanPoints.SelectedIndex]); // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            formConfigPoint.ShowDialog();
            formConfigPoint.Dispose();
        }

        private void btnAddMethodic_Click_1(object sender, EventArgs e)
        {
            FormEnterMethodic formMethodic = new FormEnterMethodic();
            formMethodic.ShowDialog();
            formMethodic.Dispose();
            UpdateMethodicViews(0, true);
        }

        private void tpHumanModel_Enter(object sender, EventArgs e)
        {
            UpdateHumanModelViews(cbHumanModel.SelectedIndex, true);
        }
        private void btnAddHumanModel_Click(object sender, EventArgs e)
        {
            FormAddHumanModel formAddHumanModel = new FormAddHumanModel();
            formAddHumanModel.ShowDialog();
            formAddHumanModel.Dispose();
            UpdateHumanModelViews(0, true);
        }
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            int i = CheckPositionOnPoint(e, SIDE_BACK);
            if (i > -1) ttip.Show(humanPointModels[i].pointname, pictureBox2);
            else ttip.Hide(pictureBox2);
        }
        private void ComboBoxTimeLaser1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            ComboBox currComboBox = (ComboBox)sender;

            currComboBox.SelectedIndex = e.Index;
            int textInteger = Convert.ToInt32(currComboBox.Items[e.Index].ToString());

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
            e.Graphics.DrawString(currComboBox.Items[e.Index].ToString(), currComboBox.Font, brush, e.Bounds.X, e.Bounds.Y);
        }
        public  void DrawPoint(int x, int y,String sideHuman)
        {
            PictureBox pictureBox = sideHuman != SIDE_BACK ? pictureBox1 : pictureBox2;
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
                switch (pointModels[i].side)
                {
                    case SIDE_FRONT:
                        {
                            using (var gr = Graphics.FromImage(pictureBox1.Image))
                                gr.FillEllipse(color, pointModels[i].coordX, pointModels[i].coordY, pointRadius, pointRadius);
                            pictureBox1.Invalidate();
                            break;
                        }

                    default:
                        {
                            using (var gr = Graphics.FromImage(pictureBox2.Image))
                                gr.FillEllipse(color, pointModels[i].coordX, pointModels[i].coordY, pointRadius, pointRadius);
                            pictureBox2.Invalidate();
                            break;
                        }
                }
            }
        }
        private async void FlashPointsFromList(List<PointModel> pointModels)
        {
            int x = 2;
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
                        switch (pointModels[i].side)
                        {
                            case SIDE_FRONT:
                                {
                                    using (var gr = Graphics.FromImage(pictureBox1.Image))
                                        gr.FillEllipse(colorsBrush[j], pointModels[i].coordX, pointModels[i].coordY, pointRadius, pointRadius);
                                    pictureBox1.Invalidate();
                                    break;
                                }

                            default:
                                {
                                    using (var gr = Graphics.FromImage(pictureBox2.Image))
                                        gr.FillEllipse(colorsBrush[j], pointModels[i].coordX, pointModels[i].coordY, pointRadius, pointRadius);
                                    pictureBox2.Invalidate();
                                    break;
                                }
                        }
                        await Task.Delay(1);// .Delay(1);
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

        private void btnStartProcedures_Click(object sender, EventArgs e)
        {
            if (selectedPointModels.Count>0)
            {
                for (int i=0;i<selectedPointModels.Count;i++)
                {
                    SendValueToSerial(selectedPointModels[i].channel, selectedPointModels[i].power);
                    Thread.Sleep(20);
                }

                timerProcedure.Enabled = true;
                btnStartProcedures.Enabled = false;
            }
        }

        private void timerProcedure_Tick(object sender, EventArgs e)
        {
            timerProcedureCounter++;
            int currentCount = 0;

            for (int i = 0; i < selectedPointModels.Count; i++)
            {
                if (selectedPointModels[i].time < timerProcedureCounter)
                {
                    SendValueToSerial(selectedPointModels[i].channel, 0);
                    Thread.Sleep(20);
                    currentCount++;
                }
                if (currentCount == selectedPointModels.Count)
                {
                    timerProcedure.Enabled = false;
                    MessageBox.Show("Procedure ended !");
                    btnStartProcedures.Enabled = true;
                }
            }
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
