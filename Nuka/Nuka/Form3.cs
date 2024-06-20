using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Nuka
{
    public partial class Form3 : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=tovar;Integrated Security=True";
        private TextBox txtName;
        private TextBox txtPrice;

        public Form3()
        {
            InitializeComponent();
            LoadData();
            CreateControls();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            string query = "SELECT * FROM tovar";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void CreateControls()
        {
            // Create textbox for Name
            txtName = new TextBox();
            txtName.Location = new Point(50, 50);
            txtName.BackColor = Color.Maroon;
            txtName.ForeColor = Color.Yellow;
            Controls.Add(txtName);

            // Create textbox for Price
            txtPrice = new TextBox();
            txtPrice.Location = new Point(50, 80);
            txtPrice.BackColor = Color.Maroon;
            txtPrice.ForeColor = Color.Yellow;
            Controls.Add(txtPrice);

            // Create button for Add
            Button btnAdd = new Button();
            btnAdd.Text = "Добавить";
            btnAdd.Location = new Point(20, 110);
            btnAdd.BackColor = Color.Maroon;
            btnAdd.ForeColor = Color.Yellow;
            btnAdd.Click += BtnAdd_Click;
            Controls.Add(btnAdd);

            // Create button for Delete
            Button btnDelete = new Button();
            btnDelete.Text = "Удалить";
            btnDelete.Location = new Point(100, 110);
            btnDelete.BackColor = Color.Maroon;
            btnDelete.ForeColor = Color.Yellow;
            btnDelete.Click += BtnDelete_Click;
            Controls.Add(btnDelete);

            // Create button for Back
            Button btnBack = new Button();
            btnBack.Text = "Назад";
            btnBack.Location = new Point(20, 140);
            btnBack.BackColor = Color.Maroon;
            btnBack.ForeColor = Color.Yellow;
            btnBack.Click += BtnBack_Click;
            Controls.Add(btnBack);

            // Create button for Save
            Button btnSave = new Button();
            btnSave.Text = "Save";
            btnSave.Location = new Point(100, 140);
            btnSave.BackColor = Color.Maroon;
            btnSave.ForeColor = Color.Yellow;
            btnSave.Click += BtnSave_Click;
            Controls.Add(btnSave);

            // Set dataGridView color
            dataGridView1.BackgroundColor = Color.Maroon;
            dataGridView1.ForeColor = Color.Black;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string price = txtPrice.Text;

            string query = "INSERT INTO tovar (Name, Price) VALUES (@Name, @Price)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Price", price);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            LoadData();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                string id = dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString();

                string query = "DELETE FROM tovar WHERE Id = @Id";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                LoadData();
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            // Navigate back to Form2
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Navigate to Form5
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
    }
}