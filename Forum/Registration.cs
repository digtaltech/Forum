using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Forum
{
    
    public partial class Registration : Form
    {
        MySqlConnection con = new MySqlConnection(@"Database = mydb; Data source = 127.0.0.1; User Id = root; Password = root");

        public Registration()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Login_Form ssLogin = new Login_Form();
            ssLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO users (login, password) VALUES ('" + textLogin.Text + "', '" + textPassword.Text + "') ", con);
                MySqlDataReader read = cmd.ExecuteReader();
                MessageBox.Show("Вы успешно зарегистрировались ! Ожидайте подтверждение вашей учётной записи от администратора.");
                con.Close();
            }
            catch(MySqlException)
            {
                MessageBox.Show("Данные невалидны !");
                con.Close();
            }
        }
    }
}
