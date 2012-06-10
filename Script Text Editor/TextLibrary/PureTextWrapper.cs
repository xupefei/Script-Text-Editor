using System;
using System.IO;
using System.Text;

namespace Script_Text_Editor.TextLibrary
{
    internal class PureTextWrapper : ITextLibrary
    {
        /// <summary>
        /// 获取当前类型的内部编号
        /// </summary>
        internal static int Index
        {
            get { return 0; }
        }

        #region methods

        // Fields
        private const string CRLFTranslation = @"\r\n";

        private const int DefaultEncoding = 2;
        private const int IsAllowCRLF = 0;
        private const string LibraryInfo = "Text Editor";
        private const string SupportExtension = "*";

        // Methods
        public int AllowCRLF()
        {
            return IsAllowCRLF;
        }

        public string GetCRLFTranslation()
        {
            return CRLFTranslation;
        }

        public int GetDefaultEncoding()
        {
            return DefaultEncoding;
        }

        public string GetLibraryInfo()
        {
            return LibraryInfo;
        }

        public string GetSupportExtension()
        {
            return SupportExtension;
        }

        public string GetText(string strInput)
        {
            if (strInput == "")
                return "#NOTEXT#";

            return strInput;
        }

        public string MakeScript(string strOrgScript, string strOrgText, string strNewText)
        {
            if (strOrgText == "")
                return strOrgScript;

            return strOrgScript.Replace(strOrgText, strNewText);
        }

        public string[] PreProcess(byte[] buffer)
        {
            return Encoding.Default.GetString(buffer).Replace("\r\n", "\n").Split('\n');
        }

        public byte[] PostProcess(string[] buffer)
        {
            var ms = new MemoryStream();
            foreach (var s in buffer)
            {
                byte[] b = Encoding.Default.GetBytes(s);
                ms.Write(b, 0, b.Length);
                ms.WriteByte((byte)'\r');
                ms.WriteByte((byte)'\n');
            }

            return ms.ToArray();
        }

        #endregion methods
    }
}