using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Client
{
    public partial class Client_Form2 : Form
    {
        public Client_Form2()
        {
            InitializeComponent();
        }

        public FileInfo fis;

        private void Client_Form2_Load(object sender, EventArgs e)
        {
            fileName_txt.Text = fis.Name;
            string type = fis.Name.Substring(fis.Name.Length - 4);
            switch (type)
            {
                case ".avi":
                    pictureBox1.Image = imageList1.Images[0];
                    break;
                case ".png":
                    pictureBox1.Image = imageList1.Images[2];
                    break;
                case ".mp3":
                    pictureBox1.Image = imageList1.Images[3];
                    break;
                case ".txt":
                    pictureBox1.Image = imageList1.Images[5];
                    break;
                default:
                    pictureBox1.Image = imageList1.Images[4];
                    break;
            }
            fileInfo_lb.Text = type.Substring(1);
            fileLocation_lb.Text = fis.FullName;
            fileSize_lb.Text = fis.Length.ToString();
            fileMakeDate_lb.Text = fis.CreationTime.ToString();
            fileAccessDate_lb.Text = fis.LastAccessTime.ToString();
            fileEditDate_lb.Text = fis.LastWriteTime.ToString();
        }

        private void Exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
