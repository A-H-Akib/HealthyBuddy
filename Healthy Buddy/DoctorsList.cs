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
    public partial class DoctorsList : Form
    {
        public DoctorsList()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            DataBaseConnection db = new DataBaseConnection();
            db.Connection();

            db.DBConnect.Open();
            MySqlDataAdapter sqldata = new MySqlDataAdapter("Select * from doctors", db.DBConnect);
            DataTable dtbl = new DataTable();
            sqldata.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            db.DBConnect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatientPage p = new PatientPage();
            this.Hide();
            p.Show();
        }
    }
}
