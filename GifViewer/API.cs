using System;
using System.Runtime.InteropServices;

namespace GIFViewer
{
    #region ShfileOpStruct
    [StructLayout(LayoutKind.Sequential)]
    public struct ShellExecuteInfo //用于ShellExecuteEx
    {
        public int cbSize;
        public int fMask;
        public IntPtr hwnd;
        public string lpVerb;
        public string lpFile;
        public string lpParameters;
        public string lpDirectory;
        public int nShow;
        public IntPtr hInstApp;
        public IntPtr lpIDList;
        public string lpClass;
        public IntPtr hkeyClass;
        public int dwHotKey;
        public IntPtr hIcon;
        public IntPtr hProcess;
    }
    /// <summary>
    /// 该结构表示一个操作
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class ShfileOpStruct
    {
        public IntPtr hwnd;//父窗口句柄 
        public UInt32 wFunc;//要执行的动作 
        public string pFrom; //源文件路径，可以是多个文件 
        public string pTo;//目标路径，可以是路径或文件名 
        public UInt16 fFlags;//标志，附加选项 
        public Int32 fAnyOperationsAborted; //是否可被中断 
        public IntPtr hNameMappings;//文件映射名字，可在其它 Shell 函数中使用 
        public string lpszProgressTitle;// 只在 FOF_SIMPLEPROGRESS 时，指定对话框的标题。 
    }

    #endregion

    public class WindowsAPI
    {

        [DllImport("shell32.dll")]
        public extern static int ShellAbout(IntPtr hWnd, string szApp, string szOtherStuff, IntPtr hIcon);

        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        [DllImport("shell32.dll")]
        public static extern bool ShellExecuteEx(ref ShellExecuteInfo lpExecInfo);

        /// <summary>
        /// 文件操作，可以执行复制，移动，删除，重命名等操作
        /// </summary>
        /// <param name="str">要执行的操作</param>
        /// <returns></returns>
        [DllImport("shell32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int SHFileOperation(ShfileOpStruct str);

        public const int FO_MOVE = 0x0001; //移动文件 　
        public const int FO_COPY = 0x0002; //复制文件 　　
        public const int FO_DELETE = 0x0003; //删除文件，只使用 pFrom 　　
        public const int FO_RENAME = 0x0004; //文件重命名 


        public const int FOF_MULTIDESTFILES = 0x01;//pTo 指定了多个目标文件，而不是单个目录 
        public const int FOF_CONFIRMMOUSE = 0x02;//没有实现
        public const int FOF_SILENT = 0x04; // 不显示一个进度对话框 
        public const int FOF_RENAMEONCOLLISION = 0x08;// 碰到有抵触的名字时，自动分配前缀 
        public const int FOF_NOCONFIRMATION = 0x10;// 不对用户显示提示 
        public const int FOF_WANTMAPPINGHANDLE = 0x20;// 填充 hNameMappings 字段，必须使用 SHFreeNameMappings 释放 
        public const int FOF_ALLOWUNDO = 0x40; // 允许撤销 
        public const int FOF_FILESONLY = 0x80;// 使用 *.* 时, 只对文件操作 
        public const int FOF_SIMPLEPROGRESS = 0x0100;// 简单进度条，意味者不显示文件名。 
        public const int FOF_NOCONFIRMMKDIR = 0x0200;// 建新目录时不需要用户确定 
        public const int FOF_NOERRORUI = 0x0400; // 不显示出错用户界面 　
        public const int FOF_NOCOPYSECURITYATTRIBS = 0x0800; // 不复制 NT 文件的安全属性 　
        public const int FOF_NORECURSION = 0x1000; // 不递归目录 

        public const int SEE_MASK_CLASSKEY = 0x3;
        public const int SEE_MASK_CLASSNAME = 0x1;
        public const int SEE_MASK_CONNECTNETDRV = 0x80;
        public const int SEE_MASK_DOENVSUBST = 0x200;
        public const int SEE_MASK_FILEANDURL = 0x4000000;
        public const int SEE_MASK_FLAG_DDEWAIT = 0x100;
        public const int SEE_MASK_FLAG_LOG_USAGE = 0x4000000;
        public const int SEE_MASK_FLAG_NO_UI = 0x400;
        public const int SEE_MASK_HMONITOR = 0x200000;
        public const int SEE_MASK_HOTKEY = 0x20;
        public const int SEE_MASK_ICON = 0x10;
        public const int SEE_MASK_IDLIST = 0x4;
        public const int SEE_MASK_INVOKEIDLIST = 0xC;
        public const int SEE_MASK_NO_CONSOLE = 0x8000;
        public const int SEE_MASK_NOASYNC = 0x100000;
        public const int SEE_MASK_NOCLOSEPROCESS = 0x40;
        public const int SEE_MASK_NOZONECHECKS = 0x800000;
        public const int SEE_MASK_UNICODE = 0x100000;

        public const int SW_HIDE = 0;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_NORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_MAXIMIZE = 3;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOW = 5;
        public const int SW_MINIMIZE = 6;
        public const int SW_SHOWMINNOACTIVE = 7;
        public const int SW_SHOWNA = 8;
        public const int SW_RESTORE = 9;
        public const int SW_SHOWDEFAULT = 10;
        public const int SW_FORCEMINIMIZE = 11;
        public const int SW_MAX = 11;

        public const int SWP_DRAWFRAME = 0x0020; //围绕窗口画一个框 
        public const int SWP_HIDEWINDOW = 0x0080; //隐藏窗口 
        public const int SWP_NOACTIVATE = 0x0010; //不激活窗口 
        public const int SWP_NOMOVE = 0x0002; //保持当前位置（x和y设定将被忽略） 
        public const int SWP_NOREDRAW = 0x0008; //窗口不自动重画 
        public const int SWP_NOSIZE = 0x0001;//保持当前大小（cx和cy会被忽略） 
        public const int SWP_NOZORDER = 0x0004;//保持窗口在列表的当前位置（hWndInsertAfter将被忽略） 
        public const int SWP_SHOWWINDOW = 0x0040; //显示窗口 
        public const int SWP_FRAMECHANGED = 0x0020; //强迫一条WM_NCCALCSIZE消息进入窗口，即使窗口的大小没有改变
    }
}
