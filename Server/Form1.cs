using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using PacketClass;

namespace Server
{
    public partial class Server_Form : Form
    {
        public Server_Form()
        {
            InitializeComponent();
        }

        public string selected = "";

        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;

        private Thread m_ThReader;

        public bool m_bStop = false;
        public bool m_bConnect = false;

        private TcpListener m_listener;
        private Thread m_thServer;

        TcpClient m_Client;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        public Initialize m_initialize;
        public Browser m_browser;
        public Detail m_detail;

        private void Path_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            selected = dialog.SelectedPath;
            Path_txt.Text = selected;
            log_txt.AppendText(selected + "로 경로가 수정되었습니다.\r\n");
        }

        public void ServerStart()
        {
            int PORT = int.Parse(PORT_txt.Text);
            m_Client = null;

            try
            {
                m_listener = new TcpListener(PORT);
                m_listener.Start();
                m_bStop = true;
                log_txt.AppendText("클라이언트 접속 대기중...\r\n");

                while(m_bStop)
                {
                    m_Client = this.m_listener.AcceptTcpClient();


                    if (m_Client.Connected)
                    {
                        m_bConnect = true;
                        log_txt.AppendText("클라이언트 접속\r\n");

                        m_Stream = m_Client.GetStream();
                        m_Read = new StreamReader(m_Stream);
                        m_Write = new StreamWriter(m_Stream);

                        m_thServer = new Thread(new ThreadStart(Run));
                        m_thServer.Start();
                    }
                }
                
            }
            catch
            {
                log_txt.AppendText("서버 생성 실패\r\n");
                m_listener.Stop();
                
                if(m_Client.Connected)
                {
                    this.m_bConnect = false;
                    this.m_Client.Close();
                    this.m_Stream.Close();
                    this.m_thServer.Abort();
                }

                return;
            }
        }

        public void ServerStop()
        {
            if (!m_bStop)
                return;

            m_bConnect = false;

            m_listener.Stop();

            m_Read.Close();
            m_Write.Close();

            m_Stream.Close();

            m_ThReader.Abort();
            m_thServer.Abort();

            log_txt.AppendText("서버 종료\r\n");
        }

        public void Send()
        {
            this.m_Stream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_Stream.Flush();

            for(int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        public void Run()
        {
            int nRead = 0;
            while(m_bConnect)
            {
                try
                {
                    nRead = 0;
                    nRead = this.m_Stream.Read(readBuffer, 0, 1024 * 4);
                }
                catch
                {
                    this.m_bConnect = false;
                    this.log_txt.AppendText("데이터 송신 에러\r\n");
                    this.m_Stream = null;
                }
                if (nRead == 0)
                    this.m_bConnect = false;
                else
                {
                    Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                    switch((int)packet.Type)
                    {
                        case (int)PacketType.Init:
                            {
                                log_txt.AppendText("초기화 데이터 요청\r\n");
                                Initialize Path = new Initialize();
                                Path.Type = (int)PacketType.Init;
                                Path.buffer = selected;

                                Packet.Serialize(Path).CopyTo(this.sendBuffer, 0);
                                this.Send();
                                break;
                            }
                        case (int)PacketType.Explorer:
                            {
                                this.m_browser = (Browser)Packet.Desserialize(this.readBuffer);
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    Browser browser = new Browser();
                                    browser.Type = (int)PacketType.Explorer;
                                    DirectoryInfo dir = new DirectoryInfo(this.m_browser.fullpath);
                                    browser.di = dir.GetDirectories();

                                    if (this.m_browser.num == 2)
                                    {
                                        log_txt.AppendText("beforeSelect 데이터 요청\r\n");
                                        browser.fi = dir.GetFiles();
                                    }
                                    else if (this.m_browser.num == 1) 
                                    {
                                        log_txt.AppendText("beforeExpand 데이터 요청..\r\n");
                                    }
                                    Packet.Serialize(browser).CopyTo(this.sendBuffer, 0);
                                    this.Send();
                                }));
                                break;
                            }
                        case (int)PacketType.DetailAndDownload:
                            {
                                this.m_detail = (Detail)Packet.Desserialize(this.readBuffer);
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    this.log_txt.AppendText(this.m_detail.message + Environment.NewLine);
                                }));
                                break;
                            }
                    }
                }
            }
        }

        private void ServerOn_btn_Click(object sender, EventArgs e)
        {
            if(ServerOn_btn.Text == "서버켜기")
            {
                if (selected == "")
                    MessageBox.Show("경로를 선택해주세요.");
                else
                {
                    m_thServer = new Thread(new ThreadStart(ServerStart));
                    m_thServer.Start();

                    ServerOn_btn.Text = "서버끊기";
                    ServerOn_btn.ForeColor = Color.Red;
                }
            }
            else
            {
                ServerStop();
                ServerOn_btn.Text = "서버켜기";
                ServerOn_btn.ForeColor = Color.Black;
            }
        }

        private void Server_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            ServerStop();
        }
    }
}
