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

namespace Healthy_Buddy
{
    public partial class SignUpPage : Form
    {
        public SignUpPage()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
                {
                    if (textBox7.Text == textBox8.Text)
                    {
                        DataBaseConnection db = new DataBaseConnection();
                        db.Connection();

                        db.command.CommandText = "Insert into user (Name,Email,Age,Gender,Height,Weight,Password) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                        db.DBConnect.Open();
                        db.reader = db.command.ExecuteReader();
                        MessageBox.Show("Account Created");
                        db.DBConnect.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password error input");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill all boxes");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Starting_Page s = new Starting_Page();
            this.Hide();
            s.Show();
        }
    }
}
