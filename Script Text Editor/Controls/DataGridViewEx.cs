using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace Script_Text_Editor.Controls
{
    public class DataGridViewEx : KryptonDataGridView
    {
        #region P/Invoke Function

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_HSCROLL = 0x0114;
        private const int WM_VSCROLL = 0x0115;
        private const int WM_MOUSEWHEEL = 0x020A;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_KEYDOWN:
                case WM_HSCROLL:
                case WM_VSCROLL:
                case WM_MOUSEWHEEL:
                    Invalidate();
                    break;
            }

            base.WndProc(ref m);
        }

        internal void Redraw()
        {
            Invalidate();
        }

        #endregion P/Invoke Function

        #region Override

        protected override void OnSelectionChanged(EventArgs e)
        {
            Redraw();

            base.OnSelectionChanged(e);
        }

        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                var rectangle = new Rectangle(e.RowBounds.Location.X, Convert.ToInt32(
                    e.RowBounds.Location.Y +
                    (e.RowBounds.Height - RowHeadersDefaultCellStyle.Font.Size)
                    / 2 - 3), RowHeadersWidth - 4, e.RowBounds.Height);

                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                                      RowHeadersDefaultCellStyle.Font, rectangle,
                                      Properties.Settings.Default.ListColor, TextFormatFlags.Right);
            }

            catch
            {
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (Parent != null)
            {
                foreach (DataGridViewColumn dgvc in Columns)
                    dgvc.Width = (Parent.ClientSize.Width - 60) / 2;
            }
        }

        #endregion Override

        internal int FirstSelectedRowIndex
        {
            get
            {
                if (SelectedRows.Count != 0)
                    return SelectedRows[0].Index;
                return -1;
            }
            set
            {
                ClearSelection();
                Rows[value].Selected = true;
            }
        }

        internal void SelectPrevLine()
        {
            try
            {
                if (FirstSelectedRowIndex == 0)
                    return;

                FirstSelectedRowIndex -= 1;

                MakeSelectedLineToCenterScreen();
            }
            catch (Exception)
            {
            }
        }

        internal void SelectNextLine()
        {
            try
            {
                if (FirstSelectedRowIndex == Rows.Count - 1)
                    return;

                FirstSelectedRowIndex += 1;

                MakeSelectedLineToCenterScreen();
            }
            catch (Exception)
            {
            }
        }

        internal void MakeSelectedLineToCenterScreen()
        {
            try
            {
                FirstDisplayedScrollingRowIndex = SelectedRows[0].Index - (DisplayedRowCount(false) / 2);
            }
            catch (Exception)
            {
                if (!SelectedRows[0].Displayed)
                    FirstDisplayedScrollingRowIndex = SelectedRows[0].Index;
            }
        }

        internal void MarkCurrentLine()
        {
            Rows[FirstSelectedRowIndex].ErrorText = "Marked";
        }

        internal void ClearCurrentLineMark()
        {
            Rows[FirstSelectedRowIndex].ErrorText = "";
        }

        internal void ClearAllMarks()
        {
            foreach (DataRow row in Rows)
            {
                row.ClearErrors();
            }
        }

        internal void GotoPrevMarkedLine()
        {
            int start = FirstSelectedRowIndex - 1;
            if (start < 0)
                start = 0;

            for (int i = start; i >= 0; i--)
            {
                if (!String.IsNullOrEmpty(Rows[i].ErrorText))
                {
                    FirstSelectedRowIndex = i;
                    MakeSelectedLineToCenterScreen();
                    return;
                }
            }
        }

        internal void GotoNextMarkedLine()
        {
            int start = FirstSelectedRowIndex + 1;
            if (start >= Rows.Count)
                start = Rows.Count - 1;

            for (int i = start; i < Rows.Count; i++)
            {
                if (!String.IsNullOrEmpty(Rows[i].ErrorText))
                {
                    FirstSelectedRowIndex = i;
                    MakeSelectedLineToCenterScreen();
                    return;
                }
            }
        }
    }
}