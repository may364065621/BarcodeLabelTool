using System.Text.Json;
using System.Text.Json.Serialization;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Xml.Linq;

namespace text1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            points.Add("leftup", new string[2]);
            points.Add("leftdown", new string[2]);
            points.Add("rightdown", new string[2]);
            points.Add("rightup", new string[2]);

            btnpoints.Add(btn_leftup);
            btnpoints.Add(btn_leftdown);
            btnpoints.Add(btn_rightdown);
            btnpoints.Add(btn_rightup);
            labelpoints.Add(label_leftup);
            labelpoints.Add(label_leftdown);
            labelpoints.Add(label_rightdown);
            labelpoints.Add(label_rightup);

            int i = 0;

            this.Text = "二维码标注工具  " + version + "  " + producer;
        }
        string version = "v1.0.0";
        string producer = "X产品部";

        Dictionary<string, string[]> points = new Dictionary<string, string[]>();
        string str_pointname = "";
        List<Button> btnpoints = new List<Button>();
        List<Label> labelpoints = new List<Label>();
        string imageName = "";
        double zoom = 1.0;

        Image image = null;
        private void btn_readImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                if (DialogResult.OK == ofd.ShowDialog())
                {
                    image = Image.FromFile(ofd.FileName);
                    imageName = ofd.FileName;
                    pictureBox1.Image = image;
                    //根据图片大小，让pictureBox1、panel、整个窗体按比例缩放
                    int max = pictureBox1.Image.Width >= pictureBox1.Image.Height ? pictureBox1.Image.Width : pictureBox1.Image.Height;
                    if (max <= 800)
                    {
                        pictureBox1.Size = new Size(pictureBox1.Image.Width, pictureBox1.Image.Height);
                        zoom = 1;
                    }
                    else
                    {
                        if (pictureBox1.Image.Width >= pictureBox1.Image.Height)
                        {
                            zoom = (pictureBox1.Image.Width * 1.0) / 800;
                        }
                        else
                        {
                            zoom = (pictureBox1.Image.Height * 1.0) / 800;
                        }
                    }
                    pictureBox1.Size = new Size(Convert.ToInt32((pictureBox1.Image.Width * 1.0) / zoom), Convert.ToInt32((pictureBox1.Image.Height * 1.0) / zoom));

                    Point p1 = pictureBox1.Location;
                    panel_tool.Location = new Point(p1.X + pictureBox1.Width + 10, p1.Y);

                    if (pictureBox1.Height > panel_tool.Height)
                    {
                        panel_tool.Height = pictureBox1.Height;
                    }
                    this.Width = pictureBox1.Width + panel_tool.Width + 50;

                    this.Height = pictureBox1.Height > panel_tool.Height ? pictureBox1.Height + 50 : panel_tool.Height + 50;

                    label_stateIn.Text = "路径\n" + imageName + "\n图片读取完成";
                    label_stateIn.ForeColor = Color.Green;
                }
            }
            catch (Exception ee)
            {
                label_stateIn.ForeColor = Color.Red;
                label_stateIn.Text = "图片读取失败";
                MessageBox.Show(ee.ToString());
            }

        }
        private void btn_cleanwindow_Click(object sender, EventArgs e)
        {
            try
            {
                if (image != null)
                {
                    pictureBox1.Image = image;
                }

                foreach (string key in points.Keys)
                {
                    points[key] = new string[2];
                }

                state_genGrid = false;
                str_pointname = "";
                cellmeg.Clear();
                state_drawPoint = false;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
        private void btn_leftup_Click(object sender, EventArgs e)
        {
            try
            {
                if (!btnpoints_click("btn_leftup"))
                {
                    MessageBox.Show("有其他按键未确认");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }
        private void btn_rightup_Click(object sender, EventArgs e)
        {
            try
            {
                if (!btnpoints_click("btn_rightup"))
                {
                    MessageBox.Show("有其他按键未确认");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }

        private void btn_leftdown_Click(object sender, EventArgs e)
        {
            try
            {
                if (!btnpoints_click("btn_leftdown"))
                {
                    MessageBox.Show("有其他按键未确认");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }

        private void btn_rightdown_Click(object sender, EventArgs e)
        {
            try
            {
                if (!btnpoints_click("btn_rightdown"))
                {
                    MessageBox.Show("有其他按键未确认");
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
        public bool btnpoints_click(string name)
        {
            try
            {
                int i = -1; int index = -1;
                foreach (Button item in btnpoints)
                {
                    i++;
                    if (item.Name != name && item.BackColor != SystemColors.ControlLight)
                    {
                        return false;
                    }
                    if (item.Name == name)
                    {
                        index = i;
                    }
                }

                if (btnpoints[index].BackColor == SystemColors.ControlLight)
                {
                    btnpoints[index].BackColor = Color.Green;
                    str_pointname = btnpoints[index].Name.Remove(0, btnpoints[index].Name.IndexOf('_') + 1);
                }
                else
                {
                    btnpoints[index].BackColor = SystemColors.ControlLight;
                    str_pointname = "";
                }
                return true;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return false;
            }

        }

        Boolean state_genGrid = false;

        int intRow = 0; int intCol = 0;

        private void btn_genGrid_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Button item in btnpoints)
                {
                    if (item.BackColor != SystemColors.ControlLight)
                    {
                        MessageBox.Show("有按键未确认");
                        return;
                    }
                }
                if (!(int.TryParse(tb_row.Text, out intRow) && int.TryParse(tb_col.Text, out intCol)))
                {
                    MessageBox.Show("行列数必须为正整数");
                    return;
                }

                if (!state_genGrid)
                {
                    state_genGrid = true;
                }
                pictureBox1.Invalidate();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }

        Boolean state_drawPoint = false;
        private void btn_drawPoint_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Button item in btnpoints)
                {
                    if (item.BackColor != SystemColors.ControlLight)
                    {
                        MessageBox.Show("有按键未确认");
                        return;
                    }
                }

                if (!state_drawPoint)
                {
                    state_drawPoint = true;
                    btn_drawPoint.BackColor = Color.Green;
                }
                else
                {
                    state_drawPoint = false;
                    btn_drawPoint.BackColor = SystemColors.ControlLight;
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }

        public class JsonMeg
        {
            public int cols { get; set; }
            public int rows { get; set; }
            public int[][]? rect { get; set; }
            public int[][]? grid_pts { get; set; }
            public int[]? values { get; set; }
        }


        private void btn_exportJson_Click(object sender, EventArgs e)
        {
            if (imageName == "")
            {
                MessageBox.Show("请先导入图片数据");
                return;
            }
            string filename = imageName.Remove(imageName.LastIndexOf('.'), imageName.Length - imageName.LastIndexOf('.')) + ".json";

            try
            {
                if (intRow != Convert.ToInt32(tb_row.Text) || intCol != Convert.ToInt32(tb_col.Text))
                {
                    MessageBox.Show("行列数有修改，但未生成新的表格");
                    return;
                }
                foreach (string key in points.Keys)
                {
                    if (points[key] == null || points[key][0] == null || points[key][0] == "0")
                    {
                        MessageBox.Show("四个角点位置信息有缺");
                        return;
                    }
                }

                JsonMeg jsonMeg = new JsonMeg();
                jsonMeg.cols = intCol;
                jsonMeg.rows = intRow;
                jsonMeg.rect = new int[][] {new int[] {Convert.ToInt32(Convert.ToInt32(points["leftup"][0])*zoom),Convert.ToInt32(Convert.ToInt32(points["leftup"][1])*zoom) },
                                        new int[] {Convert.ToInt32(Convert.ToInt32(points["leftdown"][0])*zoom),Convert.ToInt32(Convert.ToInt32(points["leftdown"][1])*zoom) },
                                        new int[] {Convert.ToInt32(Convert.ToInt32(points["rightdown"][0])*zoom),Convert.ToInt32(Convert.ToInt32(points["rightdown"][1])*zoom) },
                                        new int[] {Convert.ToInt32(Convert.ToInt32(points["rightup"][0])*zoom),Convert.ToInt32(Convert.ToInt32(points["rightup"][1])*zoom) },};
                jsonMeg.grid_pts = new int[cellmeg.Count][];
                jsonMeg.values = new int[cellmeg.Count];
                for (int i = 0; i < cellmeg.Count; i++)
                {
                    jsonMeg.grid_pts[i] = new int[] { Convert.ToInt32(cellmeg[i][4] * zoom), Convert.ToInt32(cellmeg[i][5] * zoom) };
                    jsonMeg.values[i] = Convert.ToInt32(cellmeg[i][6]);
                }
                string jsonString = JsonSerializer.Serialize(jsonMeg);
                File.WriteAllText(filename, jsonString);
                label_stateOut.Text = "Json文件\n" + filename + "\n保存成功";
                label_stateOut.ForeColor = Color.Green;
            }
            catch (Exception ee)
            {
                label_stateOut.Text = "Json文件\n" + filename + "\n保存失败";
                label_stateOut.ForeColor = Color.Red;
                MessageBox.Show(ee.ToString());
            }

        }

        Boolean state = false;
        int oldX = 0;
        int oldY = 0;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!state)
            {
                state = true;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (state)
            {
                if (str_pointname != "")//4个角点
                {
                    points[str_pointname][0] = e.X.ToString("f0");
                    points[str_pointname][1] = e.Y.ToString("f0");

                    int i = 0;
                    foreach (string key in points.Keys)
                    {
                        if (points[key][0] != null && points[key][1] != null)
                        {
                            labelpoints[i].Text = "X:" + (Convert.ToDouble(points[key][0]) * zoom).ToString("f1") + "; Y:" + (Convert.ToDouble(points[key][1]) * zoom).ToString("f1") + "";
                        }
                        i++;
                    }
                }
                if (state_drawPoint)//开始画点
                {
                    if (!stateDoubleClick)
                    {
                        refreshCellResult(e.X, e.Y);
                    }
                    stateDoubleClick = false;
                }
                pictureBox1.Invalidate();
            }

            state = false;
        }
        Boolean stateDoubleClick = false;
        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    if (state_drawPoint)//开始画点
            //    {
            //        refreshCellResult(e.X, e.Y, 0);
            //        stateDoubleClick = true;

            //    }
            //    pictureBox1.Invalidate();
            //}
            //catch (Exception ee)
            //{
            //    MessageBox.Show(ee.ToString());
            //}

        }
        public void refreshCellResult(int X, int Y)
        {
            try
            {
                if (state_drawPoint)//开始画点
                {
                    Rectangle Gridrectangle = new Rectangle(Convert.ToInt32(points["leftup"][0]) - 1, Convert.ToInt32(points["leftup"][1]) - 1,
                        Convert.ToInt32(points["rightdown"][0]) - Convert.ToInt32(points["leftup"][0]) + 2,
                        Convert.ToInt32(points["rightdown"][1]) - Convert.ToInt32(points["leftup"][1]) + 2);
                    if (!Gridrectangle.Contains(X, Y))
                    {
                        return;
                    }
                    for (int i = 0; i < cellmeg.Count; i++)
                    {
                        Rectangle Cellrectangle = new Rectangle(Convert.ToInt32(cellmeg[i][0]), Convert.ToInt32(cellmeg[i][1]),
                            Convert.ToInt32(cellmeg[i][2] - cellmeg[i][0]), Convert.ToInt32(cellmeg[i][3] - cellmeg[i][1]));
                        if (Cellrectangle.Contains(X, Y))
                        {
                            cellmeg[i][6] = cellmeg[i][6] == 0 ? 1 : 0;
                            break;

                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }

        }

        List<double[]> cellmeg = new List<double[]>();// x1 y1 x2 y2 centerX centerY 1/0

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen penline = new Pen(Color.LightGreen, 1);
            Pen pen2 = new Pen(Color.Red, 2);
            Pen penpoint = new Pen(Color.Red, 2);

            foreach (string key in points.Keys)
            {
                if (points[key][0] != null && points[key][0] != "0")
                {
                    Rectangle rectangle = new Rectangle(Convert.ToInt32(points[key][0]) - 1, Convert.ToInt32(points[key][1]) - 1, 2, 2);
                    graphics.DrawArc(pen2, rectangle, 0, 360);
                }
            }
            if (state_genGrid && intRow != 0 && intCol != 0 &&
                points["leftup"][0] != null && points["leftdown"][0] != null &&
                points["rightdown"][0] != null && points["rightup"][0] != null)
            {
                int leftupX = Convert.ToInt32(points["leftup"][0]); int leftupY = Convert.ToInt32(points["leftup"][1]);
                int leftdownX = Convert.ToInt32(points["leftdown"][0]); int leftdownY = Convert.ToInt32(points["leftdown"][1]);
                int rightdownX = Convert.ToInt32(points["rightdown"][0]); int rightdownY = Convert.ToInt32(points["rightdown"][1]);
                int rightupX = Convert.ToInt32(points["rightup"][0]); int rightupY = Convert.ToInt32(points["rightup"][1]);

                graphics.DrawLine(penline, leftupX, leftupY, leftdownX, leftdownY);// |
                graphics.DrawLine(penline, rightupX, rightupY, rightdownX, rightdownY);
                graphics.DrawLine(penline, leftupX, leftupY, rightupX, rightupY);//   -
                graphics.DrawLine(penline, leftdownX, leftdownY, rightdownX, rightdownY);

                double width = rightdownX - leftupX;//宽
                double height = rightdownY - leftupY;//高

                double widthsplit = width / intCol;//宽间距 相当于 列间距
                double heightsplit = height / intRow;//高间距 相当于 行间距
                List<double> LocateX = new List<double>();
                List<double> LocateY = new List<double>();

                for (int i = 0; i < intCol; i++)// |
                {
                    graphics.DrawLine(penline, leftupX + Convert.ToInt32(widthsplit * i), leftupY, leftdownX + Convert.ToInt32(widthsplit * i), leftdownY);
                    LocateX.Add(leftupX + widthsplit * i);
                }
                LocateX.Add(rightupX);
                for (int i = 0; i < intRow; i++)//   -
                {
                    graphics.DrawLine(penline, leftupX, leftupY + Convert.ToInt32(heightsplit * i), rightupX, rightupY + Convert.ToInt32(heightsplit * i));
                    LocateY.Add(leftupY + heightsplit * i);
                }
                LocateY.Add(rightdownY);
                if (cellmeg.Count == intCol * intRow)
                {
                    int index = -1;
                    for (int i = 0; i < intCol; i++)
                    {
                        for (int j = 0; j < intRow; j++)
                        {
                            index++;
                            cellmeg[index][0] = LocateX[i];
                            cellmeg[index][1] = LocateY[j];
                            cellmeg[index][2] = LocateX[i + 1];
                            cellmeg[index][3] = LocateY[j + 1];
                            cellmeg[index][4] = Convert.ToInt32((LocateX[i] + LocateX[i + 1]) / 2);
                            cellmeg[index][5] = Convert.ToInt32((LocateY[j] + LocateY[j + 1]) / 2);
                        }
                    }
                }
                else
                {
                    cellmeg.Clear();
                    for (int i = 0; i < intCol; i++)
                    {
                        for (int j = 0; j < intRow; j++)
                        {
                            cellmeg.Add(new double[7] { LocateX[i], LocateY[j], LocateX[i + 1], LocateY[j + 1], (LocateX[i] + LocateX[i + 1]) / 2, (LocateY[j] + LocateY[j + 1]) / 2, 0 });
                        }
                    }
                }

                foreach (double[] item in cellmeg)
                {
                    if (item[6] == 1)
                    {
                        Rectangle rectangle = new Rectangle(Convert.ToInt32((item[0] + item[2]) / 2), Convert.ToInt32((item[1] + item[3]) / 2), 2, 2);
                        graphics.DrawArc(penpoint, rectangle, 0, 360);
                    }

                }
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label3.Text = "X:" + (e.X * zoom).ToString("f1") + "\nY:" + (e.Y * zoom).ToString("f1");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}