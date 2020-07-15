using comfybed.views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading;

namespace comfybed.models
{

    class Review_Info
    {



            HomeFrm h = new HomeFrm();

        public int id { get; set; }
        public int shop_id { get; set; }
        public string review { get; set; }
        public string comment { get; set; }
        public double grade { get; set; }
        public string User_Name { get; set; }

        public string date { get; set; }

        public double  grade_avg
        {
            get
            {
                string strConn = "Server=localhost;Database=test;Uid=testuser;Pwd=123;";
                MySqlConnection conn = new MySqlConnection(strConn);
                conn.Open();
                string text = "select avg(grade) from Shop_review where ssid = 1;";
                conn.CreateCommand(text);
            }
            return;
        }
    }
}
