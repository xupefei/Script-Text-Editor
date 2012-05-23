using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Script_Text_Editor.TextLibrary;

namespace Script_Text_Editor.Data
{
    internal class TextData
    {
        internal struct LineInfo
        {
            internal int Index;
            internal string Text;

            internal LineInfo(int index, string text)
            {
                Index = index;
                Text = text;
            }
        }

        private bool _isOpened;
        private string _filename;
        private Stack<LineInfo> _stackRedo = new Stack<LineInfo>(50);
        private DataTable _dtTexts = new DataTable();
        private LibraryLinker _library = new LibraryLinker();

        internal TextData()
        {
            _dtTexts.Columns.Add("Line_Number");
            _dtTexts.Columns.Add("Org_Text");
            _dtTexts.Columns.Add("New_Text");

            _dtTexts.PrimaryKey = new[] { _dtTexts.Columns["Line_Number"] };
        }

        public bool IsOpened
        {
            get { return _isOpened; }
        }

        public string Filename
        {
            get { return _filename; }
        }

        internal DataTable DataTable
        {
            get { return _dtTexts; }
        }

        internal LibraryLinker Library
        {
            get { return _library; }
        }

        internal void OpenScript(string filename)
        {
            _dtTexts.Rows.Clear();
            _stackRedo.Clear();

            _filename = filename;

            try
            {
                string[] lines;
                using (var br = new BinaryReader(new FileStream(filename, FileMode.Open)))
                {
                    lines = _library.PreProcess(br.ReadBytes((int)br.BaseStream.Length));

                    br.Close();
                }

                for (int i = 0; i < lines.Length; i++)
                {
                    if (String.IsNullOrEmpty(lines[i]))
                        continue;

                    string sl = _library.GetText(lines[i]);

                    if (sl == "#NOTEXT#")
                        continue;

                    _dtTexts.Rows.Add(i, sl, sl);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }

            _isOpened = _dtTexts.Rows.Count > 0;
        }

        internal void BuildScript(string filename)
        {
            string[] lines;
            using (var br = new BinaryReader(new FileStream(_filename, FileMode.Open)))
            {
                lines = _library.PreProcess(br.ReadBytes((int)br.BaseStream.Length));

                br.Close();
            }

            foreach (DataRow row in _dtTexts.Rows)
            {
                var num = Int32.Parse((string)row["Line_Number"]);
                var orgT = (string)row["Org_Text"];
                var newT = (string)row["New_Text"];

                lines[num] = _library.MakeScript(lines[num], orgT, newT);
            }

            var buffer = _library.PostProcess(lines);

            using (var bw = new BinaryWriter(new FileStream(filename, FileMode.Create)))
            {
                bw.Write(buffer);
                bw.Close();
            }
        }

        bool isFirstTime;

        internal void LoadTranslation(string filename, SavedTranslationFormatProvider.LineInfo[] lines)
        {
            if (IsOpened)
            {
                if (Path.GetFileName(_filename) != Path.GetFileName(filename))
                    OpenScript(filename);
            }
            else
            {
                OpenScript(filename);
            }

            _stackRedo.Clear();

            int ii = 0;
            foreach (var line in lines)
            {
                if (line.Index == -1) //old ver
                {
                    try
                    {
                        _dtTexts.Rows[ii++]["New_Text"] = line.Text;
                    }
                    catch (Exception e)
                    {
                        if (isFirstTime)
                        {
                            KryptonMessageBox.Show(string.Format("在 {0} 导入第 {1} 行时发生错误：{2}",
                                                                 Path.GetFileName(filename), ii, e.Message));

                            isFirstTime = true;
                        }
                    }
                }
                else //new ver
                {
                    if (_dtTexts.Rows.Find(line.Index) == null)
                        continue;

                    _dtTexts.Rows.Find(line.Index)["New_Text"] = line.Text;
                }
            }
        }

        internal string GetOrgTextAt(int index)
        {
            if (_library.AllowCRLF() == 0)
                return (string)_dtTexts.Rows[index]["Org_Text"];

            return ((string)_dtTexts.Rows[index]["Org_Text"]).Replace(_library.GetCRLFTranslation(), "\r\n");
        }

        internal string GetNewTextAt(int index)
        {
            if (_library.AllowCRLF() == 0)
                return (string)_dtTexts.Rows[index]["New_Text"];

            return ((string)_dtTexts.Rows[index]["New_Text"]).Replace(_library.GetCRLFTranslation(), "\r\n");
        }

        internal SavedTranslationFormatProvider.LineInfo GetLineInfoAt(int index)
        {
            return new SavedTranslationFormatProvider.LineInfo(
                index, (string)_dtTexts.Rows.Find(index)["New_Text"]);
        }

        internal SavedTranslationFormatProvider.LineInfo[] GetLineInfoAll()
        {
            var list = new List<SavedTranslationFormatProvider.LineInfo>();

            for (int i = 0; i < _dtTexts.Rows.Count; i++)
            {
                list.Add(GetLineInfoAt(Int32.Parse((string)_dtTexts.Rows[i]["Line_Number"])));
            }

            return list.ToArray();
        }

        internal int Undo()
        {
            if (_stackRedo.Count <= 0)
                return -1;

            var item = _stackRedo.Pop();
            _dtTexts.Rows[item.Index][2] = item.Text;

            return item.Index;
        }

        internal void SaveLineAt(int index, string line)
        {
            _stackRedo.Push(new LineInfo(index, (string)_dtTexts.Rows[index][2]));
            if (_library.AllowCRLF() == 0)
            {
                _dtTexts.Rows[index][2] = line;
            }
            else
            {
                _dtTexts.Rows[index][2] = line.Replace("\r\n", _library.GetCRLFTranslation());
            }
        }
    }
}