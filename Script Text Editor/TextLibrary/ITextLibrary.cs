using System.IO;

namespace Script_Text_Editor.TextLibrary
{
    /// <summary>
    /// 实现接口
    /// </summary>
    internal interface ITextLibrary
    {
        string GetLibraryInfo();

        string GetSupportExtension();

        int AllowCRLF();

        int GetDefaultEncoding();

        string GetCRLFTranslation();

        string GetText(string strInputfile);

        string MakeScript(string strOrgScript, string strOrgText, string strNewText);

        string[] PreProcess(byte[] buffer);

        byte[] PostProcess(string[] buffer);
    }
}