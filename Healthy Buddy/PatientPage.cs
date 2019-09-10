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
    public partial class PatientPage : Form
    {
        public PatientPage()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DataBaseConnection db = new DataBaseConnection();
                db.Connection();

                db.command.CommandText = "Insert into patient (Name,Medicine,Time) values('" + Starting_Page.u + "','" + textBox1.Text + "','" + dateTimePicker1.Text + "')";
                db.DBConnect.Open();
                db.reader = db.command.ExecuteReader();
                MessageBox.Show("Reminder Created");
                db.DBConnect.Close();

            }
            else
            {
                MessageBox.Show("Fill the box first");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DoctorsList d = new DoctorsList();
            this.Hide();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HomePage h = new HomePage();
            this.Hide();
            h.Show();
        }
    }
}
