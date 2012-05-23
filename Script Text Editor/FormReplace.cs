using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Script_Text_Editor.Controls;

namespace Script_Text_Editor
{
    public partial class FormReplace : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        private readonly DataTable _dt;
        private readonly DataGridViewEx _dgv;

        public FormReplace(DataTable dt, DataGridViewEx dgv)
        {
            _dt = dt;
            _dgv = dgv;

            InitializeComponent();
        }

        private void FormReplace_Activated(object sender, EventArgs e)
        {
            Opacity = 1.0;
        }

        private void FormReplace_Deactivate(object sender, EventArgs e)
        {
            Opacity = 0.7;
        }

        private void kryptonTextBox_TextChanged(object sender, EventArgs e)
        {
            kryptonButtonNext.Enabled = !String.IsNullOrEmpty(kryptonTextBoxFind.Text);

            kryptonButtonPrev.Enabled = !String.IsNullOrEmpty(kryptonTextBoxFind.Text);

            kryptonButtonReplace.Enabled = !String.IsNullOrEmpty(kryptonTextBoxFind.Text);

            kryptonButtonReplaceAll.Enabled = !String.IsNullOrEmpty(kryptonTextBoxFind.Text);
        }

        private void FindNext(int setp)
        {
            int startLine = _dgv.FirstSelectedRowIndex + setp;

            for (int i = startLine; i < _dt.Rows.Count; i += setp)
            {
                if (((string)_dt.Rows[i]["New_Text"])
                    .IndexOf(kryptonTextBoxFind.Text, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    _dgv.FirstSelectedRowIndex = i;
                    _dgv.MakeSelectedLineToCenterScreen();
                    return;
                }

                if (kryptonCheckBoxWithOrg.Checked)
                    if (((string)_dt.Rows[i]["Org_Text"])
                        .IndexOf(kryptonTextBoxFind.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        _dgv.FirstSelectedRowIndex = i;
                        _dgv.MakeSelectedLineToCenterScreen();
                        return;
                    }
            }

            KryptonMessageBox.Show("关键字木有找到～", @"~\(≧▽≦)/~",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void kryptonButtonNext_Click(object sender, EventArgs e)
        {
            int startLine = _dgv.FirstSelectedRowIndex + 1;
            if (startLine > _dt.Rows.Count - 1)
                startLine = _dt.Rows.Count - 1;

            for (int i = startLine; i < _dt.Rows.Count; i++)
            {
                if (((string)_dt.Rows[i]["New_Text"])
                    .IndexOf(kryptonTextBoxFind.Text, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    _dgv.FirstSelectedRowIndex = i;
                    _dgv.MakeSelectedLineToCenterScreen();
                    return;
                }

                if (kryptonCheckBoxWithOrg.Checked)
                    if (((string)_dt.Rows[i]["Org_Text"])
                        .IndexOf(kryptonTextBoxFind.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        _dgv.FirstSelectedRowIndex = i;
                        _dgv.MakeSelectedLineToCenterScreen();
                        return;
                    }
            }

            KryptonMessageBox.Show("关键字木有找到～", @"~\(≧▽≦)/~",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void kryptonButtonPrev_Click(object sender, EventArgs e)
        {
            int startLine = _dgv.FirstSelectedRowIndex - 1;
            if (startLine < 0)
                startLine = 0;

            for (int i = startLine; i >= 0; i--)
            {
                if (((string)_dt.Rows[i]["New_Text"])
                    .IndexOf(kryptonTextBoxFind.Text, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    _dgv.FirstSelectedRowIndex = i;
                    _dgv.MakeSelectedLineToCenterScreen();
                    return;
                }

                if (kryptonCheckBoxWithOrg.Checked)
                    if (((string)_dt.Rows[i]["Org_Text"])
                        .IndexOf(kryptonTextBoxFind.Text, StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        _dgv.FirstSelectedRowIndex = i;
                        _dgv.MakeSelectedLineToCenterScreen();
                        return;
                    }
            }

            KryptonMessageBox.Show("关键字木有找到～", @"~\(≧▽≦)/~",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void kryptonButtonReplace_Click(object sender, EventArgs e)
        {
            int startLine = _dgv.FirstSelectedRowIndex;
            if (startLine > _dt.Rows.Count - 1)
                startLine = _dt.Rows.Count - 1;

            for (int i = startLine; i < _dt.Rows.Count; i++)
            {
                if (((string)_dt.Rows[i]["New_Text"])
                    .IndexOf(kryptonTextBoxFind.Text, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    _dt.Rows[i]["New_Text"] =
                        ((string)_dt.Rows[i]["New_Text"]).Replace(
                            kryptonTextBoxFind.Text, kryptonTextBoxReplace.Text);
                    _dgv.FirstSelectedRowIndex = i;
                    _dgv.MakeSelectedLineToCenterScreen();
                    return;
                }
            }

            KryptonMessageBox.Show("关键字木有找到～", @"~\(≧▽≦)/~",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void kryptonButtonReplaceAll_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < _dt.Rows.Count; i++)
            {
                if (((string)_dt.Rows[i]["New_Text"])
                    .IndexOf(kryptonTextBoxFind.Text, StringComparison.OrdinalIgnoreCase) != -1)
                {
                    _dt.Rows[i]["New_Text"] =
                        ((string)_dt.Rows[i]["New_Text"]).Replace(
                            kryptonTextBoxFind.Text, kryptonTextBoxReplace.Text);

                    count++;
                }
            }
            KryptonMessageBox.Show(string.Format("一共替换了 {0} 次～", count), @"~\(≧▽≦)/~",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void kryptonTextBoxFind_KeyPress(object sender, KeyPressEventArgs e)
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

        private void kryptonTextBoxFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (e.Shift)
                    kryptonButtonPrev.PerformClick();
                else
                    kryptonButtonNext.PerformClick();
                e.Handled = true;
            }
            else if (e.Control && e.KeyCode == Keys.Z)
            {
                kryptonCheckBoxWithOrg.Checked = !kryptonCheckBoxWithOrg.Checked;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}