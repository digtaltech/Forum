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


    public partial class Main : Form
    {

        MySqlConnection con = new MySqlConnection(@"Database = mydb; Data source = 127.0.0.1; User Id = root; Password = root");
        object CategoryID;
        object ThreadID;
        string Topic;
        string Poster;
        string TextPost;
        string Posted_Time;
        string query;
        public static string IDDE;// id темы
        string IDAR; 

        public Main()
        {

            InitializeComponent();




        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mydbDataSet.boat". При необходимости она может быть перемещена или удалена.
            this.boatTableAdapter.Fill(this.mydbDataSet.boat);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mydbDataSet.users". При необходимости она может быть перемещена или удалена.
            this.usersTableAdapter.Fill(this.mydbDataSet.users);

            if (Login_Form.ID.ToString() == "1")
            {
                button4.Visible = true;
            }

            listBox1.Items.Clear();
            

            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Category FROM category", con);
            MySqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                listBox1.Items.Add(read.GetValue(0).ToString());
            }
            con.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Topic_label.Visible = false;
            back_button.Visible = false;
            button2.Visible = false;
            

            listBox2.Items.Clear();
            listBox3.Items.Clear();

            object fill = listBox1.SelectedItem;

            con.Open();
            MySqlCommand cmd1 = new MySqlCommand("SELECT Category_ID FROM category WHERE Category = '" + fill + "'   ", con);
            MySqlDataReader read1 = cmd1.ExecuteReader();
            while (read1.Read())
            {
                CategoryID = read1["Category_ID"];
            }
            con.Close();

            
            con.Open();
            MySqlCommand cmd2 = new MySqlCommand("SELECT * FROM thread WHERE Category_ID = '" + CategoryID + "'  ", con);
            MySqlDataReader read2 = cmd2.ExecuteReader();
            while (read2.Read())
            {
                
                Topic = read2["Topic"].ToString();
                Poster = read2["Poster"].ToString();
                TextPost = read2["Text"].ToString();
                ThreadID = read2["Text"].ToString();



                query = "[" + Topic + "]  " + Poster + ": " + TextPost;

                

                listBox2.Items.Add(query);


            }
            con.Close();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            Topic_label.Visible = true;
            back_button.Visible = true;
            button2.Visible = true;
            button3.Visible = false;

            listBox3.Items.Clear();

            

            IDAR = listBox2.SelectedItem.ToString();


            con.Open();
            MySqlCommand cmd3 = new MySqlCommand("SELECT * FROM thread WHERE Title = '" + IDAR + "'  ", con);
            MySqlDataReader read3 = cmd3.ExecuteReader();
            while (read3.Read())
            {
                //Login_label.Text = read3["Topic"].ToString();
                Login_label.Text = read3["Poster"].ToString();
                TextBox.Text = read3["Text"].ToString();
                Date_label.Text = read3["Posted_Time"].ToString();

                IDDE = read3["Thread_ID"].ToString();

            }
            con.Close();

            con.Open();
            MySqlCommand cmd6 = new MySqlCommand("SELECT * FROM comment WHERE Thread_ID = '"+IDDE+"'  ", con);
            MySqlDataReader read6 = cmd6.ExecuteReader();
            while (read6.Read())
            {
                Poster = read6["Poster"].ToString();
                TextPost = read6["Text"].ToString();

                query = Poster + ": " + TextPost;

                listBox3.Items.Add(query);
            }
            con.Close();
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Topic_label.Visible = false;
            back_button.Visible = false;
            button3.Visible = true;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Comment_Add ssC = new Comment_Add();
                ssC.ShowDialog();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();

            con.Open();
            MySqlCommand cmd6 = new MySqlCommand("SELECT * FROM comment WHERE Thread_ID = '" + IDDE + "'  ", con);
            MySqlDataReader read6 = cmd6.ExecuteReader();
            while (read6.Read())
            {
                Poster = read6["Poster"].ToString();
                TextPost = read6["Text"].ToString();

                query = Poster + ": " + TextPost;

                listBox3.Items.Add(query);
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Topic_Create ssT = new Topic_Create();
            ssT.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Category_Create ssCat = new Category_Create();
            ssCat.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();


            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Category FROM category", con);
            MySqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                listBox1.Items.Add(read.GetValue(0).ToString());
            }
            con.Close();
        }
    }
}
