using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace DawnsburyCharacterManager
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            labelInfo.Text = "Dawnsbury Days Character Manager";
            labelsmallerinfo.Text = "Created by Chuji! \n\n" +
                "This is a small application I made for me and my friends to share our Dawnsbury Days characters more easily! I hope you find it useful <3 \n\n" +
                "Feel free to shoot me a message on social media or donate a Ko-fi if you like it! Do let me know if you find any bugs, too!";
        }

        private void labelInfo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkKofi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://ko-fi.com/chuji";
            
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // important for opening URLs
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open link: {ex.Message}");
            }
        }

        private void linkBsky_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://bsky.app/profile/chuji.bsky.social";

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // important for opening URLs
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open link: {ex.Message}");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void linkGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/Choojermelon/DawnsburyCharacterManager";

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true // important for opening URLs
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open link: {ex.Message}");
            }
        }
    }
}
