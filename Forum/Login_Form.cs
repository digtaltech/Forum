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
    public partial class Login_Form : Form
    {
        MySqlConnection con = new MySqlConnection(@"Database = mydb; Data source = 127.0.0.1; User Id = root; Password = root");

        public static object ID;
        string ID1;
        object Confirmed;
        public static string login;




        public Login_Form()
            
        {
            
            InitializeComponent();

        }

        private void Login_Form_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (textLogin.Text == "")
            {
                MessageBox.Show("Вы ввели неверный логин или пароль ");
            }
            else
            {
                try
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * , COUNT(*) FROM users WHERE login = '" + textLogin.Text + "'  ", con);
                    MySqlDataReader read = cmd.ExecuteReader();
                    while (read.Read())
                    {
                        ID = read["ID"];
                        ID1 = read["COUNT(*)"].ToString();

                        
                    }
                    con.Close();
                    if (ID1 == "0")
                    {
                        MessageBox.Show("Вы ввели неверный логин или пароль !");
                    }
                    else
                    {
                        try
                        {
                            con.Open();
                            MySqlCommand cmd1 = new MySqlCommand("SELECT Confirmed, COUNT(*) FROM users WHERE password = '" + textPassword.Text + "' AND ID = '" + ID + "'  ", con);
                            MySqlDataReader read1 = cmd1.ExecuteReader();
                            while (read1.Read())
                            {
                                Confirmed = read1["Confirmed"];
                                ID1 = read1["COUNT(*)"].ToString();

                            }
                            if (ID1 == "0")
                            {
                                MessageBox.Show("Вы ввели неверный логин или пароль !!");
                            }
                            else
                            {
                                if (Confirmed.ToString() == "0")
                                {
                                    MessageBox.Show("Ваша учётная запись ещё не подтверждена ! Ожидайте подтверждения учётной записи от администратора");
                                }
                                else
                                {
                                    MessageBox.Show("Вы вошли как  " + textLogin.Text.ToString() + " ");
                                    if (ID.ToString() == "1")
                                    {
                                        login = textLogin.Text;
                                        this.Hide();
                                        Admin_Selected ssAdmin_Selected = new Admin_Selected();
                                        ssAdmin_Selected.Show();
                                    }
                                    else
                                    {
                                        login = textLogin.Text;

                                        this.Hide();
                                        Main ssMain = new Main();
                                        ssMain.Show();
                                    }
                                }
                            }
                            con.Close();
                        }
                        catch (MySqlException)
                        {
                            MessageBox.Show("Вы ввели неверный логин или пароль !!");
                            con.Close();
                        }
                    }

                }
                catch(MySqlException)
                {
                    MessageBox.Show("Вы ввели неверный логин или пароль !");
                    con.Close();
                }
            }
            
        }

        private void textLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration ssReg = new Registration();
            ssReg.Show();
        }
    }
}
