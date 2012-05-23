namespace Script_Text_Editor
{
    partial class FormSettings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanelAbout = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.labelAbout = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonButtonOK = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButtonCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonPanelFont = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.labelTextNew = new System.Windows.Forms.Label();
            this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labelTextOrg = new System.Windows.Forms.Label();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labelList = new System.Windows.Forms.Label();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanelBitmap = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonLabelBitmap2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pictureBoxBitmap1 = new System.Windows.Forms.PictureBox();
            this.kryptonLabelBitmap1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonTextBoxImage1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonPanelEmpty = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.kryptonListBox1 = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelAbout)).BeginInit();
            this.kryptonPanelAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelFont)).BeginInit();
            this.kryptonPanelFont.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelBitmap)).BeginInit();
            this.kryptonPanelBitmap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBitmap1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelEmpty)).BeginInit();
            this.kryptonPanelEmpty.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonManager
            // 
            this.kryptonManager.GlobalPaletteMode = ComponentFactory.Krypton.Toolkit.PaletteModeManager.Office2010Silver;
            this.kryptonManager.GlobalStrings.Abort = "中止";
            this.kryptonManager.GlobalStrings.Cancel = "取消";
            this.kryptonManager.GlobalStrings.Close = "关闭";
            this.kryptonManager.GlobalStrings.Ignore = "忽略";
            this.kryptonManager.GlobalStrings.No = "否";
            this.kryptonManager.GlobalStrings.OK = "是";
            this.kryptonManager.GlobalStrings.Retry = "重试";
            this.kryptonManager.GlobalStrings.Today = "今天";
            this.kryptonManager.GlobalStrings.Yes = "是";
            // 
            // kryptonPanel
            // 
            this.kryptonPanel.Controls.Add(this.kryptonPanelAbout);
            this.kryptonPanel.Controls.Add(this.kryptonButtonOK);
            this.kryptonPanel.Controls.Add(this.kryptonButtonCancel);
            this.kryptonPanel.Controls.Add(this.kryptonPanelFont);
            this.kryptonPanel.Controls.Add(this.kryptonPanelBitmap);
            this.kryptonPanel.Controls.Add(this.kryptonPanelEmpty);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(84, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(345, 255);
            this.kryptonPanel.TabIndex = 0;
            // 
            // kryptonPanelAbout
            // 
            this.kryptonPanelAbout.Controls.Add(this.labelAbout);
            this.kryptonPanelAbout.Controls.Add(this.pictureBox1);
            this.kryptonPanelAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanelAbout.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanelAbout.Name = "kryptonPanelAbout";
            this.kryptonPanelAbout.Size = new System.Drawing.Size(345, 213);
            this.kryptonPanelAbout.TabIndex = 7;
            this.kryptonPanelAbout.Visible = false;
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.BackColor = System.Drawing.Color.Transparent;
            this.labelAbout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.labelAbout.Location = new System.Drawing.Point(177, 3);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(165, 30);
            this.labelAbout.TabIndex = 1;
            this.labelAbout.Text = "Script Text Editor by Paddy Xu\r\nBuild ";
            this.labelAbout.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Script_Text_Editor.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(345, 213);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonButtonOK
            // 
            this.kryptonButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kryptonButtonOK.Location = new System.Drawing.Point(130, 219);
            this.kryptonButtonOK.Name = "kryptonButtonOK";
            this.kryptonButtonOK.Size = new System.Drawing.Size(90, 25);
            this.kryptonButtonOK.TabIndex = 7;
            this.kryptonButtonOK.Values.Text = "保存修改";
            this.kryptonButtonOK.Click += new System.EventHandler(this.kryptonButtonOK_Click);
            // 
            // kryptonButtonCancel
            // 
            this.kryptonButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonButtonCancel.Location = new System.Drawing.Point(238, 219);
            this.kryptonButtonCancel.Name = "kryptonButtonCancel";
            this.kryptonButtonCancel.Size = new System.Drawing.Size(90, 25);
            this.kryptonButtonCancel.TabIndex = 8;
            this.kryptonButtonCancel.Values.Text = "放弃修改";
            this.kryptonButtonCancel.Click += new System.EventHandler(this.kryptonButtonCancel_Click);
            // 
            // kryptonPanelFont
            // 
            this.kryptonPanelFont.Controls.Add(this.labelTextNew);
            this.kryptonPanelFont.Controls.Add(this.kryptonLabel4);
            this.kryptonPanelFont.Controls.Add(this.labelTextOrg);
            this.kryptonPanelFont.Controls.Add(this.kryptonLabel2);
            this.kryptonPanelFont.Controls.Add(this.labelList);
            this.kryptonPanelFont.Controls.Add(this.kryptonLabel1);
            this.kryptonPanelFont.Location = new System.Drawing.Point(3, 3);
            this.kryptonPanelFont.Name = "kryptonPanelFont";
            this.kryptonPanelFont.Size = new System.Drawing.Size(105, 213);
            this.kryptonPanelFont.TabIndex = 0;
            this.kryptonPanelFont.Visible = false;
            // 
            // labelTextNew
            // 
            this.labelTextNew.BackColor = System.Drawing.Color.Transparent;
            this.labelTextNew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTextNew.Location = new System.Drawing.Point(6, 165);
            this.labelTextNew.Name = "labelTextNew";
            this.labelTextNew.Size = new System.Drawing.Size(336, 39);
            this.labelTextNew.TabIndex = 6;
            this.labelTextNew.Text = "呵呵，开个玩笑 :-)\r\n单击这里选择字体……";
            this.labelTextNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTextNew.Click += new System.EventHandler(this.labelTextNew_Click);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(6, 142);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel4.TabIndex = 5;
            this.kryptonLabel4.Values.Text = "新文本字体";
            // 
            // labelTextOrg
            // 
            this.labelTextOrg.BackColor = System.Drawing.Color.Transparent;
            this.labelTextOrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelTextOrg.Location = new System.Drawing.Point(6, 100);
            this.labelTextOrg.Name = "labelTextOrg";
            this.labelTextOrg.Size = new System.Drawing.Size(336, 39);
            this.labelTextOrg.TabIndex = 4;
            this.labelTextOrg.Text = "大事なのは、美しいことではない。\r\n美しくあろうとすることだ。";
            this.labelTextOrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTextOrg.Click += new System.EventHandler(this.labelTextOrg_Click);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(6, 77);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "原文本字体";
            // 
            // labelList
            // 
            this.labelList.BackColor = System.Drawing.Color.Transparent;
            this.labelList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelList.Location = new System.Drawing.Point(6, 35);
            this.labelList.Name = "labelList";
            this.labelList.Size = new System.Drawing.Size(336, 39);
            this.labelList.TabIndex = 2;
            this.labelList.Text = "DOTA毁一生，网游穷三代。\r\n天天上自习，必成高富帅！";
            this.labelList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelList.Click += new System.EventHandler(this.labelList_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(6, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "列表项字体";
            // 
            // kryptonPanelBitmap
            // 
            this.kryptonPanelBitmap.Controls.Add(this.kryptonLabelBitmap2);
            this.kryptonPanelBitmap.Controls.Add(this.pictureBoxBitmap1);
            this.kryptonPanelBitmap.Controls.Add(this.kryptonLabelBitmap1);
            this.kryptonPanelBitmap.Controls.Add(this.kryptonTextBoxImage1);
            this.kryptonPanelBitmap.Controls.Add(this.kryptonLabel3);
            this.kryptonPanelBitmap.Location = new System.Drawing.Point(111, 3);
            this.kryptonPanelBitmap.Name = "kryptonPanelBitmap";
            this.kryptonPanelBitmap.Size = new System.Drawing.Size(124, 213);
            this.kryptonPanelBitmap.TabIndex = 5;
            this.kryptonPanelBitmap.Visible = false;
            // 
            // kryptonLabelBitmap2
            // 
            this.kryptonLabelBitmap2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonLabelBitmap2.Location = new System.Drawing.Point(269, 35);
            this.kryptonLabelBitmap2.Name = "kryptonLabelBitmap2";
            this.kryptonLabelBitmap2.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabelBitmap2.TabIndex = 13;
            this.kryptonLabelBitmap2.Values.Text = "恢复为默认";
            this.kryptonLabelBitmap2.Click += new System.EventHandler(this.kryptonLabelBitmap2_Click);
            // 
            // pictureBoxBitmap1
            // 
            this.pictureBoxBitmap1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBitmap1.Location = new System.Drawing.Point(6, 62);
            this.pictureBoxBitmap1.Name = "pictureBoxBitmap1";
            this.pictureBoxBitmap1.Size = new System.Drawing.Size(336, 139);
            this.pictureBoxBitmap1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBitmap1.TabIndex = 12;
            this.pictureBoxBitmap1.TabStop = false;
            // 
            // kryptonLabelBitmap1
            // 
            this.kryptonLabelBitmap1.AutoSize = false;
            this.kryptonLabelBitmap1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kryptonLabelBitmap1.Location = new System.Drawing.Point(243, 35);
            this.kryptonLabelBitmap1.Name = "kryptonLabelBitmap1";
            this.kryptonLabelBitmap1.Size = new System.Drawing.Size(20, 20);
            this.kryptonLabelBitmap1.TabIndex = 11;
            this.kryptonLabelBitmap1.Values.Text = "...";
            this.kryptonLabelBitmap1.Click += new System.EventHandler(this.kryptonLabelBitmap1_Click);
            // 
            // kryptonTextBoxImage1
            // 
            this.kryptonTextBoxImage1.Location = new System.Drawing.Point(6, 35);
            this.kryptonTextBoxImage1.Name = "kryptonTextBoxImage1";
            this.kryptonTextBoxImage1.Size = new System.Drawing.Size(231, 20);
            this.kryptonTextBoxImage1.TabIndex = 10;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(60, 20);
            this.kryptonLabel3.TabIndex = 0;
            this.kryptonLabel3.Values.Text = "背景图片";
            // 
            // kryptonPanelEmpty
            // 
            this.kryptonPanelEmpty.Controls.Add(this.label1);
            this.kryptonPanelEmpty.Location = new System.Drawing.Point(244, 3);
            this.kryptonPanelEmpty.Name = "kryptonPanelEmpty";
            this.kryptonPanelEmpty.Size = new System.Drawing.Size(89, 213);
            this.kryptonPanelEmpty.TabIndex = 6;
            this.kryptonPanelEmpty.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.Location = new System.Drawing.Point(106, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "未完成\r\n请自行修改配置文件……";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kryptonListBox1
            // 
            this.kryptonListBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonListBox1.Items.AddRange(new object[] {
            "字体",
            "图片",
            "目录",
            "设置",
            "关于"});
            this.kryptonListBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonListBox1.Name = "kryptonListBox1";
            this.kryptonListBox1.Size = new System.Drawing.Size(84, 255);
            this.kryptonListBox1.TabIndex = 1;
            this.kryptonListBox1.SelectedIndexChanged += new System.EventHandler(this.kryptonListBox1_SelectedIndexChanged);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 255);
            this.Controls.Add(this.kryptonPanel);
            this.Controls.Add(this.kryptonListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelAbout)).EndInit();
            this.kryptonPanelAbout.ResumeLayout(false);
            this.kryptonPanelAbout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelFont)).EndInit();
            this.kryptonPanelFont.ResumeLayout(false);
            this.kryptonPanelFont.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelBitmap)).EndInit();
            this.kryptonPanelBitmap.ResumeLayout(false);
            this.kryptonPanelBitmap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBitmap1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanelEmpty)).EndInit();
            this.kryptonPanelEmpty.ResumeLayout(false);
            this.kryptonPanelEmpty.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox kryptonListBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanelFont;
        private System.Windows.Forms.Label labelTextNew;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private System.Windows.Forms.Label labelTextOrg;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private System.Windows.Forms.Label labelList;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanelBitmap;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabelBitmap2;
        private System.Windows.Forms.PictureBox pictureBoxBitmap1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabelBitmap1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBoxImage1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanelEmpty;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButtonCancel;
        private System.Windows.Forms.Label label1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButtonOK;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanelAbout;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

