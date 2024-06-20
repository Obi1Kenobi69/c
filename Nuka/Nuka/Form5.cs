using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Nuka
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Add buttons
            Button btnSaveToText = new Button();
            btnSaveToText.Text = "Text File";
            btnSaveToText.Location = new Point(10, 45);
            btnSaveToText.Click += new EventHandler(SaveToText);
            btnSaveToText.BackColor = Color.Yellow;
            this.Controls.Add(btnSaveToText);

            Button btnSaveToExcel = new Button();
            btnSaveToExcel.Text = "Excel";
            btnSaveToExcel.Location = new Point(10, 70);
            btnSaveToExcel.Click += new EventHandler(SaveToExcel);
            btnSaveToExcel.BackColor = Color.Yellow;
            this.Controls.Add(btnSaveToExcel);

            Button btnBack = new Button();
            btnBack.Text = "Назад";
            btnBack.Location = new Point(10, 100);
            btnBack.Click += new EventHandler(GoBack);
            btnBack.BackColor = Color.Yellow;
            this.Controls.Add(btnBack);
        }

        private void SaveToText(object sender, EventArgs e)
        {
            // Database connection
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=tovar;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create text file
                string filePath = @"C:\Users\glnnn\OneDrive\Документы\output.txt";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Write table content to the file
                    string query = "SELECT * FROM tovar";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        writer.WriteLine($"{reader["id"]}, {reader["name"]}, {reader["price"]}");
                    }
                }
            }
        }

        private void SaveToExcel(object sender, EventArgs e)
        {
            // Database connection
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=tovar;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create Excel application
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Sheets[1];

                // Write table content to Excel
                string query = "SELECT * FROM tovar";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                int row = 1;
                while (reader.Read())
                {
                    worksheet.Cells[row, 1] = reader["id"].ToString();
                    worksheet.Cells[row, 2] = reader["name"].ToString();
                    worksheet.Cells[row, 3] = reader["price"].ToString();
                    row++;
                }

                // Save Excel file
                string filePath = "output.xlsx";
                workbook.SaveAs(filePath);

                // Close Excel application
                workbook.Close();
                excelApp.Quit();
            }
        }

        private void GoBack(object sender, EventArgs e)
        {
            // Go back to Form3
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }
    }
}