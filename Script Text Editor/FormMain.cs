using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Script_Text_Editor.Data;

namespace Script_Text_Editor
{
    public partial class FormMain : KryptonForm
    {
        private TextData _textData = new TextData();
        private bool _isModified;
        private int _currentCount;
        private int _autoSaveCount;
        private TimeSpan _currentTime;
        private TimeSpan _totalTime;

        #region WndProc

        private const int WM_CTLCOLOREDIT = 0x0133;
        private const int TRANSPARENT = 0x1;
        private const int NULL_BRUSH = 0x5;

        [DllImport("gdi32")]
        private static extern int SetBkMode(IntPtr hdc, int bkMode);

        [DllImport("gdi32")]
        private static extern int SetTextColor(IntPtr hdc, int color);

        [DllImport("gdi32")]
        private static extern IntPtr GetStockObject(int fnobject);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CTLCOLOREDIT && (m.LParam == textBoxNewText.Handle || m.LParam == textBoxOrgText.Handle))
            {
                SetBkMode(m.WParam, TRANSPARENT);
                SetTextColor(m.WParam, ColorTranslator.ToWin32(Properties.Settings.Default.TextBoxColor));
                m.Result = GetStockObject(NULL_BRUSH);
                return;
            }
            base.WndProc(ref m);
        }

        #endregion WndProc

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(Properties.Settings.Default.BackgroundImage))
                    BackgroundImage = new Bitmap(Properties.Settings.Default.BackgroundImage);
            }
            catch { }

            Location = Properties.Settings.Default.WindowLocation;
            Size = Properties.Settings.Default.WindowSize;

            textBoxNewText.SetBackImage();
            textBoxOrgText.SetBackImage();

            dataGridViewText.StateCommon.DataCell.Content.Font = Properties.Settings.Default.ListFont;
            dataGridViewText.StateCommon.DataCell.Content.Color1 = Properties.Settings.Default.ListColor;

            dataGridViewText.AutoGenerateColumns = false;
            dataGridViewText.DataSource = _textData.DataTable.DefaultView;

            textBoxOrgText.Font = Properties.Settings.Default.TextBoxFontOrg;
            textBoxNewText.Font = Properties.Settings.Default.TextBoxFontNew;

            SetTitle(null);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_isModified)
                if (KryptonMessageBox.Show(
                    "文件已修改，但没有保存。\r\n确定要退出吗？",
                    "",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2)
                    == DialogResult.No)
                    e.Cancel = true;

            Utilities.ChangeSetting("WindowLocation", Location.X.ToString() + ", " + Location.Y.ToString());
            Utilities.ChangeSetting("WindowSize", Size.Width.ToString() + ", " + Size.Height.ToString());
        }

        private void CheckAutoSave()
        {
            _autoSaveCount++;

            if (_autoSaveCount >= Properties.Settings.Default.AutoSaveDuration)
            {
                SavedTranslationFormatProvider.MakeSavedTranslation(
                    Utilities.GetAbsolutePath(
                        Properties.Settings.Default.AutoSavePath + "\\"
                        + Path.GetFileNameWithoutExtension(_textData.Filename) + ".sav"),
                    _textData.Filename,
                    _textData.Library.GetLibraryInfo(),
                    _totalTime,
                    _textData.Library.GetDefaultEncoding(),
                    dataGridViewText.FirstSelectedRowIndex,
                    _textData.GetLineInfoAll()
                    );

                _autoSaveCount = 0;
            }
        }

        private void SetTitle(string append)
        {
            Text = String.IsNullOrEmpty(append)
                       ? _textData.Library.GetLibraryInfo()
                       : string.Format("[{0}] {1}", append, _textData.Library.GetLibraryInfo());
        }

        private void kryptonCommandNew_Execute(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = string.Format("*.{0}|*.{0}", _textData.Library.GetSupportExtension()),
                InitialDirectory = Utilities.GetAbsolutePath(Properties.Settings.Default.ScriptPath),
            };
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            _isModified = false;
            _textData.OpenScript(ofd.FileName);

            _currentTime = TimeSpan.Zero;

            textBoxNewText.Focus();
        }

        private void kryptonCommandOpen_Execute(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "*.txt;*.sav;*.autosave|*.txt;*.sav;*.autosave",
                FileName = Path.GetFileName(_textData.Filename),
                InitialDirectory = Utilities.GetAbsolutePath(Properties.Settings.Default.SavedPath),
            };
            if (ofd.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                var stfp = new SavedTranslationFormatProvider(ofd.FileName);
                var file = CheckFileExists(stfp.ScriptPath);

                if (String.IsNullOrEmpty(file))
                {
                    KryptonMessageBox.Show("无法找到对应的脚本文件。");
                    return;
                }

                _totalTime = stfp.TotalTime;

                _textData.LoadTranslation(file, stfp.Lines);

                _isModified = false;
                //goto last modified-line
                dataGridViewText.FirstSelectedRowIndex = stfp.LastLine;
                dataGridViewText.MakeSelectedLineToCenterScreen();

                _currentTime = TimeSpan.Zero;

                textBoxNewText.Focus();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void kryptonCommandSave_Execute(object sender, EventArgs e)
        {
            if (!_textData.IsOpened)
                return;

            var sfd = new SaveFileDialog
            {
                Filter = "*.sav|*.sav",
                FileName = Path.GetFileName(_textData.Filename) + ".sav",
                InitialDirectory = Utilities.GetAbsolutePath(Properties.Settings.Default.SavedPath),
            };

            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;

            SavedTranslationFormatProvider.MakeSavedTranslation(
                sfd.FileName,
                _textData.Filename,
                _textData.Library.GetLibraryInfo(),
                _totalTime,
                _textData.Library.GetDefaultEncoding(),
                dataGridViewText.FirstSelectedRowIndex,
                _textData.GetLineInfoAll()
                );

            _isModified = false;
        }

        private void kryptonCommandBuild_Execute(object sender, EventArgs e)
        {
            if (!_textData.IsOpened)
                return;

            var sfd = new SaveFileDialog
            {
                Filter = string.Format("*.{0}|*.{0}", _textData.Library.GetSupportExtension()),
                FileName = Path.GetFileName(_textData.Filename),
                InitialDirectory = Utilities.GetAbsolutePath(Properties.Settings.Default.NewScriptPath),
            };

            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;

            _textData.BuildScript(sfd.FileName);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!_textData.IsOpened)
                return;

            _currentTime += new TimeSpan(0, 0, 1);
            _totalTime += new TimeSpan(0, 0, 1);
        }

        private void FormMain_SizeChanged(object sender, EventArgs e)
        {
            textBoxNewText.SetBackImage();
            textBoxOrgText.SetBackImage();
        }

        private void dataGridViewText_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewText.FirstSelectedRowIndex == -1)
                return;

            textBoxOrgText.Text = _textData.GetOrgTextAt(dataGridViewText.FirstSelectedRowIndex);
            textBoxNewText.Text = _textData.GetNewTextAt(dataGridViewText.FirstSelectedRowIndex);
        }

        private void textBoxNewText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Down)//Prev
            {
                dataGridViewText.SelectNextLine();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Up)//Next
            {
                dataGridViewText.SelectPrevLine();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Return)//Ctrl + Enter
            {
                _isModified = true;
                if (!Properties.Settings.Default.OnEnterGotoNext)
                {
                    _textData.SaveLineAt(dataGridViewText.FirstSelectedRowIndex, textBoxNewText.Text);
                    CheckAutoSave();
                    _currentCount++;

                    dataGridViewText.SelectNextLine();
                    e.Handled = true;
                }
                else
                    if (_textData.Library.AllowCRLF() == 1)
                    {
                        textBoxNewText.SelectedText = "\r\n";
                    }
            }
            else if (e.Control && e.KeyCode == Keys.A)//Ctrl + A
            {
                textBoxNewText.SelectAll();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.N)//Ctrl + N
            {
                kryptonCommandNew_Execute(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.O)//Ctrl + O
            {
                kryptonCommandOpen_Execute(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.S)//Ctrl + S
            {
                kryptonCommandSave_Execute(sender, e);
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.F)//Ctrl + F
            {
                kryptonCommandReplace_Execute(sender, e);
                e.Handled = true;
            }
            else if (!e.Control && e.KeyCode == Keys.Return)//Enter
            {
                _isModified = true;
                if (Properties.Settings.Default.OnEnterGotoNext)
                {
                    _textData.SaveLineAt(dataGridViewText.FirstSelectedRowIndex, textBoxNewText.Text);
                    CheckAutoSave();
                    _currentCount++;

                    dataGridViewText.SelectNextLine();
                    e.Handled = true;
                }
                else
                    if (_textData.Library.AllowCRLF() == 1)
                    {
                        textBoxNewText.SelectedText = "\r\n";
                    }
            }
        }

        private void textBoxNewText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
            }
            else if (e.KeyChar == '\n')
            {
                e.Handled = true;
            }
        }

        private string CheckFileExists(string filename)
        {
            if (File.Exists(filename))
                return filename;

            if (_textData.IsOpened && Path.GetFileName(_textData.Filename) == Path.GetFileName(filename))
                return filename;

            string baseDir = Utilities.GetAbsolutePath(Properties.Settings.Default.ScriptPath);

            var files = Directory.GetFiles(baseDir, Path.GetFileName(filename), SearchOption.AllDirectories);
            if (files.Length == 0)
                return null;

            var ktd = new KryptonTaskDialog
            {
                Icon = MessageBoxIcon.Information,
                CommonButtons = TaskDialogButtons.Cancel,
                WindowTitle = "看上去这个存档中记录的路径信息不太正确",
                MainInstruction = "不过，下面这个文件可能是正确的　：",
                Content = Utilities.GetRelativePath(files[0], Utilities.GetAbsolutePath("")),
            };

            var ktdcOk = new KryptonTaskDialogCommand
            {
                DialogResult = DialogResult.OK,
                Image = Properties.Resources.arrow_right_green,
                Text = "好，就用这个",
            };
            var ktdcNo = new KryptonTaskDialogCommand
            {
                DialogResult = DialogResult.Cancel,
                Image = Properties.Resources.arrow_right_red,
                Text = "不，这个是错误的",
            };

            ktd.CommandButtons.AddRange(new[] { ktdcOk, ktdcNo });
            if (ktd.ShowDialog() == DialogResult.OK)
                return files[0];

            return null;
        }

        private void kryptonContextMenu1_Opening(object sender, CancelEventArgs e)
        {
            kryptonContextMenuItem11.ExtraText = _currentTime.ToString();
            kryptonContextMenuItem12.ExtraText = _textData.IsOpened ? _textData.DataTable.Rows.Count.ToString() : "0";
            kryptonContextMenuItem15.ExtraText = _textData.IsOpened ? Path.GetFileName(_textData.Filename) : "空";
            kryptonContextMenuItem16.ExtraText = _textData.IsOpened ? _currentCount.ToString() : "0";
            kryptonContextMenuItem18.ExtraText = _totalTime.ToString();
        }

        private void kryptonCommandReplace_Execute(object sender, EventArgs e)
        {
            if (_textData.IsOpened)
            {
                var formReplace = new FormReplace(_textData.DataTable, dataGridViewText)
                {
                    Top = Top + 200,
                    Left = Left + 200
                };
                formReplace.Show();
            }
        }

        private void kryptonCommandMark_Execute(object sender, EventArgs e)
        {
            if (_textData.IsOpened)
                dataGridViewText.MarkCurrentLine();
        }

        private void kryptonCommandUnmark_Execute(object sender, EventArgs e)
        {
            if (_textData.IsOpened)
                dataGridViewText.ClearCurrentLineMark();
        }

        private void kryptonCommandEraseAll_Execute(object sender, EventArgs e)
        {
            if (_textData.IsOpened)
                dataGridViewText.ClearAllMarks();
        }

        private void kryptonCommandPrevMark_Execute(object sender, EventArgs e)
        {
            if (_textData.IsOpened)
                dataGridViewText.GotoPrevMarkedLine();
        }

        private void kryptonCommandNextMark_Execute(object sender, EventArgs e)
        {
            if (_textData.IsOpened)
                dataGridViewText.GotoNextMarkedLine();
        }

        private void kryptonCommandBatchOutput_Execute(object sender, EventArgs e)
        {
            var formBatchInputOutput = new FormBatchInputOutput
                                           {
                                               Top = Top + 200,
                                               Left = Left + 200
                                           };
            formBatchInputOutput.Show();
        }

        private void dataGridViewText_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxNewText.Focus();
        }

        private void kryptonCommandSetting_Execute(object sender, EventArgs e)
        {
            var formSettings = new FormSettings();
            if (formSettings.ShowDialog() == DialogResult.Cancel)
                return;

            dataGridViewText.StateCommon.DataCell.Content.Font = Properties.Settings.Default.ListFont;
            textBoxOrgText.Font = Properties.Settings.Default.TextBoxFontOrg;
            textBoxNewText.Font = Properties.Settings.Default.TextBoxFontNew;
            dataGridViewText.StateCommon.DataCell.Content.Color1 = Properties.Settings.Default.ListColor;
            textBoxOrgText.ForeColor = Properties.Settings.Default.TextBoxColor;
            try
            {
                BackgroundImage = new Bitmap(Properties.Settings.Default.BackgroundImage);
                textBoxNewText.SetBackImage();
                textBoxOrgText.SetBackImage();
            }
            catch
            {
                KryptonMessageBox.Show("背景图无效。");
            }
        }

        private void kryptonCommandUndo_Execute(object sender, EventArgs e)
        {
            if (!_textData.IsOpened)
                return;

            int i = _textData.Undo();

            if (i == -1)
            {
                KryptonMessageBox.Show("无历史记录。");
                return;
            }

            dataGridViewText.FirstSelectedRowIndex = i;
            dataGridViewText.MakeSelectedLineToCenterScreen();
        }
    }
}