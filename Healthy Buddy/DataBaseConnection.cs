using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Healthy_Buddy
{
    class DataBaseConnection
    {
        public MySqlConnection DBConnect;
        public MySqlCommand command;
        public MySqlDataReader reader;
       
       

        public void Connection()
        {
            String ConnectString = "datasource = Localhost; port=3306; username=root; password=; database = healthybuddy";
            DBConnect = new MySqlConnection(ConnectString);
            command = DBConnect.CreateCommand();

        }

    }
}
