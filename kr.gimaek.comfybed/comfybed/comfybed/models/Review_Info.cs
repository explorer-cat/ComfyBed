using comfybed.views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading;
using comfybed.common;
using System.Security.Permissions;
using comfybed.view.Shop;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.CRUD;
using Xamarin.Forms;

namespace comfybed.models
{

    public class Review_Info
    {
        public int id { get; set; }
        public int ssid { get; set; }
        public string review { get; set; }
        public string comment { get; set; }
        public string User_Name { get; set; }
        public DateTime date { get; set; }
        public double grade { get; set; }


    }
}
    
