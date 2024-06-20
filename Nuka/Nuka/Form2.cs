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

namespace Nuka
{
    public partial class Form2 : Form
    {
        private TextBox textBox1;
        private Button button1;
        private ListBox listBox2;
        private Button buttonBack;
        private Button buttonAdminMode;

        public Form2()
        {
            InitializeComponent();
            InitializeAdditionalComponents();
        }

        private void InitializeAdditionalComponents()
        {
            // Initialize textBox1
            textBox1 = new TextBox();
            textBox1.Location = new Point(20, 20);
            textBox1.BackColor = Color.MidnightBlue;
            textBox1.ForeColor = Color.Yellow;
            this.Controls.Add(textBox1);

            // Initialize button1
            button1 = new Button();
            button1.Text = "Search";
            button1.Location = new Point(150, 20);
            button1.BackColor = Color.MidnightBlue;
            button1.ForeColor = Color.Yellow;
            button1.Click += Button1_Click;
            this.Controls.Add(button1);

            // Initialize listBox2
            listBox2 = new ListBox();
            listBox2.Location = new Point(20, 60);
            listBox2.Size = new Size(200, 200);
            listBox2.BackColor = Color.MidnightBlue;
            listBox2.ForeColor = Color.Yellow;
            this.Controls.Add(listBox2);

            // Initialize buttonBack
            buttonBack = new Button();
            buttonBack.Text = "Назад";
            buttonBack.Location = new Point(20, 270);
            buttonBack.BackColor = Color.MidnightBlue;
            buttonBack.ForeColor = Color.Yellow;
            buttonBack.Click += ButtonBack_Click;
            this.Controls.Add(buttonBack);

            // Initialize buttonAdminMode
            buttonAdminMode = new Button();
            buttonAdminMode.Text = "Admin mode";
            buttonAdminMode.Location = new Point(100, 270);
            buttonAdminMode.BackColor = Color.MidnightBlue;
            buttonAdminMode.ForeColor = Color.Yellow;
            buttonAdminMode.Click += ButtonAdminMode_Click;
            this.Controls.Add(buttonAdminMode);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Connexion à la base de données
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=tovar;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                // Ouvrir la connexion
                connection.Open();

                // Requête SQL pour récupérer les données
                string query = "SELECT Name FROM tovar";
                SqlCommand command = new SqlCommand(query, connection);

                // Exécuter la requête et récupérer les résultats
                SqlDataReader reader = command.ExecuteReader();

                // Ajouter les noms à la listBox1
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["Name"].ToString());
                }

                // Fermer le lecteur de données et la connexion
                reader.Close();
            }
            catch (Exception ex)
            {
                // Gestion des erreurs
                MessageBox.Show("Erreur lors de la connexion à la base de données : " + ex.Message);
            }
            finally
            {
                // Fermer la connexion
                connection.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string searchName = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(searchName))
            {
                listBox2.Items.Clear();

                // Connexion à la base de données
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=tovar;Integrated Security=True";
                SqlConnection connection = new SqlConnection(connectionString);

                try
                {
                    // Ouvrir la connexion
                    connection.Open();

                    // Requête SQL pour récupérer les données avec le nom spécifié
                    string query = "SELECT Id, Name, Price FROM tovar WHERE Name = @Name";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Name", searchName);

                    // Exécuter la requête et récupérer les résultats
                    SqlDataReader reader = command.ExecuteReader();

                    // Afficher les résultats dans listBox2
                    while (reader.Read())
                    {
                        listBox2.Items.Add(reader["Id"].ToString() + " - " + reader["Name"].ToString() + " - " + reader["Price"].ToString());
                    }

                    // Fermer le lecteur de données et la connexion
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Gestion des erreurs
                    MessageBox.Show("Erreur lors de la recherche dans la base de données : " + ex.Message);
                }
                finally
                {
                    // Fermer la connexion
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom à rechercher.");
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            // Retourner à Form1
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void ButtonAdminMode_Click(object sender, EventArgs e)
        {
            // Passer à Form3 et afficher un message
            Form4 form4 = new Form4();
            MessageBox.Show("Вы входите в режим Admin");
            form4.Show();
            this.Hide();
        }
    }
}