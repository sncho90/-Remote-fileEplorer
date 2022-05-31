
namespace Server
{
    partial class Server_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IP_txt = new System.Windows.Forms.TextBox();
            this.PORT_txt = new System.Windows.Forms.TextBox();
            this.Path_txt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ServerOn_btn = new System.Windows.Forms.Button();
            this.Path_btn = new System.Windows.Forms.Button();
            this.log_txt = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "PORT";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "PATH ";
            // 
            // IP_txt
            // 
            this.IP_txt.Location = new System.Drawing.Point(90, 12);
            this.IP_txt.Name = "IP_txt";
            this.IP_txt.Size = new System.Drawing.Size(476, 28);
            this.IP_txt.TabIndex = 3;
            // 
            // PORT_txt
            // 
            this.PORT_txt.Location = new System.Drawing.Point(90, 80);
            this.PORT_txt.Name = "PORT_txt";
            this.PORT_txt.Size = new System.Drawing.Size(476, 28);
            this.PORT_txt.TabIndex = 4;
            // 
            // Path_txt
            // 
            this.Path_txt.Location = new System.Drawing.Point(90, 148);
            this.Path_txt.Name = "Path_txt";
            this.Path_txt.ReadOnly = true;
            this.Path_txt.Size = new System.Drawing.Size(476, 28);
            this.Path_txt.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "log";
            // 
            // ServerOn_btn
            // 
            this.ServerOn_btn.Location = new System.Drawing.Point(617, 33);
            this.ServerOn_btn.Name = "ServerOn_btn";
            this.ServerOn_btn.Size = new System.Drawing.Size(96, 55);
            this.ServerOn_btn.TabIndex = 7;
            this.ServerOn_btn.Text = "서버켜기";
            this.ServerOn_btn.UseVisualStyleBackColor = true;
            this.ServerOn_btn.Click += new System.EventHandler(this.ServerOn_btn_Click);
            // 
            // Path_btn
            // 
            this.Path_btn.Location = new System.Drawing.Point(617, 141);
            this.Path_btn.Name = "Path_btn";
            this.Path_btn.Size = new System.Drawing.Size(96, 39);
            this.Path_btn.TabIndex = 8;
            this.Path_btn.Text = "경로선택";
            this.Path_btn.UseVisualStyleBackColor = true;
            this.Path_btn.Click += new System.EventHandler(this.Path_btn_Click);
            // 
            // log_txt
            // 
            this.log_txt.Location = new System.Drawing.Point(26, 222);
            this.log_txt.Multiline = true;
            this.log_txt.Name = "log_txt";
            this.log_txt.Size = new System.Drawing.Size(687, 277);
            this.log_txt.TabIndex = 9;
            // 
            // Server_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 537);
            this.Controls.Add(this.log_txt);
            this.Controls.Add(this.Path_btn);
            this.Controls.Add(this.ServerOn_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Path_txt);
            this.Controls.Add(this.PORT_txt);
            this.Controls.Add(this.IP_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Server_Form";
            this.Text = "Server_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_Form_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IP_txt;
        private System.Windows.Forms.TextBox PORT_txt;
        private System.Windows.Forms.TextBox Path_txt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button ServerOn_btn;
        private System.Windows.Forms.Button Path_btn;
        private System.Windows.Forms.TextBox log_txt;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

