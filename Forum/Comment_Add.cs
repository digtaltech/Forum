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
    public partial class Comment_Add : Form
    {

        MySqlConnection con = new MySqlConnection(@"Database = mydb; Data source = 127.0.0.1; User Id = root; Password = root");


        public Comment_Add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO comment SET Poster = '"+Login_Form.login+"', Text = '"+textBox1.Text+"', Thread_ID = '"+Main.IDDE+"'  ", con);
                MySqlDataReader read = cmd.ExecuteReader();
                MessageBox.Show("Комментарий успешно добавлен");
                con.Close();
                this.Close();
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
