using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Healthy_Buddy
{
    public partial class Starting_Page : Form
    {
        public static string u;
        public Starting_Page()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            textBox2.UseSystemPasswordChar = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            DataBaseConnection db = new DataBaseConnection();
            db.Connection();

            db.command.CommandText = "Select * from user where Name = '"+ textBox1.Text+"' AND Password = '"+textBox2.Text+"' ";
            db.DBConnect.Open();
            db.reader = db.command.ExecuteReader();
           
            if (db.reader.Read())
            {
                u = textBox1.Text;
                db.DBConnect.Close();
                db.reader.Close();
                HomePage h = new HomePage();
                this.Hide();
                h.Show();
            }
            else
            {
                MessageBox.Show("Error Input");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SignUpPage s = new SignUpPage();
            this.Hide();
            s.Show();
        }
    }
}
