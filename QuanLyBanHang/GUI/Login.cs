using QuanLyBanHang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.BUS;
namespace QuanLyBanHang.Gui
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        // Bấm vào nút Login
        private void Login_button_Click(object sender, EventArgs e)
        {
            LoginBUS login = new LoginBUS();
            var email = emailTxt.Text.Trim();
            var password = passwordTxt.Text.Trim();
            var per = login.CheckPerson(email, password);
            if (per != null)
            {
                if (per.e_status == "active")
                {
                    ResetRankBUS res = new ResetRankBUS();
                    if (per.email == "hoang@gmail.com")
                    {
                        var form1 = new Admin();
                        res.resetEachMonth();
                        form1.Show();
                        this.Visible = false;
                    }
                    else
                    {
                        var form1 = new Home(per);
                        res.resetEachMonth();
                        form1.Show();
                        this.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Your Account Is Not Active");
                }
            }
            else
            {
                MessageBox.Show("Your Account or Passwork is Invalid!!!");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (passwordTxt.PasswordChar.ToString().Contains('*'))
            {
                passwordTxt.PasswordChar = (char)0;
                pictureBox3.Image = Properties.Resources.open_eye;
            }
            else
            {
                passwordTxt.PasswordChar = '*';
                pictureBox3.Image = Properties.Resources.visibility;
            }
        }
    }
}
