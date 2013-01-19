using System;
using System.IO;
using System.Text;

namespace Script_Text_Editor
{
    internal class Utilities
    {
        internal static string GetAbsolutePath(string path2)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path2);
        }

        internal static string GetRelativePath(string fullPath, string pathAsBase)
        {
            if (!pathAsBase.EndsWith(@"\"))
                pathAsBase += @"\";

            return fullPath.Replace(pathAsBase, "");
        }

        internal static int CalcLineCount(string filename)
        {
            int count;
            using (var sr = new StreamReader(filename, Encoding.Default, true))
            {
                count = sr.ReadToEnd().Length - sr.ReadToEnd().Replace("\r\n", "\n").Length;
                sr.Close();
            }
            return count;
        }

        internal static void ChangeSetting(string name, string value)
        {
            string configFileName = System.Windows.Forms.Application.ExecutablePath + ".config";
            var doc = new System.Xml.XmlDocument();
            doc.Load(configFileName);
            string configString =
                @"configuration/applicationSettings/Script_Text_Editor.Properties.Settings/setting[@name='"
                + name + "']/value";
            System.Xml.XmlNode configNode = doc.SelectSingleNode(configString);
            if (configNode != null)
            {
                configNode.InnerText = value;
                doc.Save(configFileName);
                // 刷新应用程序设置
                Properties.Settings.Default.Reload();
            }
        }

        internal static int[] SelectTextBox(string strInput)
        {
            if (strInput.Length < 1)
                return new[] { 0, 0 };

            int start = strInput[0] == '　' ? 0 : strInput.IndexOfAny(new[] { '「', '『'}, 0);

            int end = strInput.LastIndexOfAny(new[] { '」', '』'}, strInput.Length - 1);

            if (start == -1 && end != -1)
                return new[] { 0, end };

            if (start != -1 && end == -1)
                return new[] { start + 1, strInput.Length - start };

            if (start == -1 && end == -1)
                return new[] { 0, strInput.Length };

            return new[] { start + 1, end - start - 1 };
        }
    }
}