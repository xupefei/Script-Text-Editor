using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace Script_Text_Editor.Data
{
    internal class SavedTranslationFormatProvider
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

        private bool _isNewVersion;
        private TimeSpan _totalTime;
        private string _scriptPath;
        private int _encoding;
        private int _lastLine;
        private List<LineInfo> _lines = new List<LineInfo>();

        internal int LastLine
        {
            get { return _lastLine; }
        }

        internal int Encoding
        {
            get { return _encoding; }
        }

        internal string ScriptPath
        {
            get { return _scriptPath; }
        }

        internal TimeSpan TotalTime
        {
            get { return _totalTime; }
        }

        internal LineInfo[] Lines
        {
            get { return _lines.ToArray(); }
        }

        internal SavedTranslationFormatProvider(string filename)
        {
            string[] lines;
            using (var sr = new StreamReader(filename))
            {
                lines = sr.ReadToEnd().Replace("\r\n", "\n").Split('\n');
                sr.Close();
            }

            //check
            if (lines[0].IndexOf("Translation file") == -1)
                throw new Exception("这似乎不是一个有效的存档。");

            //format line
            if (lines[0].EndsWith(" [Version 2]"))
                _isNewVersion = true;

            //time info
            _totalTime = _isNewVersion ? TimeSpan.Parse(lines[1]) : TimeSpan.Zero;

            //script path
            _scriptPath = lines[2];

            //encoding
            _encoding = Int32.Parse(lines[3]);

            //last editing line
            _lastLine = Int32.Parse(lines[4]);

            //text lines
            if (_isNewVersion)
            {
                for (int i = 5; i < lines.Length - 1; i++)
                {
                    string l = lines[i];

                    if (l.Length < 7) //eg. <00001>
                        continue;

                    int index = Int32.Parse(l.Substring(1, 5));
                    string text = l.Substring(7);

                    _lines.Add(new LineInfo(index, text));
                }
            }
            else
            {
                for (int i = 5; i < lines.Length - 1; i++)
                {
                    string l = lines[i];

                    _lines.Add(new LineInfo(-1, l));
                }
            }
        }

        internal static void MakeSavedTranslation(string saveTo, string scriptName, string libraryInfo,
            TimeSpan total, int encoding, int crtLine, LineInfo[] lines)
        {
            using (var sw = new StreamWriter(saveTo))
            {
                sw.WriteLine("{0} Translation file [Version 2]", libraryInfo);
                sw.WriteLine("{0}", total.ToString());
                sw.WriteLine(scriptName);
                sw.WriteLine(encoding);
                sw.WriteLine(crtLine);

                foreach (var line in lines)
                {
                    sw.WriteLine("<{0}>{1}",
                                 line.Index.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'), line.Text);
                }

                sw.Close();
            }
        }
    }
}