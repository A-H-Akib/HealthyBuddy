using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulpep.NotificationWindow;

namespace Healthy_Buddy
{
    class Notification
    {
        public void notification()
        {
            DataBaseConnection db = new DataBaseConnection();
            db.Connection();
            string a = "";
            string b = "";
            db.command.CommandText = "Select * From patient where Name='" + Starting_Page.u + "' ";
            db.DBConnect.Open();
            db.reader = db.command.ExecuteReader();
            while (db.reader.Read())
            {
                a = db.reader.GetString("Medicine");
                b= db.reader.GetString("Time");
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.Notification;
                popup.TitleText = "Medicine intake reminder";
                popup.ContentText = a+" "+b;
                popup.Popup();
                HomePage.NotificationCounter = 1;
            }
            db.DBConnect.Close();

            
        }
    }
}
