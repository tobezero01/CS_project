using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TH3_B3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadDrives();
        }
        private void LoadDrives()
        {
            // Xóa danh sách các mục hiện có trong ComboBox cbODia
            cbODia.Items.Clear();

            // Lấy danh sách các ổ đĩa có trong máy tính
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Thêm các ổ đĩa vào ComboBox
            foreach (DriveInfo drive in drives)
            {
                cbODia.Items.Add(drive.Name);
            }
        }
        // sk khi chon 1 bai hat trong listbox
        private void lbTapTin_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string selectedSong = lbTapTin.SelectedItem.ToString();
            string[] s = selectedSong.Split('.');
            if (!string.IsNullOrEmpty(selectedSong))
            {
                // Khi chọn một bài hát, tải lời bài hát và chơi bài hát
                loadLyrics(s[0] + ".txt");
                playSongs(selectedSong);
            }
        }
      
        private void playSongs(string songPath) 
        {
            axWindowsMediaPlayer1.URL = songPath;
        }
        private string getODia() { return cbODia.Text + @"\" ; }
        private void cbODia_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbThuMuc.Items.Clear();
            lbTapTin.Items.Clear();
            DirectoryInfo directory = new DirectoryInfo(getODia());
            DirectoryInfo[] directories = directory.GetDirectories("*.*");
            FileInfo[] files = directory.GetFiles();

            foreach (DirectoryInfo d in directories)
            {
                cbThuMuc.Items.Add(d.Name);               
            }          
            
        }

        private void loadLyrics(string LyricsSongPath)
        {                     
            try
            {              
                FileStream fs = new FileStream(LyricsSongPath, FileMode.Open);
                StreamReader rd = new StreamReader(fs, Encoding.UTF8);
                string giaTri = rd.ReadToEnd();
                rtbLyrics.Text = giaTri;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Day khong phai file bai hat " );
            }
        }

        private void cbThuMuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbTapTin.Items.Clear();
            rtbLyrics.Text = "";
            string[] songsFile = Directory.GetFiles(cbODia.Text + cbThuMuc.Text,"*.mp3");
            foreach(string s in songsFile)
            {
                lbTapTin.Items.Add(s );
            }
            
        }
    }
}
