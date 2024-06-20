using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nuka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создание кнопки "Вход"
            Button btnLogin = new Button();
            btnLogin.Text = "Вход";
            btnLogin.Location = new Point(50, 100);
            btnLogin.Size = new Size(150, 50);
            btnLogin.BackColor = Color.Yellow;
            btnLogin.Click += BtnLogin_Click;
            Controls.Add(btnLogin);

            // Создание кнопки "Закрыть"
            Button btnClose = new Button();
            btnClose.Text = "Закрыть";
            btnClose.Location = new Point(50, 160);
            btnClose.Size = new Size(150, 50);
            btnClose.BackColor = Color.Yellow;
            btnClose.Click += BtnClose_Click;
            Controls.Add(btnClose);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            // Закрытие текущей формы
            this.Hide();

            // Переход на форму 2
            Form2 form2 = new Form2();
            form2.FormClosed += (s, args) => this.Close(); // Закрытие текущей формы при закрытии формы 2
            form2.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Закрытие приложения
        }
    }
}