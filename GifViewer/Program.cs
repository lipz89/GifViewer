using System;
using System.Windows.Forms;

namespace GIFViewer
{
    static class Program
    {
        public static string ApplicationName
        {
            get { return "GIF文件查看器"; }
        }

        /// <summary> 
        /// 应用程序的主入口点。 
        /// </summary> 
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm=new FrmMain();
            mainForm.LoadImage(args.Length > 0 ? args[0] : null);
            Application.Run(mainForm);
        }
    }
}
