using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using PacketClass;
using System.Diagnostics;

namespace Client
{
    public partial class Client_Form : Form
    {
        public Client_Form()
        {
            InitializeComponent();
        }

        private void DlPt_txt_TextChanged(object sender, EventArgs e)
        {

        }

        public string selected = "";
        public string servPath = "";

        public NetworkStream m_Stream;
        public StreamReader m_Read;
        public StreamWriter m_Write;
        private Thread m_ThReader;

        public bool m_bConnect = false;
        public bool m_sConnect = false;

        TcpClient m_Client;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        public Initialize m_initializeC;
        public Browser m_browserPath;

        public void Connect()
        {
            m_Client = new TcpClient();
            int PORT = int.Parse(PORT_txt.Text);

            try
            {
                m_Client.Connect(IP_txt.Text, PORT);
            }
            catch
            {
                m_bConnect = false;
                return;
            }
            m_bConnect = true;

            m_Stream = m_Client.GetStream();
            m_Read = new StreamReader(m_Stream);
            m_Write = new StreamWriter(m_Stream);

            if (!m_bConnect)
                return;

            Initialize Init = new Initialize();
            Init.Type = (int)PacketType.Init;
            Init.buffer = "초기화 데이터 요청...";
            Packet.Serialize(Init).CopyTo(sendBuffer, 0);
            Send();

            int nRead = 0;
            if(m_bConnect)
            {
                try
                {
                    nRead = 0;
                    nRead = this.m_Stream.Read(readBuffer, 0, 1024 * 4);
                }
                catch
                {
                    m_bConnect = false;
                    m_Stream = null;
                }
                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                if((int)packet.Type == (int)PacketType.Init)
                {
                    m_initializeC = (Initialize)Packet.Desserialize(readBuffer);
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        servPath = m_initializeC.buffer;
                    }));
                    TreeNode root = TreeView.Nodes.Add(servPath);
                    root.ImageIndex = 1;
                    TreeView.SelectedNode = root;
                    root.SelectedImageIndex = root.ImageIndex;
                    root.Nodes.Add("");
                }
            }
            else
            {
                m_bConnect = false;
                m_sConnect = false;
                m_Client.Close();
                m_Stream.Close();
            }
        }

        public void setPlus(TreeNode node)
        {
            if(m_bConnect)
            {
                Browser browser = new Browser();
                browser.Type = (int)PacketType.Explorer;
                browser.fullpath = node.FullPath;

                Packet.Serialize(browser).CopyTo(sendBuffer, 0);
                Send();

                int nRead = 0;
                try
                {
                    nRead = 0;
                    nRead = this.m_Stream.Read(readBuffer, 0, 1024 * 4);
                }
                catch
                {
                    m_bConnect = false;
                    m_Stream = null;
                }

                Packet packet = (Packet)Packet.Desserialize(readBuffer);
                if((int)packet.Type == (int)PacketType.Explorer)
                {
                    m_browserPath = (Browser)Packet.Desserialize(readBuffer);
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        if (m_browserPath.di.Length > 1)
                        {
                            node.Nodes.Add("");
                        }
                    }));
                }
            }
        }

        public int fileImage(string path)
        {
            int index = 0;
            string type = path.Substring(path.Length - 4);
            switch (type)
            {
                case ".avi":
                    index = 0; 
                    break;
                case ".png":
                    index = 2; 
                    break;
                case ".mp3":
                    index = 3;
                    break;
                case ".txt":
                    index = 5; 
                    break;
                default:
                    index = 4; 
                    break;
            }
            return index;
        }

        public void OpenFiles()
        {
            ListView.SelectedListViewItemCollection siList = listView1.SelectedItems;

            foreach (ListViewItem item in siList)
                OpenItem(item);
        }

        public void OpenItem(ListViewItem Item)
        {
            TreeNode node = TreeView.SelectedNode;
            TreeNode child;

            if (Item.Tag.ToString() == "D")
            {
                node.Expand();
                child = node.FirstNode;

                while (child != null)
                {
                    if (child.Text == Item.Text)
                    {
                        TreeView.SelectedNode = child;
                        TreeView.Focus();
                        break;
                    }
                    child = child.NextNode;
                }
            }
            else if (Item.Tag.ToString() == "F")
            {
                if (m_bConnect)
                {
                    Detail dt = new Detail();
                    dt.Type = (int)PacketType.DetailAndDownload;
                    dt.message = "상세정보 데이터 요청..";

                    Packet.Serialize(dt).CopyTo(this.sendBuffer, 0);
                    this.Send();

                    Client_Form2 detail = new Client_Form2();

                    string path = node.FullPath + "\\" + Item.Text;

                    detail.fis = new FileInfo(path);
                    detail.Show();
                }
            }
        }



        public void Disconnect()
        {
            if (!m_bConnect)
                return;
            m_bConnect = false;

            m_Read.Close();
            m_Write.Close();
            m_Stream.Close();
            m_ThReader.Abort();
        }

        public void Send()
        {
            this.m_Stream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_Stream.Flush();

            for (int i = 0; i < 1024 * 4; i++)
            {
                this.sendBuffer[i] = 0;
            }
        }

        private void pathOb_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            selected = dialog.SelectedPath;
            PATH_txt.Text = selected;
        }

        private void connectSv_btn_Click(object sender, EventArgs e)
        {
            if(connectSv_btn.Text == "서버연결")
            {
                if (selected == "")
                    MessageBox.Show("경로를 선택해주세요.");
                else
                {
                    Connect();
                    if(m_bConnect)
                    {
                        connectSv_btn.Text = "서버끊기";
                        connectSv_btn.ForeColor = Color.Red;
                    }
                }
            }
            else
            {
                Disconnect();
                connectSv_btn.Text = "서버연결";
                connectSv_btn.ForeColor = Color.Black;
            }
        }

        private void Client_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        private void TreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node;

            if (m_bConnect)
            {
                e.Node.Nodes.Clear();

                Browser Brows = new Browser();
                Brows.Type = (int)PacketType.Explorer;
                Brows.message = "beforeExpand 데이터 요청..";
                Brows.num = 1;
                Brows.fullpath = e.Node.FullPath;

                Packet.Serialize(Brows).CopyTo(this.sendBuffer, 0);
                this.Send();

                int nRead = 0;
                try
                {
                    nRead = 0;
                    nRead = this.m_Stream.Read(readBuffer, 0, 1024 * 4);
                }
                catch
                {
                    this.m_bConnect = false;
                    this.m_Stream = null;
                }
                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                if ((int)packet.Type == (int)PacketType.Explorer)
                {
                    this.m_browserPath = (Browser)Packet.Desserialize(this.readBuffer);
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        foreach (DirectoryInfo dirs in this.m_browserPath.di)
                        {
                            node = e.Node.Nodes.Add(dirs.Name);
                            setPlus(node);
                        }
                    }));
                }
            }
        }

        private void TreeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            ListViewItem item;

            if(m_bConnect)
            {
                Browser browser = new Browser();
                browser.Type = (int)PacketType.Explorer;
                browser.fullpath = e.Node.FullPath;
                browser.num = 2;

                Packet.Serialize(browser).CopyTo(sendBuffer, 0);
                Send();

                listView1.Items.Clear();

                int nRead = 0;
                try
                {
                    nRead = 0;
                    nRead = m_Stream.Read(readBuffer, 0, 1024 * 4);
                }
                catch
                {
                    m_bConnect = false;
                    m_Stream = null;
                }

                Packet packet = (Packet)Packet.Desserialize(readBuffer);
                if ((int)packet.Type == (int)PacketType.Explorer)
                {
                    m_browserPath = (Browser)Packet.Desserialize(readBuffer);

                    this.Invoke(new MethodInvoker(delegate ()
                    {
                    }));

                    foreach (DirectoryInfo tdis in m_browserPath.di)
                    {
                        item = listView1.Items.Add(tdis.Name);
                        item.SubItems.Add("");
                        item.SubItems.Add(tdis.LastWriteTime.ToString());
                        item.ImageIndex = 1;
                        item.Tag = "D";
                    }

                    foreach(FileInfo fis in m_browserPath.fi)
                    {
                        item = listView1.Items.Add(fis.Name);
                        item.SubItems.Add(fis.Length.ToString());
                        item.SubItems.Add(fis.LastWriteTime.ToString());
                        item.ImageIndex = fileImage(fis.Name);
                        item.Tag = "F";
                    }
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            OpenFiles();
        }

        private void toolMenuDetail_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }

        private void toolMenuEasy_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void toolMenuSmallIcon_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void toolMenuBigIcon_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void detail_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection sList = listView1.SelectedItems;
            ListViewItem Item;
            TreeNode node = TreeView.SelectedNode;
            if(sList.Count == 1)
            {
                Item = sList[0];
                Detail dt = new Detail();
                dt.Type = (int)PacketType.DetailAndDownload;
                dt.message = "상세정보 데이터 요청..";

                Packet.Serialize(dt).CopyTo(this.sendBuffer, 0);
                this.Send();

                Client_Form2 detail = new Client_Form2();

                string path = node.FullPath + "\\" + Item.Text;

                detail.fis = new FileInfo(path);
                detail.Show();
            }
        }

        private void download_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection sList = listView1.SelectedItems;
            ListViewItem Item;
            TreeNode node = TreeView.SelectedNode;

            Item = sList[0];
            string path = node.FullPath + "\\" + Item.Text;

            if (sList.Count == 1)
            {
                if (Item.Tag.ToString().Equals("D"))
                    MessageBox.Show("폴더는 다운로드를 지원하지 않습니다.");
                else if(Item.Tag.ToString().Equals("F"))
                {
                    try
                    {
                        File.Copy(path, PATH_txt.Text + "\\" + Item.Text);
                    }
                    catch(Exception error)
                    {
                        MessageBox.Show("다운로드 실패 : " + error);
                        return;
                    }

                    Detail dt = new Detail();
                    dt.Type = (int)PacketType.DetailAndDownload;
                    dt.message = path + "데이터 다운로드 완료...";

                    Packet.Serialize(dt).CopyTo(this.sendBuffer, 0);
                    this.Send();
                }
            }
        }
    }
}
