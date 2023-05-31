namespace text1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            panel_tool = new Panel();
            btn_cleanwindow = new Button();
            btn_readImage = new Button();
            btn_leftup = new Button();
            tb_col = new TextBox();
            btn_rightup = new Button();
            tb_row = new TextBox();
            btn_leftdown = new Button();
            label2 = new Label();
            btn_rightdown = new Button();
            label1 = new Label();
            btn_exportJson = new Button();
            btn_drawPoint = new Button();
            btn_genGrid = new Button();
            label_rightdown = new Label();
            label_stateOut = new Label();
            label_stateIn = new Label();
            label_leftup = new Label();
            label_leftdown = new Label();
            label3 = new Label();
            label_rightup = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel_tool.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(panel_tool);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 484);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(504, 440);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.MouseDoubleClick += pictureBox1_MouseDoubleClick;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // panel_tool
            // 
            panel_tool.Controls.Add(btn_cleanwindow);
            panel_tool.Controls.Add(btn_readImage);
            panel_tool.Controls.Add(btn_leftup);
            panel_tool.Controls.Add(tb_col);
            panel_tool.Controls.Add(btn_rightup);
            panel_tool.Controls.Add(tb_row);
            panel_tool.Controls.Add(btn_leftdown);
            panel_tool.Controls.Add(label2);
            panel_tool.Controls.Add(btn_rightdown);
            panel_tool.Controls.Add(label1);
            panel_tool.Controls.Add(btn_exportJson);
            panel_tool.Controls.Add(btn_drawPoint);
            panel_tool.Controls.Add(btn_genGrid);
            panel_tool.Controls.Add(label_rightdown);
            panel_tool.Controls.Add(label_stateOut);
            panel_tool.Controls.Add(label_stateIn);
            panel_tool.Controls.Add(label_leftup);
            panel_tool.Controls.Add(label_leftdown);
            panel_tool.Controls.Add(label3);
            panel_tool.Controls.Add(label_rightup);
            panel_tool.Location = new Point(513, 3);
            panel_tool.Name = "panel_tool";
            panel_tool.Size = new Size(250, 478);
            panel_tool.TabIndex = 5;
            // 
            // btn_cleanwindow
            // 
            btn_cleanwindow.Location = new Point(145, 56);
            btn_cleanwindow.Name = "btn_cleanwindow";
            btn_cleanwindow.Size = new Size(88, 52);
            btn_cleanwindow.TabIndex = 1;
            btn_cleanwindow.Text = "清空窗体";
            btn_cleanwindow.UseVisualStyleBackColor = true;
            btn_cleanwindow.Click += btn_cleanwindow_Click;
            // 
            // btn_readImage
            // 
            btn_readImage.Location = new Point(13, 56);
            btn_readImage.Name = "btn_readImage";
            btn_readImage.Size = new Size(92, 52);
            btn_readImage.TabIndex = 1;
            btn_readImage.Text = "导入图片";
            btn_readImage.UseVisualStyleBackColor = true;
            btn_readImage.Click += btn_readImage_Click;
            // 
            // btn_leftup
            // 
            btn_leftup.BackColor = SystemColors.ControlLight;
            btn_leftup.Location = new Point(13, 114);
            btn_leftup.Name = "btn_leftup";
            btn_leftup.Size = new Size(77, 31);
            btn_leftup.TabIndex = 1;
            btn_leftup.Text = "左上";
            btn_leftup.UseVisualStyleBackColor = false;
            btn_leftup.Click += btn_leftup_Click;
            // 
            // tb_col
            // 
            tb_col.Location = new Point(166, 262);
            tb_col.Name = "tb_col";
            tb_col.Size = new Size(67, 23);
            tb_col.TabIndex = 3;
            // 
            // btn_rightup
            // 
            btn_rightup.BackColor = SystemColors.ControlLight;
            btn_rightup.Location = new Point(13, 225);
            btn_rightup.Name = "btn_rightup";
            btn_rightup.Size = new Size(77, 31);
            btn_rightup.TabIndex = 1;
            btn_rightup.Text = "右上";
            btn_rightup.UseVisualStyleBackColor = false;
            btn_rightup.Click += btn_rightup_Click;
            // 
            // tb_row
            // 
            tb_row.Location = new Point(40, 262);
            tb_row.Name = "tb_row";
            tb_row.Size = new Size(65, 23);
            tb_row.TabIndex = 3;
            // 
            // btn_leftdown
            // 
            btn_leftdown.BackColor = SystemColors.ControlLight;
            btn_leftdown.Location = new Point(13, 151);
            btn_leftdown.Name = "btn_leftdown";
            btn_leftdown.Size = new Size(77, 31);
            btn_leftdown.TabIndex = 1;
            btn_leftdown.Text = "左下";
            btn_leftdown.UseVisualStyleBackColor = false;
            btn_leftdown.Click += btn_leftdown_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(129, 265);
            label2.Name = "label2";
            label2.Size = new Size(31, 17);
            label2.TabIndex = 2;
            label2.Text = "cols";
            // 
            // btn_rightdown
            // 
            btn_rightdown.BackColor = SystemColors.ControlLight;
            btn_rightdown.Location = new Point(13, 188);
            btn_rightdown.Name = "btn_rightdown";
            btn_rightdown.Size = new Size(77, 31);
            btn_rightdown.TabIndex = 1;
            btn_rightdown.Text = "右下";
            btn_rightdown.UseVisualStyleBackColor = false;
            btn_rightdown.Click += btn_rightdown_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 265);
            label1.Name = "label1";
            label1.Size = new Size(36, 17);
            label1.TabIndex = 2;
            label1.Text = "rows";
            // 
            // btn_exportJson
            // 
            btn_exportJson.BackColor = SystemColors.ControlLight;
            btn_exportJson.ForeColor = SystemColors.ControlText;
            btn_exportJson.Location = new Point(13, 365);
            btn_exportJson.Name = "btn_exportJson";
            btn_exportJson.Size = new Size(92, 52);
            btn_exportJson.TabIndex = 1;
            btn_exportJson.Text = "导出json文件";
            btn_exportJson.UseVisualStyleBackColor = false;
            btn_exportJson.Click += btn_exportJson_Click;
            // 
            // btn_drawPoint
            // 
            btn_drawPoint.BackColor = SystemColors.ControlLight;
            btn_drawPoint.Location = new Point(13, 328);
            btn_drawPoint.Name = "btn_drawPoint";
            btn_drawPoint.Size = new Size(77, 31);
            btn_drawPoint.TabIndex = 1;
            btn_drawPoint.Text = "开始画点";
            btn_drawPoint.UseVisualStyleBackColor = false;
            btn_drawPoint.Click += btn_drawPoint_Click;
            // 
            // btn_genGrid
            // 
            btn_genGrid.BackColor = SystemColors.ControlLight;
            btn_genGrid.Location = new Point(13, 291);
            btn_genGrid.Name = "btn_genGrid";
            btn_genGrid.Size = new Size(77, 31);
            btn_genGrid.TabIndex = 1;
            btn_genGrid.Text = "生成表格";
            btn_genGrid.UseVisualStyleBackColor = false;
            btn_genGrid.Click += btn_genGrid_Click;
            // 
            // label_rightdown
            // 
            label_rightdown.AutoSize = true;
            label_rightdown.Location = new Point(118, 195);
            label_rightdown.Name = "label_rightdown";
            label_rightdown.Size = new Size(43, 17);
            label_rightdown.TabIndex = 2;
            label_rightdown.Text = "label1";
            // 
            // label_stateOut
            // 
            label_stateOut.AutoSize = true;
            label_stateOut.ForeColor = SystemColors.ControlText;
            label_stateOut.Location = new Point(13, 420);
            label_stateOut.Name = "label_stateOut";
            label_stateOut.Size = new Size(43, 17);
            label_stateOut.TabIndex = 2;
            label_stateOut.Text = "label1";
            // 
            // label_stateIn
            // 
            label_stateIn.AutoSize = true;
            label_stateIn.Location = new Point(13, 6);
            label_stateIn.Name = "label_stateIn";
            label_stateIn.Size = new Size(43, 17);
            label_stateIn.TabIndex = 2;
            label_stateIn.Text = "label1";
            // 
            // label_leftup
            // 
            label_leftup.AutoSize = true;
            label_leftup.Location = new Point(118, 121);
            label_leftup.Name = "label_leftup";
            label_leftup.Size = new Size(43, 17);
            label_leftup.TabIndex = 2;
            label_leftup.Text = "label1";
            // 
            // label_leftdown
            // 
            label_leftdown.AutoSize = true;
            label_leftdown.Location = new Point(118, 158);
            label_leftdown.Name = "label_leftdown";
            label_leftdown.Size = new Size(43, 17);
            label_leftdown.TabIndex = 2;
            label_leftdown.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(190, 328);
            label3.Name = "label3";
            label3.Size = new Size(43, 17);
            label3.TabIndex = 2;
            label3.Text = "label1";
            // 
            // label_rightup
            // 
            label_rightup.AutoSize = true;
            label_rightup.Location = new Point(118, 232);
            label_rightup.Name = "label_rightup";
            label_rightup.Size = new Size(43, 17);
            label_rightup.TabIndex = 2;
            label_rightup.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(776, 484);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel_tool.ResumeLayout(false);
            panel_tool.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button btn_readImage;
        private Button btn_rightdown;
        private Button btn_leftdown;
        private Button btn_rightup;
        private Button btn_leftup;
        private Label label_leftup;
        private Label label_rightdown;
        private Label label_leftdown;
        private Label label_rightup;
        private Button btn_genGrid;
        private TextBox tb_col;
        private TextBox tb_row;
        private Label label2;
        private Label label1;
        private Panel panel_tool;
        private PictureBox pictureBox1;
        private Button btn_drawPoint;
        private Button btn_cleanwindow;
        private Button btn_exportJson;
        private Label label_stateIn;
        private Label label_stateOut;
        private Label label3;
    }
}