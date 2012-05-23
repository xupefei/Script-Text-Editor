using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.CSharp;

namespace Script_Text_Editor.TextLibrary
{
    #region DynamicCodeCompiler

    internal class DynamicCodeCompiler
    {
        private CompilerParameters _compilerParameters = new CompilerParameters();

        internal DynamicCodeCompiler()
        {
            _compilerParameters.ReferencedAssemblies.Add("System.dll");
            _compilerParameters.GenerateExecutable = false;
            _compilerParameters.GenerateInMemory = true;
        }

        /// <summary>
        /// 获取或设置要编译的代码
        /// </summary>
        internal string SourceCode { get; set; }

        /// <summary>
        /// 编译选项
        /// </summary>
        internal CompilerParameters CompilerParameters
        {
            get { return _compilerParameters; }
            set { _compilerParameters = value; }
        }

        internal Assembly Compile()
        {
            var provider = new CSharpCodeProvider();
            CompilerResults results = provider.CompileAssemblyFromSource(_compilerParameters, SourceCode);

            if (results.Errors.HasErrors)
            {
                string errorText = string.Empty;

                foreach (CompilerError err in results.Errors)
                    errorText += String.Format("{0}{1}: {2}", Environment.NewLine, err.Line, err.ErrorText);

                throw new Exception(errorText);
            }

            return results.CompiledAssembly;
        }
    }

    #endregion DynamicCodeCompiler

    internal class DynamicCodeWrapper : ITextLibrary
    {
        private bool _hasError;
        private NetWrapper _netWrapper;

        /// <summary>
        /// 获取当前类型的内部编号
        /// </summary>
        internal static int Index
        {
            get { return 1; }
        }

        #region Interface methods

        public string GetLibraryInfo()
        {
            return _netWrapper.GetLibraryInfo();
        }

        public string GetSupportExtension()
        {
            return _netWrapper.GetSupportExtension();
        }

        public string GetCRLFTranslation()
        {
            return _netWrapper.GetCRLFTranslation();
        }

        public int AllowCRLF()
        {
            return _netWrapper.AllowCRLF();
        }

        public int GetDefaultEncoding()
        {
            return _netWrapper.GetDefaultEncoding();
        }

        public string GetText(string file)
        {
            return _netWrapper.GetText(file);
        }

        public string MakeScript(string strOrgScript, string strOrgText, string strNewText)
        {
            return _netWrapper.MakeScript(strOrgScript, strOrgText, strNewText);
        }

        public string[] PreProcess(byte[] buffer)
        {
            return _netWrapper.PreProcess(buffer);
        }

        public byte[] PostProcess(string[] buffer)
        {
            return _netWrapper.PostProcess(buffer);
        }

        #endregion Interface methods

        #region Wrapper

        internal DynamicCodeWrapper(string filePath, Encoding encoding)
        {
            string code;
            using (var sr = new StreamReader(filePath, encoding, true))
            {
                code = sr.ReadToEnd();
                sr.Close();
            }

            Init(code);
        }

        internal DynamicCodeWrapper(string code)
        {
            Init(code);
        }

        internal NetWrapper NETWrapper
        {
            get { return _netWrapper; }
        }

        internal bool HasError
        {
            get { return _hasError; }
        }

        private void Init(string code)
        {
            var compiler = new DynamicCodeCompiler();
            compiler.SourceCode = code;

            foreach (string line in code.Replace(Environment.NewLine, "\n").Split('\n'))
            {
                if (line.StartsWith(@"//@Ref:"))
                    compiler.CompilerParameters.ReferencedAssemblies.Add(line.Split(':')[1]);
            }

            try
            {
                _netWrapper = new NetWrapper(compiler.Compile());
            }
            catch (Exception e)
            {
                _hasError = true;
                KryptonMessageBox.Show(e.Message);
            }
        }

        #endregion Wrapper
    }
}