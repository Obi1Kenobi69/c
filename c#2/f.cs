using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageWindow
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
                Text = "Картинка",
                Size = new Size(800, 600)
            };

            var pictureBox = new PictureBox
            {
                Image = Image.FromFile("F:/html fnafopediastore/fon.jpg"),
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
            };

            form.Controls.Add(pictureBox);

            Application.Run(form);
        }
    }
}