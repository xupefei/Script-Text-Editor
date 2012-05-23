using System;
using System.Reflection;
using ComponentFactory.Krypton.Toolkit;

namespace Script_Text_Editor.TextLibrary
{
    internal class NetWrapper : ITextLibrary
    {
        private object target;
        private Type type;

        /// <summary>
        /// 获取当前类型的内部编号
        /// </summary>
        internal static int Index
        {
            get { return 2; }
        }

        #region Interface methods

        public string GetLibraryInfo()
        {
            return (string)Invoke("GetLibraryInfo", null);
        }

        public string GetSupportExtension()
        {
            return (string)Invoke("GetSupportExtension", null);
        }

        public string GetCRLFTranslation()
        {
            return (string)Invoke("GetCRLFTranslation", null);
        }

        public int AllowCRLF()
        {
            return (int)Invoke("AllowCRLF", null);
        }

        public int GetDefaultEncoding()
        {
            return (int)Invoke("GetDefaultEncoding", null);
        }

        public string GetText(string strInput)
        {
            return (string)Invoke("GetText", new object[] { strInput });
        }

        public string MakeScript(string strOrgScript, string strOrgText, string strNewText)
        {
            return (string)Invoke("MakeScript", new object[] { strOrgScript, strOrgText, strNewText });
        }

        public string[] PreProcess(byte[] buffer)
        {
            return (string[])Invoke("PreProcess", new object[] { buffer });
        }

        public byte[] PostProcess(string[] buffer)
        {
            return (byte[])Invoke("PostProcess", new object[] { buffer });
        }

        #endregion Interface methods

        #region Wrapper

        internal NetWrapper(string library)
        {
            type = Assembly.LoadFrom(library).GetType("Text_Library.Program");
            target = type.InvokeMember("Program", BindingFlags.CreateInstance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly, null, null, null);
        }

        internal NetWrapper(Assembly assembly)
        {
            type = assembly.GetType("Text_Library.Program");
            target = type.InvokeMember("Program", BindingFlags.CreateInstance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly, null, null, null);
        }

        internal object Invoke(string strMethod, object[] args)
        {
            return
                (object)
                type.InvokeMember(strMethod,
                                  BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Public |
                                  BindingFlags.Instance | BindingFlags.DeclaredOnly, null, target, args);
        }

        #endregion Wrapper
    }
}