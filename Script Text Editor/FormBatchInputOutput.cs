using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Script_Text_Editor.Data;

namespace Script_Text_Editor
{
    public partial class FormBatchInputOutput : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        public FormBatchInputOutput()
        {
            InitializeComponent();
        }

        private void kryptonTextBox_TextChanged(object sender, EventArgs e)
        {
            kryptonButtonOutput.Enabled = !String.IsNullOrEmpty(kryptonTextBox1.Text) &&
                                          !String.IsNullOrEmpty(kryptonTextBox2.Text);

            kryptonButtonInput.Enabled = !String.IsNullOrEmpty(kryptonTextBox1.Text) &&
                                         !String.IsNullOrEmpty(kryptonTextBox2.Text) &&
                                         !String.IsNullOrEmpty(kryptonTextBox3.Text);
        }

        private void kryptonLabel4_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
                kryptonTextBox1.Text = fbd.SelectedPath;
        }

        private void kryptonLabel5_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
                kryptonTextBox2.Text = fbd.SelectedPath;
        }

        private void kryptonLabel6_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
                kryptonTextBox3.Text = fbd.SelectedPath;
        }

        private void kryptonButtonOutput_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == KryptonMessageBox.Show(
                                    "本操作将会覆盖目录下已存在的文件，要开始神一般的杀戮吗？",
                                    "哦死你开挂？",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2))
                return;

            int count = 0;
            try
            {
                var textData = new TextData();
                foreach (var file in Directory.GetFiles(kryptonTextBox1.Text,
                                                        "*." + textData.Library.GetSupportExtension()))
                {
                    count++;

                    textData.OpenScript(file);

                    SavedTranslationFormatProvider.MakeSavedTranslation(
                        Path.Combine(kryptonTextBox2.Text, Path.GetFileName(file) + ".sav"),
                        file,
                        textData.Library.GetLibraryInfo(),
                        TimeSpan.Zero,
                        textData.Library.GetDefaultEncoding(),
                        0,
                        textData.GetLineInfoAll()
                        );
                }
            }
            catch (Exception ea)
            {
                KryptonMessageBox.Show(ea.Message);
            }

            KryptonMessageBox.Show(string.Format("已导入 {0} 个文件。", count));
        }

        private void kryptonButtonInput_Click(object sender, EventArgs e)
        {
            if (DialogResult.No == KryptonMessageBox.Show(
                                    "本操作将会覆盖目录下已存在的文件，要开始神一般的杀戮吗？",
                                    "哦死你开挂？",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question,
                                    MessageBoxDefaultButton.Button2))
                return;

            int count = 0;
            try
            {
                foreach (var file in Directory.GetFiles(kryptonTextBox2.Text, "*.sav"))
                {
                    count++;

                    var textData = new TextData();

                    var stfp = new SavedTranslationFormatProvider(file);

                    textData.LoadTranslation(Path.Combine(kryptonTextBox1.Text, Path.GetFileName(stfp.ScriptPath)),
                                             stfp.Lines);

                    textData.BuildScript(Path.Combine(kryptonTextBox3.Text, Path.GetFileName(stfp.ScriptPath)));
                }
            }
            catch (Exception ea)
            {
                KryptonMessageBox.Show(ea.Message);
            }

            KryptonMessageBox.Show(string.Format("已导入 {0} 个文件。", count));
        }

        private void FormBatchInputOutput_Load(object sender, EventArgs e)
        {
            kryptonTextBox1.Text = Utilities.GetAbsolutePath(Properties.Settings.Default.ScriptPath);
            kryptonTextBox2.Text = Utilities.GetAbsolutePath(Properties.Settings.Default.SavedPath);
            kryptonTextBox3.Text = Utilities.GetAbsolutePath(Properties.Settings.Default.NewScriptPath);
        }
    }
}