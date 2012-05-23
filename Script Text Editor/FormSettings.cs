using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Script_Text_Editor
{
    public partial class FormSettings : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void labelList_Click(object sender, EventArgs e)
        {
            var fd = new FontDialog
                         {
                             ShowColor = true,
                             Font = labelList.Font,
                             Color = labelList.ForeColor,
                         };
            if (fd.ShowDialog() == DialogResult.No)
                return;

            labelList.Font = fd.Font;
            labelList.ForeColor = fd.Color;
        }

        private void labelTextOrg_Click(object sender, EventArgs e)
        {
            var fd = new FontDialog
            {
                ShowColor = false,
                Font = labelTextOrg.Font,
                Color = labelTextOrg.ForeColor,
            };
            if (fd.ShowDialog() == DialogResult.No)
                return;

            labelTextOrg.Font = fd.Font;
            labelTextOrg.ForeColor = fd.Color;
        }

        private void labelTextNew_Click(object sender, EventArgs e)
        {
            var fd = new FontDialog
            {
                ShowColor = true,
                Font = labelTextNew.Font,
                Color = labelTextNew.ForeColor,
            };
            if (fd.ShowDialog() == DialogResult.No)
                return;

            labelTextNew.Font = fd.Font;
            labelTextNew.ForeColor = fd.Color;
        }

        private void kryptonLabelBitmap1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
                          {
                              Filter = "Bitmap|*.jpg;*.png",
                          };
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                kryptonTextBoxImage1.Text = ofd.FileName;
                pictureBoxBitmap1.Image = new Bitmap(ofd.FileName);
            }
            catch
            {
                KryptonMessageBox.Show("背景图片格式无效。");
            }
        }

        private void kryptonListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (kryptonListBox1.SelectedIndex)
            {
                case 0:
                    kryptonPanelFont.Dock = DockStyle.Top;
                    kryptonPanelFont.Visible = true;
                    kryptonPanelBitmap.Visible = false;
                    kryptonPanelAbout.Visible = false;
                    kryptonPanelEmpty.Visible = false;
                    break;
                case 1:
                    kryptonPanelBitmap.Dock = DockStyle.Top;
                    kryptonPanelFont.Visible = false;
                    kryptonPanelBitmap.Visible = true;
                    kryptonPanelAbout.Visible = false;
                    kryptonPanelEmpty.Visible = false;
                    break;
                case 4:
                    kryptonPanelBitmap.Dock = DockStyle.Top;
                    kryptonPanelFont.Visible = false;
                    kryptonPanelBitmap.Visible = false;
                    kryptonPanelAbout.Visible = true;
                    kryptonPanelEmpty.Visible = false;
                    break;
                default:
                    kryptonPanelEmpty.Dock = DockStyle.Top;
                    kryptonPanelFont.Visible = false;
                    kryptonPanelBitmap.Visible = false;
                    kryptonPanelAbout.Visible = false;
                    kryptonPanelEmpty.Visible = true;
                    break;
            }
        }

        private void kryptonLabelBitmap2_Click(object sender, EventArgs e)
        {
            kryptonTextBoxImage1.Text = "";
            pictureBoxBitmap1.Image = null;
        }

        private void kryptonButtonOK_Click(object sender, EventArgs e)
        {
            Utilities.ChangeSetting("ListFont",
                                    labelList.Font.Name + ", " + labelList.Font.Size + "pt");
            Utilities.ChangeSetting("TextBoxFontOrg",
                                    labelTextOrg.Font.Name + ", " + labelTextOrg.Font.Size + "pt");
            Utilities.ChangeSetting("TextBoxFontNew",
                                    labelTextNew.Font.Name + ", " + labelTextNew.Font.Size + "pt");
            Utilities.ChangeSetting("ListColor",
                                    string.Format("{0},{1},{2}",
                                                  labelList.ForeColor.R.ToString(),
                                                  labelList.ForeColor.G.ToString(),
                                                  labelList.ForeColor.B.ToString()));
            Utilities.ChangeSetting("TextBoxColor",
                                    string.Format("{0},{1},{2}",
                                                  labelTextNew.ForeColor.R.ToString(),
                                                  labelTextNew.ForeColor.G.ToString(),
                                                  labelTextNew.ForeColor.B.ToString()));
            Utilities.ChangeSetting("BackgroundImage", kryptonTextBoxImage1.Text);
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            labelAbout.Text += Application.ProductVersion;

            labelList.Font = Properties.Settings.Default.ListFont;
            labelTextOrg.Font = Properties.Settings.Default.TextBoxFontOrg;
            labelTextNew.Font = Properties.Settings.Default.TextBoxFontNew;
            labelList.ForeColor = Properties.Settings.Default.ListColor;
            labelTextNew.ForeColor = Properties.Settings.Default.TextBoxColor;
            kryptonTextBoxImage1.Text = Properties.Settings.Default.BackgroundImage;
            try
            {
                pictureBoxBitmap1.Image = new Bitmap(Properties.Settings.Default.BackgroundImage);
            }
            catch { }

            kryptonListBox1.SelectedIndex = 0;
        }

        private void kryptonButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}