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
    public partial class Admin : Form
    {
        MySqlConnection con = new MySqlConnection(@"Database = mydb; Data source = 127.0.0.1; User Id = root; Password = root");
        
        public Admin()
        {
            InitializeComponent();

            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mydbDataSet.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.mydbDataSet.users);

            IDBox.SelectedIndex = -1;
            IDBox.Items.Clear();

            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT ID FROM users ORDER BY ID ASC", con);
            MySqlDataReader read = cmd.ExecuteReader();

            while(read.Read())
            {
                IDBox.Items.Add(read.GetValue(0).ToString());
                
            }
            con.Close();
            
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Admin_Load(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ID = IDBox.SelectedItem.ToString();

            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE users SET Confirmed = 1 WHERE ID = '"+ID+"'  ", con);
            MySqlDataReader read = cmd.ExecuteReader();
            MessageBox.Show("OK");
            con.Close();
            timer1.Start();
        }
    }
}
