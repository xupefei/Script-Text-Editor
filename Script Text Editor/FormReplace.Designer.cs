namespace Script_Text_Editor
{
    partial class FormReplace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReplace));
            this.kryptonManager = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.kryptonPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonCheckBoxWithOrg = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.kryptonButtonReplaceAll = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButtonReplace = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButtonPrev = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButtonNext = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.kryptonTextBoxReplace = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBoxFind = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).BeginInit();
            this.kryptonPanel.SuspendLayout();
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
            this.kryptonPanel.Controls.Add(this.kryptonCheckBoxWithOrg);
            this.kryptonPanel.Controls.Add(this.kryptonButtonReplaceAll);
            this.kryptonPanel.Controls.Add(this.kryptonButtonReplace);
            this.kryptonPanel.Controls.Add(this.kryptonButtonPrev);
            this.kryptonPanel.Controls.Add(this.kryptonButtonNext);
            this.kryptonPanel.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel.Controls.Add(this.kryptonTextBoxReplace);
            this.kryptonPanel.Controls.Add(this.kryptonTextBoxFind);
            this.kryptonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel.Name = "kryptonPanel";
            this.kryptonPanel.Size = new System.Drawing.Size(398, 148);
            this.kryptonPanel.TabIndex = 0;
            // 
            // kryptonCheckBoxWithOrg
            // 
            this.kryptonCheckBoxWithOrg.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonCheckBoxWithOrg.Location = new System.Drawing.Point(18, 116);
            this.kryptonCheckBoxWithOrg.Name = "kryptonCheckBoxWithOrg";
            this.kryptonCheckBoxWithOrg.Size = new System.Drawing.Size(150, 20);
            this.kryptonCheckBoxWithOrg.TabIndex = 10;
            this.kryptonCheckBoxWithOrg.Text = "也搜索原文本 (Ctrl + Z)";
            this.kryptonCheckBoxWithOrg.Values.Text = "也搜索原文本 (Ctrl + Z)";
            // 
            // kryptonButtonReplaceAll
            // 
            this.kryptonButtonReplaceAll.Enabled = false;
            this.kryptonButtonReplaceAll.Location = new System.Drawing.Point(254, 111);
            this.kryptonButtonReplaceAll.Name = "kryptonButtonReplaceAll";
            this.kryptonButtonReplaceAll.Size = new System.Drawing.Size(135, 25);
            this.kryptonButtonReplaceAll.TabIndex = 9;
            this.kryptonButtonReplaceAll.Values.Text = "替换全部";
            this.kryptonButtonReplaceAll.Click += new System.EventHandler(this.kryptonButtonReplaceAll_Click);
            // 
            // kryptonButtonReplace
            // 
            this.kryptonButtonReplace.Enabled = false;
            this.kryptonButtonReplace.Location = new System.Drawing.Point(254, 78);
            this.kryptonButtonReplace.Name = "kryptonButtonReplace";
            this.kryptonButtonReplace.Size = new System.Drawing.Size(135, 25);
            this.kryptonButtonReplace.TabIndex = 8;
            this.kryptonButtonReplace.Values.Text = "替换一次";
            this.kryptonButtonReplace.Click += new System.EventHandler(this.kryptonButtonReplace_Click);
            // 
            // kryptonButtonPrev
            // 
            this.kryptonButtonPrev.Enabled = false;
            this.kryptonButtonPrev.Location = new System.Drawing.Point(254, 45);
            this.kryptonButtonPrev.Name = "kryptonButtonPrev";
            this.kryptonButtonPrev.Size = new System.Drawing.Size(135, 25);
            this.kryptonButtonPrev.TabIndex = 7;
            this.kryptonButtonPrev.Values.Image = global::Script_Text_Editor.Properties.Resources.PreviousRecord;
            this.kryptonButtonPrev.Values.Text = "上一个 (Shift-Enter)";
            this.kryptonButtonPrev.Click += new System.EventHandler(this.kryptonButtonPrev_Click);
            // 
            // kryptonButtonNext
            // 
            this.kryptonButtonNext.Enabled = false;
            this.kryptonButtonNext.Location = new System.Drawing.Point(254, 12);
            this.kryptonButtonNext.Name = "kryptonButtonNext";
            this.kryptonButtonNext.Size = new System.Drawing.Size(135, 25);
            this.kryptonButtonNext.TabIndex = 6;
            this.kryptonButtonNext.Values.Image = global::Script_Text_Editor.Properties.Resources.NextRecord;
            this.kryptonButtonNext.Values.Text = "下一个 (Enter)";
            this.kryptonButtonNext.Click += new System.EventHandler(this.kryptonButtonNext_Click);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 64);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(48, 20);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = "替换为";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(73, 20);
            this.kryptonLabel1.TabIndex = 2;
            this.kryptonLabel1.Values.Text = "搜索字符串";
            // 
            // kryptonTextBoxReplace
            // 
            this.kryptonTextBoxReplace.Location = new System.Drawing.Point(12, 90);
            this.kryptonTextBoxReplace.Name = "kryptonTextBoxReplace";
            this.kryptonTextBoxReplace.Size = new System.Drawing.Size(236, 20);
            this.kryptonTextBoxReplace.TabIndex = 1;
            this.kryptonTextBoxReplace.TextChanged += new System.EventHandler(this.kryptonTextBox_TextChanged);
            // 
            // kryptonTextBoxFind
            // 
            this.kryptonTextBoxFind.Location = new System.Drawing.Point(12, 38);
            this.kryptonTextBoxFind.Name = "kryptonTextBoxFind";
            this.kryptonTextBoxFind.Size = new System.Drawing.Size(236, 20);
            this.kryptonTextBoxFind.TabIndex = 0;
            this.kryptonTextBoxFind.TextChanged += new System.EventHandler(this.kryptonTextBox_TextChanged);
            this.kryptonTextBoxFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kryptonTextBoxFind_KeyDown);
            this.kryptonTextBoxFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.kryptonTextBoxFind_KeyPress);
            // 
            // FormReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 148);
            this.Controls.Add(this.kryptonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormReplace";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "查找与替换";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.FormReplace_Activated);
            this.Deactivate += new System.EventHandler(this.FormReplace_Deactivate);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel)).EndInit();
            this.kryptonPanel.ResumeLayout(false);
            this.kryptonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButtonNext;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBoxReplace;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBoxFind;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButtonReplaceAll;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButtonReplace;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButtonPrev;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox kryptonCheckBoxWithOrg;
    }
}

