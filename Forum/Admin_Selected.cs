using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forum
{
    public partial class Admin_Selected : Form
    {
        

        public Admin_Selected()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Admin ssAmdin = new Admin();
            ssAmdin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
            Main ssMain = new Main();
            ssMain.Show();
        }

        private void Admin_Selected_Load(object sender, EventArgs e)
        {

        }
    }
}
