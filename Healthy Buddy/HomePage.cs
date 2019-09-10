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
    public partial class HomePage : Form
    {
        public static int NotificationCounter=0;
        int counter = 1;
        public HomePage()
        {
            if (NotificationCounter == 0)
            {
                Notification n = new Notification();
                n.notification();
            }
            
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {

            panel1.Visible = true;
            panel1.BringToFront();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.BringToFront();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel1.BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.BringToFront();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            
            DataBaseConnection db = new DataBaseConnection();
            db.Connection();

           
            db.command.CommandText = "Select Tips From tips where SerialNo ='" + counter + "' ";
            db.DBConnect.Open();
            db.reader = db.command.ExecuteReader();
                while (db.reader.Read())
                {
                if (counter > 3)
                {
                    counter = 1;
                    textBox5.Text = db.reader.GetString("Tips");
                }
                else
                {
                    textBox5.Text = db.reader.GetString("Tips");
                    counter++;
                }
                    
                }
            db.DBConnect.Close();
                
            
        }
        private void button11_Click(object sender, EventArgs e)
        {
            
            
            DataBaseConnection db = new DataBaseConnection();
            db.Connection();
            string a="";
            db.command.CommandText= "Select Password From user where Name='" + Starting_Page.u + "' ";
            db.DBConnect.Open();
            db.reader = db.command.ExecuteReader();
            while (db.reader.Read())
            {
                a = db.reader.GetString("Password");
            }
            db.DBConnect.Close();
            if (textBox1.Text == a)
            {
                db.command.CommandText = "Update user SET Password= '" + textBox2.Text + "', Weight= '" + textBox3.Text + "', Age='" + textBox4.Text + "'  where Name= '" + Starting_Page.u + "' ";
                db.DBConnect.Open();
                db.reader = db.command.ExecuteReader();
                MessageBox.Show("Entry success");
                db.DBConnect.Close();
            }
            else
            {
                MessageBox.Show("Password error");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            NotificationCounter = 0;
            Starting_Page s = new Starting_Page();
            this.Hide();
            s.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PatientPage s = new PatientPage();
            this.Hide();
            s.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FitnessPage f = new FitnessPage();
            this.Hide();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegulerPage r = new RegulerPage();
            this.Hide();
            r.Show();
        }
    }
}
