using System;
using System.Collections.Generic;
using System.Text;

namespace comfybed.models
{
    class Reserve_Info
    {
       public int id   { get; set; }
        public int shop_id { get; set; }
        public int room_id { get; set; }
        public string reserve_user { get; set; }
        public string reserve_day { 
            get
            {
                DateTime dt = new DateTime();
                return DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        public string checkin_day { get; set; }
        public string checkout_day { get; set; }
        public bool payment { get; set; }

    }
}
