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
using System.IO;

namespace Healthy_Buddy
{
    public partial class FitnessPage : Form
    {
        public FitnessPage()
        {
            InitializeComponent();
            this.MaximizeBox = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HomePage h = new HomePage();
            this.Hide();
            h.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            DataBaseConnection db = new DataBaseConnection();
            db.Connection();

            db.command.CommandText = "Select Image from image where Catagory='WeightLoss' ";
            db.DBConnect.Open();

            MySqlDataAdapter da = new MySqlDataAdapter(db.command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                
                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Image"]);

                pictureBox1.Image = Image.FromStream(ms);
                db.DBConnect.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataBaseConnection db = new DataBaseConnection();
            db.Connection();

            db.command.CommandText = "Select Image from image where Catagory='WeightGain' ";
            db.DBConnect.Open();

            MySqlDataAdapter da = new MySqlDataAdapter(db.command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {

                MemoryStream ms = new MemoryStream((byte[])ds.Tables[0].Rows[0]["Image"]);

                pictureBox1.Image = Image.FromStream(ms);
                db.DBConnect.Close();
            }
        }
    }
}
