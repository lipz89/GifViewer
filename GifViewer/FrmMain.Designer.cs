namespace GIFViewer
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbPrev = new System.Windows.Forms.ToolStripButton();
            this.tsbNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.picMain = new System.Windows.Forms.PictureBox();
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmiOpenItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiMspaint = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiIE = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiChoose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiOpenPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.cmiAttribute = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tsbFit = new System.Windows.Forms.ToolStripButton();
            this.tsbReal = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbHelp = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).BeginInit();
            this.cmsMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(283, 433);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(102, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbPrev
            // 
            this.tsbPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrev.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrev.Image")));
            this.tsbPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrev.Name = "tsbPrev";
            this.tsbPrev.Size = new System.Drawing.Size(23, 22);
            this.tsbPrev.Tag = "prev";
            this.tsbPrev.Text = "上一个图像(左箭头)";
            this.tsbPrev.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // tsbNext
            // 
            this.tsbNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNext.Image = ((System.Drawing.Image)(resources.GetObject("tsbNext.Image")));
            this.tsbNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNext.Name = "tsbNext";
            this.tsbNext.Size = new System.Drawing.Size(23, 22);
            this.tsbNext.Tag = "next";
            this.tsbNext.Text = "下一个图像(右箭头)";
            this.tsbNext.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Tag = "delete";
            this.tsbDelete.Text = "删除(Del)";
            this.tsbDelete.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Tag = "save";
            this.tsbSave.Text = "另存为(Ctrl+S)";
            this.tsbSave.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // picMain
            // 
            this.picMain.ContextMenuStrip = this.cmsMain;
            this.picMain.Location = new System.Drawing.Point(0, 0);
            this.picMain.Name = "picMain";
            this.picMain.Size = new System.Drawing.Size(680, 424);
            this.picMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picMain.TabIndex = 0;
            this.picMain.TabStop = false;
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiOpenItem,
            this.toolStripSeparator3,
            this.cmiOpenPosition,
            this.toolStripSeparator5,
            this.cmiCopy,
            this.cmiDelete,
            this.toolStripSeparator6,
            this.cmiAttribute});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(161, 132);
            // 
            // cmiOpenItem
            // 
            this.cmiOpenItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiMspaint,
            this.cmiIE,
            this.toolStripSeparator4,
            this.cmiChoose});
            this.cmiOpenItem.Name = "cmiOpenItem";
            this.cmiOpenItem.Size = new System.Drawing.Size(160, 22);
            this.cmiOpenItem.Text = "打开方式(&H)";
            // 
            // cmiMspaint
            // 
            this.cmiMspaint.Name = "cmiMspaint";
            this.cmiMspaint.Size = new System.Drawing.Size(174, 22);
            this.cmiMspaint.Tag = "mspaint";
            this.cmiMspaint.Text = "画图工具";
            this.cmiMspaint.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // cmiIE
            // 
            this.cmiIE.Name = "cmiIE";
            this.cmiIE.Size = new System.Drawing.Size(174, 22);
            this.cmiIE.Tag = "ie";
            this.cmiIE.Text = "Internet Explorer";
            this.cmiIE.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(171, 6);
            // 
            // cmiChoose
            // 
            this.cmiChoose.Name = "cmiChoose";
            this.cmiChoose.Size = new System.Drawing.Size(174, 22);
            this.cmiChoose.Tag = "choose";
            this.cmiChoose.Text = "选择程序(&C)";
            this.cmiChoose.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // cmiOpenPosition
            // 
            this.cmiOpenPosition.Name = "cmiOpenPosition";
            this.cmiOpenPosition.Size = new System.Drawing.Size(160, 22);
            this.cmiOpenPosition.Tag = "openforder";
            this.cmiOpenPosition.Text = "打开文件位置(&I)";
            this.cmiOpenPosition.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(157, 6);
            // 
            // cmiCopy
            // 
            this.cmiCopy.Name = "cmiCopy";
            this.cmiCopy.Size = new System.Drawing.Size(160, 22);
            this.cmiCopy.Tag = "copy";
            this.cmiCopy.Text = "复制(&C)";
            this.cmiCopy.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // cmiDelete
            // 
            this.cmiDelete.Name = "cmiDelete";
            this.cmiDelete.Size = new System.Drawing.Size(160, 22);
            this.cmiDelete.Tag = "delete";
            this.cmiDelete.Text = "删除(&D)";
            this.cmiDelete.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(157, 6);
            // 
            // cmiAttribute
            // 
            this.cmiAttribute.Name = "cmiAttribute";
            this.cmiAttribute.Size = new System.Drawing.Size(160, 22);
            this.cmiAttribute.Tag = "attribute";
            this.cmiAttribute.Text = "属性(&R)";
            this.cmiAttribute.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.ContextMenuStrip = this.cmsMain;
            this.panel1.Controls.Add(this.picMain);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 426);
            this.panel1.TabIndex = 2;
            // 
            // tsbFit
            // 
            this.tsbFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFit.Image = ((System.Drawing.Image)(resources.GetObject("tsbFit.Image")));
            this.tsbFit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFit.Name = "tsbFit";
            this.tsbFit.Size = new System.Drawing.Size(23, 22);
            this.tsbFit.Tag = "fit";
            this.tsbFit.Text = "最合适大小(Ctrl+B)";
            this.tsbFit.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // tsbReal
            // 
            this.tsbReal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReal.Image = ((System.Drawing.Image)(resources.GetObject("tsbReal.Image")));
            this.tsbReal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReal.Name = "tsbReal";
            this.tsbReal.Size = new System.Drawing.Size(23, 22);
            this.tsbReal.Tag = "real";
            this.tsbReal.Text = "实际大小(Ctrl+A)";
            this.tsbReal.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbHelp
            // 
            this.tsbHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbHelp.Image = ((System.Drawing.Image)(resources.GetObject("tsbHelp.Image")));
            this.tsbHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHelp.Name = "tsbHelp";
            this.tsbHelp.Size = new System.Drawing.Size(23, 22);
            this.tsbHelp.Tag = "help";
            this.tsbHelp.Text = "帮助(F1)";
            this.tsbHelp.Click += new System.EventHandler(this.tsbtn_Click);
            // 
            // FrmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(684, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(440, 330);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIF图片查看器";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FrmMain_DragEnter);
            this.Resize += new System.EventHandler(this.FormResize);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picMain)).EndInit();
            this.cmsMain.ResumeLayout(false);
            this.panel1.ResumeLayout(true);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox picMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbPrev;
        private System.Windows.Forms.ToolStripButton tsbNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton tsbFit;
        private System.Windows.Forms.ToolStripButton tsbReal;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem cmiOpenItem;
        private System.Windows.Forms.ToolStripMenuItem cmiMspaint;
        private System.Windows.Forms.ToolStripMenuItem cmiIE;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cmiChoose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmiOpenPosition;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem cmiCopy;
        private System.Windows.Forms.ToolStripMenuItem cmiDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem cmiAttribute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbHelp;
    }
}