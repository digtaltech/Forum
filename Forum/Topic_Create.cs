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
    public partial class Topic_Create : Form
    {
        MySqlConnection con = new MySqlConnection(@"Database = mydb; Data source = 127.0.0.1; User Id = root; Password = root");
        string Category;
        string Topic;
        string TextPost;
        string Title;
        object ID;

        public Topic_Create()
        {
            InitializeComponent();
        }

        private void Topic_Create_Load(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Category FROM category", con);
            MySqlDataReader read = cmd.ExecuteReader();
            while(read.Read())
            {
                CategoryBox.Items.Add(read.GetValue(0).ToString());
            }
            con.Close();
        }

        private void CategoryBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Category = CategoryBox.SelectedItem.ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Topic = TopicBox.Text;
            TextPost = TextBox.Text;

            Title = "[" + Topic + "]  " + Login_Form.login + ": " + TextPost;

            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM category WHERE Category = '"+Category+"'  ", con);
            MySqlDataReader read = cmd.ExecuteReader();
            while(read.Read())
            {
                ID = read["Category_ID"];
                
            }
            con.Close();

            con.Open();
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO thread SET Topic = '"+Topic+"', Text = '"+TextPost+"', Poster = '"+Login_Form.login+ "', Title = '"+Title+"', Category_ID = '"+ID+"'   ", con);
            MySqlDataReader read1 = cmd1.ExecuteReader();
            MessageBox.Show("Тема успешно создана !");
            con.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
