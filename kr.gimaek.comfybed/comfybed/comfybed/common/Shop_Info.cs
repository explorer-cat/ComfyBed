using System;
using System.Collections.Generic;
using System.Text;

namespace comfybed.common
{
    class Shop_Info
    {
        public string Shop_Name { get; set; } //모텔이름
        public string Shop_Address { get; set; } //모텔주소
        public string Shop_CallNum { get; set; } //전화번호
        public double xy { get; set; } //모텔위치
        public string ceo { get; set; } //사업자이름(CEO)
        public string BsNumber { get; set; } //사업자번호
        public string Rentroom_minprice { get; set; } //대실 최저가
        public string Sleeproom_minprice { get; set; } //숙박 최저가
        public string place { get; set; } //
        public double grade { get; set; } //평점
        public int ReView { get;   set;   } //리뷰
        public bool Event_Check { get; set;  } //최대 할인 여부
        public string Sale_Event {  get; set; } //최대할인가격 얼마? EX) 최대 5000원 할인
        public string Image_Url{ get;set;} // 이미지 url
        public string Grade_Star //별
        {
            get
            {
                return "https://slimeplanet.cafe24.com/comfybed/image/star.png";
            }
        }
    }
}
