using System;
using System.Collections.Generic;
using System.Text;

namespace comfybed.models
{
    class Room_Info
    {
        public int shop_id { get; set; } //이미지에 이벤트 스티커 유무 0false 1true
        public string room_img {   get; set;  } //최대할인가격 얼마? EX) 최대 5000원 할인
        public bool room_check { get; set; }
    }
}
