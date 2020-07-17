using System;
using System.Collections.Generic;
using System.Text;

namespace comfybed.models
{
    class Room_Info
    {
        public string room_img { get; set; }
        public string room_name { get; set; }

        public string room_info { get; set; }

        public string rent_price { get; set; }
        public string sleep_price { get; set; }
       
        public int room_id { get; set; }

        public int id { get; set; }

        public int ssid { get; set; }
        public int rent_limit { get; set; }
        public int rent_time { get; set; }
        public int sleep_checkin { get; set; }
        public int sleep_checkout { get; set; }
    }
}
