using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Script_Text_Editor
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            if (!File.Exists(Utilities.GetAbsolutePath(Application.ExecutablePath + ".config")))
            {
                using (var fs = File.Create(Application.ExecutablePath + ".config"))
                {
                    fs.Write(Properties.Resources.app, 0, Properties.Resources.app.Length);
                    fs.Close();
                }
            }

            if (!Directory.Exists(Utilities.GetAbsolutePath(Properties.Settings.Default.ScriptPath)))
                Directory.CreateDirectory(Utilities.GetAbsolutePath(Properties.Settings.Default.ScriptPath));

            if (!Directory.Exists(Utilities.GetAbsolutePath(Properties.Settings.Default.SavedPath)))
                Directory.CreateDirectory(Utilities.GetAbsolutePath(Properties.Settings.Default.SavedPath));

            if (!Directory.Exists(Utilities.GetAbsolutePath(Properties.Settings.Default.NewScriptPath)))
                Directory.CreateDirectory(Utilities.GetAbsolutePath(Properties.Settings.Default.NewScriptPath));

            if (!Directory.Exists(Utilities.GetAbsolutePath(Properties.Settings.Default.AutoSavePath)))
                Directory.CreateDirectory(Utilities.GetAbsolutePath(Properties.Settings.Default.AutoSavePath));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}