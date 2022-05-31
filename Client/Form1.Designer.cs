
namespace Client
{
    partial class Client_Form
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client_Form));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IP_txt = new System.Windows.Forms.TextBox();
            this.PATH_txt = new System.Windows.Forms.TextBox();
            this.PORT_txt = new System.Windows.Forms.TextBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.TreeView = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openFd_btn = new System.Windows.Forms.Button();
            this.pathOb_btn = new System.Windows.Forms.Button();
            this.connectSv_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detail = new System.Windows.Forms.ToolStripMenuItem();
            this.download = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolMenuDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuEasy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuSmallIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuBigIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.columnFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFileDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "다운로드 경로:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(468, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "PORT:";
            // 
            // IP_txt
            // 
            this.IP_txt.Location = new System.Drawing.Point(57, 10);
            this.IP_txt.Name = "IP_txt";
            this.IP_txt.Size = new System.Drawing.Size(389, 28);
            this.IP_txt.TabIndex = 3;
            // 
            // PATH_txt
            // 
            this.PATH_txt.Location = new System.Drawing.Point(157, 56);
            this.PATH_txt.Name = "PATH_txt";
            this.PATH_txt.ReadOnly = true;
            this.PATH_txt.Size = new System.Drawing.Size(497, 28);
            this.PATH_txt.TabIndex = 4;
            this.PATH_txt.TextChanged += new System.EventHandler(this.DlPt_txt_TextChanged);
            // 
            // PORT_txt
            // 
            this.PORT_txt.Location = new System.Drawing.Point(533, 10);
            this.PORT_txt.Name = "PORT_txt";
            this.PORT_txt.Size = new System.Drawing.Size(121, 28);
            this.PORT_txt.TabIndex = 5;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "avi.png");
            this.imageList.Images.SetKeyName(1, "folder.png");
            this.imageList.Images.SetKeyName(2, "image.png");
            this.imageList.Images.SetKeyName(3, "music.png");
            this.imageList.Images.SetKeyName(4, "temp.png");
            this.imageList.Images.SetKeyName(5, "text.png");
            // 
            // TreeView
            // 
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.TreeView.ImageIndex = 0;
            this.TreeView.ImageList = this.imageList;
            this.TreeView.Location = new System.Drawing.Point(0, 0);
            this.TreeView.Name = "TreeView";
            this.TreeView.SelectedImageIndex = 0;
            this.TreeView.Size = new System.Drawing.Size(159, 430);
            this.TreeView.TabIndex = 6;
            this.TreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView_BeforeExpand);
            this.TreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView_BeforeSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.openFd_btn);
            this.panel1.Controls.Add(this.pathOb_btn);
            this.panel1.Controls.Add(this.connectSv_btn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.IP_txt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.PATH_txt);
            this.panel1.Controls.Add(this.PORT_txt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(666, 141);
            this.panel1.TabIndex = 7;
            // 
            // openFd_btn
            // 
            this.openFd_btn.Location = new System.Drawing.Point(499, 90);
            this.openFd_btn.Name = "openFd_btn";
            this.openFd_btn.Size = new System.Drawing.Size(139, 37);
            this.openFd_btn.TabIndex = 8;
            this.openFd_btn.Text = "폴더열기";
            this.openFd_btn.UseVisualStyleBackColor = true;
            // 
            // pathOb_btn
            // 
            this.pathOb_btn.Location = new System.Drawing.Point(269, 90);
            this.pathOb_btn.Name = "pathOb_btn";
            this.pathOb_btn.Size = new System.Drawing.Size(149, 37);
            this.pathOb_btn.TabIndex = 7;
            this.pathOb_btn.Text = "경로설정";
            this.pathOb_btn.UseVisualStyleBackColor = true;
            this.pathOb_btn.Click += new System.EventHandler(this.pathOb_btn_Click);
            // 
            // connectSv_btn
            // 
            this.connectSv_btn.Location = new System.Drawing.Point(57, 90);
            this.connectSv_btn.Name = "connectSv_btn";
            this.connectSv_btn.Size = new System.Drawing.Size(135, 37);
            this.connectSv_btn.TabIndex = 6;
            this.connectSv_btn.Text = "서버연결";
            this.connectSv_btn.UseVisualStyleBackColor = true;
            this.connectSv_btn.Click += new System.EventHandler(this.connectSv_btn_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Controls.Add(this.TreeView);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(666, 430);
            this.panel2.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(159, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 430);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnFileName,
            this.columnFileSize,
            this.columnFileDate});
            this.listView1.ContextMenuStrip = this.contextMenuStrip;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList;
            this.listView1.Location = new System.Drawing.Point(159, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(507, 430);
            this.listView1.SmallImageList = this.imageList;
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detail,
            this.download,
            this.toolStripSeparator1,
            this.toolMenuDetail,
            this.toolMenuEasy,
            this.toolMenuSmallIcon,
            this.toolMenuBigIcon});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(241, 235);
            // 
            // detail
            // 
            this.detail.Name = "detail";
            this.detail.Size = new System.Drawing.Size(240, 32);
            this.detail.Text = "상세정보";
            this.detail.Click += new System.EventHandler(this.detail_Click);
            // 
            // download
            // 
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(240, 32);
            this.download.Text = "다운로드";
            this.download.Click += new System.EventHandler(this.download_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(171, 6);
            // 
            // toolMenuDetail
            // 
            this.toolMenuDetail.Name = "toolMenuDetail";
            this.toolMenuDetail.Size = new System.Drawing.Size(174, 32);
            this.toolMenuDetail.Text = "자세히";
            this.toolMenuDetail.Click += new System.EventHandler(this.toolMenuDetail_Click);
            // 
            // toolMenuEasy
            // 
            this.toolMenuEasy.Name = "toolMenuEasy";
            this.toolMenuEasy.Size = new System.Drawing.Size(174, 32);
            this.toolMenuEasy.Text = "간단히";
            this.toolMenuEasy.Click += new System.EventHandler(this.toolMenuEasy_Click);
            // 
            // toolMenuSmallIcon
            // 
            this.toolMenuSmallIcon.Name = "toolMenuSmallIcon";
            this.toolMenuSmallIcon.Size = new System.Drawing.Size(174, 32);
            this.toolMenuSmallIcon.Text = "작은아이콘";
            this.toolMenuSmallIcon.Click += new System.EventHandler(this.toolMenuSmallIcon_Click);
            // 
            // toolMenuBigIcon
            // 
            this.toolMenuBigIcon.Name = "toolMenuBigIcon";
            this.toolMenuBigIcon.Size = new System.Drawing.Size(174, 32);
            this.toolMenuBigIcon.Text = "큰아이콘";
            this.toolMenuBigIcon.Click += new System.EventHandler(this.toolMenuBigIcon_Click);
            // 
            // columnFileName
            // 
            this.columnFileName.Text = "파일이름";
            // 
            // columnFileSize
            // 
            this.columnFileSize.Text = "파일크기";
            // 
            // columnFileDate
            // 
            this.columnFileDate.Text = "수정한날짜";
            // 
            // Client_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 571);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Client_Form";
            this.Text = "Client_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Client_Form_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IP_txt;
        private System.Windows.Forms.TextBox PATH_txt;
        private System.Windows.Forms.TextBox PORT_txt;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button openFd_btn;
        private System.Windows.Forms.Button pathOb_btn;
        private System.Windows.Forms.Button connectSv_btn;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem detail;
        private System.Windows.Forms.ToolStripMenuItem download;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolMenuDetail;
        private System.Windows.Forms.ToolStripMenuItem toolMenuEasy;
        private System.Windows.Forms.ToolStripMenuItem toolMenuSmallIcon;
        private System.Windows.Forms.ToolStripMenuItem toolMenuBigIcon;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ColumnHeader columnFileName;
        private System.Windows.Forms.ColumnHeader columnFileSize;
        private System.Windows.Forms.ColumnHeader columnFileDate;
    }
}

