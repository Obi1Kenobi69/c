using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Nuka
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            // Создание кнопки "Вход"
            button1 = new Button();
            button1.Text = "Вход";
            button1.Location = new System.Drawing.Point(100, 100);
            button1.Size = new System.Drawing.Size(100, 30);
            button1.Click += button1_Click;
            button1.BackColor = System.Drawing.Color.MidnightBlue;
            button1.ForeColor = System.Drawing.Color.Yellow;
            Controls.Add(button1);

            // Создание текстбокса для логина
            textBox1 = new TextBox();
            textBox1.Location = new System.Drawing.Point(50, 50);
            textBox1.Size = new System.Drawing.Size(200, 20);
            textBox1.BackColor = System.Drawing.Color.MidnightBlue;
            textBox1.ForeColor = System.Drawing.Color.Yellow;
            Controls.Add(textBox1);

            // Создание текстбокса для пароля
            textBox2 = new TextBox();
            textBox2.Location = new System.Drawing.Point(50, 80);
            textBox2.Size = new System.Drawing.Size(200, 20);
            textBox2.BackColor = System.Drawing.Color.MidnightBlue;
            textBox2.ForeColor = System.Drawing.Color.Yellow;
            Controls.Add(textBox2);

            // Изменение стиля формы
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ForeColor = System.Drawing.Color.Yellow;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            if (login == "naruto" && password == "12345")
            {
                this.Hide();
                Form3 form3 = new Form3();
                form3.Show();
                form3.Text = "Вы вошли в Admin";
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}