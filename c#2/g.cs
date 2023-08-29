using System;
using System.Windows.Forms;
using WMPLib;

namespace AudioWindow
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            var form = new Form
            {
                Text = "Аудио",
                Size = new System.Drawing.Size(800, 600)
            };


            var wmp = new WindowsMediaPlayer
            {
                URL = "F:/html fnafopediastore/music.mp3",
                Height = form.Height,
                Width = form.Width
            };


            var wmpControl = (Control)wmp;
            form.Controls.Add(wmpControl);


            wmp.controls.play();

            wmp.PlayStateChange += (state) =>
            {
                if (state == WMPPlayState.wmppsStopped)
                {
                    Application.Exit();
                }
            };


            Application.Run(form);
        }
    }
}