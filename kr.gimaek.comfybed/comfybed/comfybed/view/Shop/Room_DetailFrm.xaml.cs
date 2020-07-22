using comfybed.common;
using comfybed.models;
using comfybed.views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core.Records.General;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace comfybed.view.Shop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Room_DetailFrm : ContentPage
    {
        List<Room_Info> dsRoom_Info = new List<Room_Info>();
        List<Reserve_Info> dsResrve_Info = new List<Reserve_Info>();

       public Room_Info roominfo;



        public Room_DetailFrm(Room_Info info)
        {
            if(info == null)
            {
                return;
            }

            roominfo = info;
            
            //쿼리문 : 선택된 호텔방의 id 중 선택된 room id의 데이터만 불러온다.
            //-> 1번 모텔 1번방을 선택한다면 1번방에 대한 대한 데이터만 Room_Detail 가는거
            JArray j = App.DM.Open("select * from shop_room where shop_id = " + info.ssid +" and room_id = "+info.room_id+";");
            dsRoom_Info = JsonConvert.DeserializeObject<List<Room_Info>>(j.ToString());

            this.BindingContext = roominfo;
            InitializeComponent();
        }



        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
         //   Recalculate();
            var startdate = startDatePicker.Date.ToString("yyyy-MM-dd");
            Debug.WriteLine(startdate);
          // Debug.WriteLine(startDatePicker.Date.ToString("yyyy-MM-dd"));
          // JArray j = App.DM.Open("select * from reserve_user WHERE shop_id = 1 and room_id = 1 and checkin_day = '2020-07-21';");
          // dsResrve_Info = JsonConvert.DeserializeObject<List<Reserve_Info>>(j.ToString());
          // Debug.WriteLine(dsResrve_Info);
        }


        private void reserved_Clicked_1(object sender, EventArgs e)
        {

            DataMod mod = new DataMod();
            try
            {
            //DisplayAlert("dd", ""+d.getRoomName()+"d", "dd");
            mod.GetResult("INSERT INTO reserve_user(shop_id,reserve_check,room_id,room_name,user_name,price,checkin_day,checkout_day) VALUES ('" + roominfo.ssid+"', '예약 완료', '"+ roominfo.room_id+ "',  '" + roominfo.room_name+ "','최성우' , '"+ roominfo.rent_price+"원', '" + rentDatePicker.Date.ToString("yyyy-MM-dd")+"','"+rentDatePicker.Date.ToString("yyyy-MM-dd")+"');");
              mod.GetResult("INSERT INTO fuck(fuck) VALUES (1);");
                DisplayAlert("성공", "정상적으로 예약되었습니다.", "확인");
            }
            catch(Exception error)
            {
                Debug.WriteLine(error);
            }
}

        private void reserved_Clicked(object sender, EventArgs e)
        {
            DataMod mod = new DataMod();
       //     Room_DetailFrm(Room_Info);
            Debug.WriteLine(startDatePicker.Date.ToString("yyyy-MM-dd"));
            try
            {
                mod.GetResult("INSERT INTO reserve_user(shop_id,room_id,room_name,checkin_day,checkout_day) VALUES ('"+ roominfo.ssid+"', '" + roominfo.room_id + "', '"+roominfo.room_name+"' , '" + startDatePicker.Date.ToString("yyyy-MM-dd") + "','" + endDatePicker.Date.ToString("yyyy-MM-dd") + "');");
                DisplayAlert("성공", "정상적으로 예약되었습니다.", "확인");
                }
              catch(Exception error)
            {
                Debug.WriteLine(error);
            }
        }





        private void startDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void endDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }

        private void rentDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

        }
    }
}