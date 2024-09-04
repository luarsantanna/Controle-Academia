using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace CONTROLE_ACADEMIA.visao
{
    public partial class FormWebCam : Form
    {
        public FormWebCam()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private FilterInfoCollection VideoDevices;
        private VideoCaptureDevice VideoSource;
        private void FormWebCam_Load(object sender, EventArgs e)
        {
            VideoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo item in VideoDevices) 
            {
                lsDevices.Items.Add(item.Name);
            }
            if(lsDevices.Items.Count==0)
            {
                MessageBox.Show("nenhuma camera encontrada");
                pbFoto.Image=null;
                this.Dispose();
            }
            lsDevices.SelectedIndex = 0;


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if(VideoSource == null)
            {
                VideoSource = new VideoCaptureDevice(VideoDevices[lsDevices.SelectedIndex].MonikerString);
                VideoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
                VideoSource.Start();
            
            }

        }

        void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pbVideo.Image = bitmap;
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            if (VideoSource != null && VideoSource.IsRunning) 
            {
                VideoSource.Stop();
                VideoSource = null;
                pbVideo.CreateGraphics().Clear(Color.SteelBlue);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if(VideoSource != null && VideoSource.IsRunning)
            {
                VideoSource.Stop();
                pbVideo = null;
                Application.DoEvents();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            base.OnFormClosing(e);
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            pbFoto.Image = pbVideo.Image;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            btnStop_Click(sender, e);
            this.Dispose();

        }
             
    }
}
