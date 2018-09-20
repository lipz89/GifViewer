using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace GIFViewer
{
    public partial class FrmMain : Form
    {
        private  Image errorImage;

        private  Image ErrorImage
        {
            get
            {
                if (errorImage == null)
                {
                    errorImage = new Bitmap(64, 15);
                    Graphics gp = Graphics.FromImage(ErrorImage);
                    gp.DrawString("没有预览。", this.Font, Brushes.Red, 0, 0);
                    gp.Dispose();
                }

                return errorImage;
            }
        }

        public FrmMain()
        {
            InitializeComponent();
            picMain.Resize += FormResize;
            this.toolStrip1.Items.AddRange(new ToolStripItem[] {
                this.tsbPrev, 
                this.tsbNext,
                this.toolStripSeparator1,
                //this.tsbFit, 
                //this.tsbReal,
                //this.toolStripSeparator2, 
                this.tsbDelete,
                this.tsbSave,
                this.toolStripSeparator5,
                this.tsbHelp
            });
            toolStrip1.Left = (this.Width - toolStrip1.Width) / 2 - SystemInformation.SizingBorderWidth;
            base.Text = Program.ApplicationName;
        }

        private List<string> files = new List<string>();
        private string dirPath;
        private int index = -1;
        private FillMode fillMode = FillMode.Fit;

        private static void Try(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static T Try<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return default(T);
            }
        }

        #region 业务逻辑
        /// <summary>
        /// 加载图片列表并显示需要显示的图片
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public void LoadImage(string path)
        {
            Try(() =>
            {
                if (!string.IsNullOrEmpty(path))
                {
                    dirPath = string.Empty;
                    if (File.Exists(path))
                    {
                        var fi = new FileInfo(path);
                        dirPath = fi.DirectoryName;
                    }
                    else if (Directory.Exists(path))
                    {
                        dirPath = path;
                    }
                    if (!string.IsNullOrEmpty(dirPath))
                    {
                        var fs = new DirectoryInfo(dirPath).GetFiles("*.gif").Select(x => x.FullName.ToLower()).ToList();
                        if ((ModifierKeys & Keys.ControlKey) == 0)
                        {
                            files.Clear();
                        }
                        files.AddRange(fs);
                        files = files.Distinct().ToList();
                        index = files.IndexOf(path.ToLower());
                    }
                }
                ShowDirection(0);
                cmsMain.Enabled = toolStrip1.Enabled = index >= 0;
            });
        }

        /// <summary>
        /// 将绝对路径转换成相对路径
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        private string SimplePath(string fullPath)
        {
            return Try(() => fullPath.Substring(fullPath.LastIndexOf('\\') + 1));
        }
        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="path"></param>
        private void ShowImage(string path)
        {
            Try(() =>
            {
                if (!File.Exists(path))
                {
                    files.Remove(path);
                    ShowDirection(0);
                    return;
                }

                var image = GetFile(path);
                if (image == null)
                {
                    ShowError();
                }
                else
                {
                    picMain.Image = image;
                }
                cmsMain.Enabled = toolStrip1.Enabled = true;
                this.Text = string.Format("{0} - {1}", SimplePath(path), Program.ApplicationName);
                fillMode = FillMode.Real;
                FillSize();
            });
        }
        /// <summary>
        /// 显示错误,没有预览字样
        /// </summary>
        private void ShowError()
        {
            Try(() =>
            {
                this.Text = Program.ApplicationName;
                picMain.SizeMode = PictureBoxSizeMode.CenterImage;
                picMain.Image = ErrorImage;
                cmsMain.Enabled = toolStrip1.Enabled = false;
                index = -1;
            });
        }
        /// <summary>
        /// 窗体大小改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormResize(object sender, EventArgs e)
        {
            Try(() =>
            {
                if (fillMode == FillMode.Fit)
                {
                    picMain.Size = new Size(panel1.Width - 2, panel1.Height - 2);
                    if (picMain.Image.Width < picMain.Width && picMain.Image.Height < picMain.Height)
                        picMain.SizeMode = PictureBoxSizeMode.CenterImage;
                    else
                        picMain.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else if (fillMode == FillMode.Real)
                {
                    if (picMain.Image.Width <= panel1.Width - 2)
                        picMain.Left = (panel1.Width - picMain.Width) / 2 - 1;
                    else
                        picMain.Left = 0 - panel1.HorizontalScroll.Value;
                    if (picMain.Image.Height <= panel1.Height - 2)
                        picMain.Top = (panel1.Height - picMain.Height) / 2 - 1;
                    else
                        picMain.Top = 0 - panel1.VerticalScroll.Value;
                }
            });
        }
        /// <summary>
        /// 拖放进入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        /// <summary>
        /// 拖放结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_DragDrop(object sender, DragEventArgs e)
        {
            Try(() =>
            {
                var fns = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (fns.Any())
                {
                    LoadImage(fns[0]);
                }
            });
        }

        #endregion

        #region 处理方法

        private void ShowDirection(int dir = 0)
        {
            index += Math.Sign(dir);
            if (files.Any())
            {
                if (index >= files.Count)
                {
                    index = 0;
                }
                if (index < 0)
                {
                    index = dir < 0 ? files.Count - 1 : 0;
                }
                ShowImage(files[index]);
            }
            else
            {
                ShowError();
            }
        }

        /// <summary>
        /// 最适合大小
        /// </summary>
        private void FillSize()
        {
            Try(() =>
            {
                if (fillMode == FillMode.Fit)
                    return;
                fillMode = FillMode.Fit;
                panel1.AutoScroll = false;
                picMain.Location = new Point(0, 0);
                picMain.Size = new Size(panel1.Width - 2, panel1.Height - 2);
                if (picMain.Image.Width < picMain.Width && picMain.Image.Height < picMain.Height)
                    picMain.SizeMode = PictureBoxSizeMode.CenterImage;
                else
                    picMain.SizeMode = PictureBoxSizeMode.Zoom;
            });
        }
        /// <summary>
        /// 实际大小
        /// </summary>
        private void RealSize()
        {
            Try(() =>
            {
                if (fillMode == FillMode.Real)
                    return;
                fillMode = FillMode.Real;
                panel1.AutoScroll = true;
                picMain.SizeMode = PictureBoxSizeMode.AutoSize;
                if (picMain.Image.Width <= panel1.Width - 2)
                    picMain.Left = (panel1.Width - picMain.Width) / 2 - 1;
                else
                    picMain.Left = 0;
                if (picMain.Image.Height <= panel1.Height - 2)
                    picMain.Top = (panel1.Height - picMain.Height) / 2 - 1;
                else
                    picMain.Top = 0;
                panel1.AutoScrollPosition = new Point((picMain.Image.Width - panel1.Width) / 2, (picMain.Image.Height - panel1.Height) / 2);
            });
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void Delete()
        {
            Try(() =>
            {
                string fn = files[index];
                var sfs = new ShfileOpStruct
                {
                    hwnd = this.Handle,
                    wFunc = WindowsAPI.FO_DELETE,
                    pFrom = fn + "\0\0",
                    pTo = null,
                    fFlags = WindowsAPI.FOF_ALLOWUNDO
                };
                int result = WindowsAPI.SHFileOperation(sfs);
                if (result != 0)
                {
                    return;
                }
                files.Remove(fn);
                ShowDirection(0);
            });
        }
        /// <summary>
        /// 将文件转为内存流
        /// </summary>
        private MemoryStream ReadFile(string path)
        {
            return Try(() =>
            {
                if (!File.Exists(path))
                    return null;

                using (var file = new FileStream(path, FileMode.Open))
                {
                    var b = new byte[file.Length];
                    file.Read(b, 0, b.Length);
                    var stream = new MemoryStream(b);
                    return stream;
                }
            });
        }

        /// <summary>
        /// 将内存流转为图片
        /// </summary>
        private Image GetFile(string path)
        {
            return Try(() =>
            {
                var stream = ReadFile(path);
                if (stream == null)
                    return null;
                try
                {
                    return Image.FromStream(stream);
                }
                catch
                {
                    return ErrorImage;
                }
            });
        }

        /// <summary>
        /// 另存为
        /// </summary>
        private void SaveAs()
        {
            Try(() =>
            {
                var dlgSave = new SaveFileDialog
                {
                    InitialDirectory = dirPath,
                    Filter = @"GIF格式图片|*.gif",
                    FileName = SimplePath(files[index])
                };
                if (dlgSave.ShowDialog() == DialogResult.OK)
                {
                    var sfs = new ShfileOpStruct
                    {
                        hwnd = this.Handle,
                        wFunc = WindowsAPI.FO_COPY,
                        pFrom = files[index] + "\0\0",
                        pTo = dlgSave.FileName + "\0\0",
                        fFlags = WindowsAPI.FOF_ALLOWUNDO
                    };
                    WindowsAPI.SHFileOperation(sfs);
                }
            });
        }
        /// <summary>
        /// 通过其他程序打开一个文件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="args"></param>
        private void Open(string app, string args)
        {
            Try(() =>
            {
                Process.Start(app, "\"" + args + "\"");
            });
        }
        /// <summary>
        /// 将本图片的路径放进剪切板
        /// </summary>
        private void Copy()
        {
            Try(() =>
            {
                var sc = new StringCollection { files[index] };
                Clipboard.SetFileDropList(sc);
            });
        }
        /// <summary>
        /// 显示文件属性
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="hwnd"></param>
        private void ShowProperties(string filename, IntPtr hwnd)
        {
            Try(() =>
            {
                var sei = new ShellExecuteInfo();
                sei.cbSize = Marshal.SizeOf(sei);
                sei.fMask = WindowsAPI.SEE_MASK_NOCLOSEPROCESS | WindowsAPI.SEE_MASK_INVOKEIDLIST | WindowsAPI.SEE_MASK_FLAG_NO_UI;
                sei.hwnd = hwnd;
                sei.lpVerb = "properties";
                sei.lpFile = filename + "\0\0";
                sei.lpParameters = null;
                sei.lpDirectory = null;
                sei.nShow = 0;
                sei.hInstApp = IntPtr.Zero;
                sei.lpIDList = IntPtr.Zero;
                WindowsAPI.ShellExecuteEx(ref sei);
            });
        }
        /// <summary>
        /// 显示打开方式界面,并以选中的方式打开文件
        /// </summary>
        /// <param name="filename"></param>
        private static void ShowOpenAs(string filename)
        {
            Try(() =>
            {
                WindowsAPI.ShellExecute(
                    IntPtr.Zero,
                    "open",
                    "Rundll32.exe",
                    "shell32.dll,OpenAs_RunDLL " + filename,
                    null,
                    WindowsAPI.SW_SHOWDEFAULT);
            });
        }
        /// <summary>
        /// 显示帮助
        /// </summary>
        private void ShowHelp()
        {
            Try(() =>
            {
                WindowsAPI.ShellAbout(
                    this.Handle,
                    Program.ApplicationName,
                    "一款简单的查看GIF格式图片的查看器\n（win7照片查看器无法预览GIF动态图片）",
                    this.Icon.Handle);
            });
        }

        #endregion
        /// <summary>
        /// 菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtn_Click(object sender, EventArgs e)
        {
            Try(() =>
            {
                if (index < 0)
                    return;
                var tsb = (ToolStripItem)sender;
                string tag = tsb.Tag.ToString();
                switch (tag)
                {
                    case "prev":
                        ShowDirection(-1);
                        break;
                    case "next":
                        ShowDirection(1);
                        break;
                    case "delete":
                        Delete();
                        break;
                    case "save":
                        SaveAs();
                        break;
                    case "fit":
                        FillSize();
                        break;
                    case "real":
                        RealSize();
                        break;
                    case "mspaint":
                        Open("mspaint.exe", files[index]);
                        break;
                    case "ie":
                        Open("iexplore.exe", files[index]);
                        break;
                    case "choose":
                        ShowOpenAs(files[index]);
                        break;
                    case "copy":
                        Copy();
                        break;
                    case "openforder":
                        Open("explorer", dirPath);
                        break;
                    case "attribute":
                        ShowProperties(files[index], this.Handle);
                        break;
                    case "help":
                        ShowHelp();
                        break;
                }
            });
        }
        /// <summary>
        /// 按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            Try(() =>
            {
                if (index < 0)
                    return;
                if (e.KeyData == (Keys.B | Keys.Control))
                    FillSize();
                else if (e.KeyData == (Keys.A | Keys.Control))
                    RealSize();
                else if (e.KeyData == (Keys.S | Keys.Control))
                    SaveAs();
                else if (e.KeyData == (Keys.E | Keys.Control))
                    Open("mspaint.exe", files[index]);
                else if (e.KeyData == Keys.Left || e.KeyData == Keys.Up)
                    ShowDirection(-1);
                else if (e.KeyData == Keys.Right || e.KeyData == Keys.Down)
                    ShowDirection(1);
                else if (e.KeyData == Keys.Delete)
                    Delete();
                else if (e.KeyData == Keys.F1)
                    ShowHelp();
            });
        }
    }
}
