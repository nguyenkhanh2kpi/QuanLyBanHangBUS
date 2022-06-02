using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyBanHang.Models;

namespace QuanLyBanHang.Gui
{
    public partial class GiftCard : Form
    {
        public GiftCard()
        {
            InitializeComponent();
        }
        public static string dirParameter = @"C:\Users\KHANH\OneDrive\Desktop\DeTaiWinF\git-remake\QuanLyBanHang\GiftCard\" + @"\file.txt";
        //Thong ke tong ket so Order tung khach hang da mua
        private void labelCustomerOrder_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var query = (from c in db.CustomerRanks
                             where c.reward >0
                             select new
                             {
                                 Id = c.id,
                                 Name = c.Customer.e_name,
                                 Phone = c.Customer.phone_number,
                                 Reward = c.reward,
                            }).ToList();
                dataGridView1.DataSource = query;

            }
        }

        //Giftcard loai Dong cho khach hang
        private void buttonGiftCard1_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var query = (from c in db.CustomerRanks
                             where c.reward >= 10 && c.reward<15
                             select new
                             {
                                 Id = c.id,
                                 Name = c.Customer.e_name,
                                 Phone = c.Customer.phone_number,
                                 Reward = c.reward,
                             }).ToList();
                dataGridView1.DataSource = query;
                foreach (var c in query)
                {
                    string n = c.Name;
                    string msg = "*PHIEU QUA TANG* " + "\n ******************* \n" + "Khach hang: " + c.Name + "\n Nhan duoc phieu qua tang mua do tri gia 50.000 vnd";
                    GiveGiftCard(n,msg);
                }
                
            }
        }   
        //Gift card loai Bac
        private void buttonGiftCard2_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var query = (from c in db.CustomerRanks
                             where c.reward >= 15 && c.reward <20
                             select new
                             {
                                 Id = c.id,
                                 Name = c.Customer.e_name,
                                 Phone = c.Customer.phone_number,
                                 Reward = c.reward,
                             }).ToList();
                dataGridView1.DataSource = query;
                foreach (var c in query)
                {
                    string n = c.Name;
                    string msg = "*PHIEU QUA TANG* " + "\n ******************* \n" + "Khach hang: " + c.Name + "\n Nhan duoc phieu qua tang mua do tri gia 100.000 vnd";
                    GiveGiftCard(n, msg);
                }
            }
        }
        //Gift card loai Gold
        private void buttonGiftcard3_Click(object sender, EventArgs e)
        {
            using (var db = new QuanLyBanHang1Entities())
            {
                var query = (from c in db.CustomerRanks
                             where c.reward >= 20
                             select new
                             {
                                 Id = c.id,
                                 Name = c.Customer.e_name,
                                 Phone = c.Customer.phone_number,
                                 Reward = c.reward,
                             }).ToList();
                dataGridView1.DataSource = query;
                foreach (var c in query)
                {
                    string n = c.Name;
                    string msg = "*PHIEU QUA TANG* " + "\n ******************* \n" + "Khach hang: " + c.Name + "\n Nhan duoc phieu qua tang mua do tri gia 200.000 vnd";
                    GiveGiftCard(n, msg);
                }
            }
        }
        //Save giftcard duoi dang txt
        public static async Task GiveGiftCard(String name, string text)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Gift Card";
            saveFile.FileName = @"C:\Users\KHANH\OneDrive\Desktop\DeTaiWinF\git-remake\QuanLyBanHang\GiftCard\" + name + ".txt";
            saveFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFile.DefaultExt = "txt";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                string path = saveFile.FileName;
                var write = new BinaryWriter(File.Create(path));
                MessageBox.Show("File has saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                write.Write(text);
                write.Dispose();

            }
        }
    }
}
