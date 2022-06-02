using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using AForge;
using ZXing;
using QuanLyBanHang.Models;
using QuanLyBanHang.Gui;
namespace QuanLyBanHang.Gui
{
    public partial class ScanForm : Form
    {
        public ScanForm()
        {
            InitializeComponent();
        }
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice videoCaptureDevice;
        Bitmap bitmap;
        public string code;
        private void ScanForm_Load(object sender, EventArgs e)
        {
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filterInfoCollection)
                camComboBox.Items.Add(device.Name);
            camComboBox.SelectedIndex = 0;
            videoCaptureDevice = new VideoCaptureDevice(filterInfoCollection[camComboBox.SelectedIndex].MonikerString);
            videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            videoCaptureDevice.Start();
        }
        private void VideoCaptureDevice_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            bitmap = (Bitmap)eventArgs.Frame.Clone();
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(bitmap);
            pictureBox1.Image = bitmap;
            if (result != null)
            {
                videoCaptureDevice.SignalToStop();
                videoCaptureDevice.NewFrame -= new NewFrameEventHandler(VideoCaptureDevice_NewFrame);
                videoCaptureDevice = null;
                ClearImage();
                code = result.ToString();
                this.Invoke(new EventHandler(
                            delegate
                            {
                                Close(); // Entering with a "Step Into" here it crashes.
                            }
                            ));
            }
        }
        private void ScanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoCaptureDevice != null)
            {
                if (videoCaptureDevice.IsRunning)
                {
                    videoCaptureDevice.Stop();
                }
                ClearImage();
            }
        }
        public void ClearImage()
        {
            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
        }
    }
}
