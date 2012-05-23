using System;
using System.IO;
using System.Text;
using ComponentFactory.Krypton.Toolkit;

namespace Script_Text_Editor.TextLibrary
{
    internal class LibraryLinker
    {
        /// <summary>
        /// 库接口
        /// </summary>
        private ITextLibrary library;

        /// <summary>
        /// 构造函数
        /// </summary>
        internal LibraryLinker()
        {
            int type = Properties.Settings.Default.LibraryType;
            string path = Properties.Settings.Default.LibraryPath;

            //检查库是否存在
            if ((!File.Exists(path)) && (type != 0))
            {
                KryptonMessageBox.Show("指定的解析库不存在，使用纯文本模式。");
                type = 0;
            }

            try
            {
                //初始化初始化库
                switch (type)
                {
                    case 1: //DynamicCodeWrapper
                        library = new DynamicCodeWrapper(path, Encoding.UTF8);
                        break;
                    case 2: //NetWrapper
                        library = new NetWrapper(path);
                        break;
                    default:
                        library = new PureTextWrapper();
                        break;
                }
            }
            catch (Exception e)
            {
                KryptonMessageBox.Show(e.Message);
                Environment.Exit(0);
            }
        }

        internal string GetLibraryInfo()
        {
            return library.GetLibraryInfo();
        }

        internal string GetSupportExtension()
        {
            return library.GetSupportExtension();
        }

        internal int AllowCRLF()
        {
            return library.AllowCRLF();
        }

        internal int GetDefaultEncoding()
        {
            return library.GetDefaultEncoding();
        }

        internal string GetCRLFTranslation()
        {
            return library.GetCRLFTranslation();
        }

        internal string GetText(string strInputfile)
        {
            try
            {
                return library.GetText(strInputfile);
            }
            catch (Exception e)
            {
                KryptonMessageBox.Show(e.Message);
                return String.Empty;
            }
        }

        internal string MakeScript(string strOrgScript, string strOrgText, string strNewText)
        {
            try
            {
                return library.MakeScript(strOrgScript, strOrgText, strNewText);
            }
            catch (Exception e)
            {
                KryptonMessageBox.Show(e.Message);
                return strOrgScript;
            }
        }

        internal string[] PreProcess(byte[] buffer)
        {
            try
            {
                return library.PreProcess(buffer);
            }
            catch (Exception)
            {
                switch (GetDefaultEncoding())
                {
                    case 1:
                        return Encoding.GetEncoding(932).GetString(buffer).Replace("\r\n", "\n").Split('\n');
                    case 2:
                        return Encoding.GetEncoding(936).GetString(buffer).Replace("\r\n", "\n").Split('\n');
                    case 3:
                        return Encoding.Unicode.GetString(buffer).Replace("\r\n", "\n").Split('\n');
                    case 4:
                        return Encoding.UTF8.GetString(buffer).Replace("\r\n", "\n").Split('\n');
                    default:
                        return Encoding.Default.GetString(buffer).Replace("\r\n", "\n").Split('\n');
                }
            }
        }

        internal byte[] PostProcess(string[] buffer)
        {
            try
            {
                return library.PostProcess(buffer);
            }
            catch (Exception)
            {
                var ms = new MemoryStream();
                foreach (var s in buffer)
                {
                    byte[] b;
                    switch (GetDefaultEncoding())
                    {
                        case 1:
                        case 2:
                            b = Encoding.GetEncoding(936).GetBytes(s);
                            break;
                        case 3:
                            b = Encoding.Unicode.GetBytes(s);
                            break;
                        case 4:
                            b = Encoding.UTF8.GetBytes(s);
                            break;
                        default:
                            b = Encoding.Default.GetBytes(s);
                            break;
                    }
                    ms.Write(b, 0, b.Length);
                    ms.Write(new byte[] { 0x0D, 0x0A }, 0, 2);
                }
                var bu = new byte[ms.Length - 2];
                Array.Copy(ms.ToArray(), 0, bu, 0, ms.Length - 2);
                return bu;
            }
        }
    }
}