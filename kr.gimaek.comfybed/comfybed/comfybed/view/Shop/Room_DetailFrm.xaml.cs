using comfybed.models;
using comfybed.views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace comfybed.view.Shop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Room_DetailFrm : ContentPage
    {
        List<Room_Info> dsRoom_Info = new List<Room_Info>();


        HomeFrm h = new HomeFrm();
        Shop_DetailFrm d = new Shop_DetailFrm();
        public Room_DetailFrm()
        {
            InitializeComponent();
            //쿼리문 : 선택된 호텔방의 id 중 선택된 room id의 데이터만 불러온다.
            //-> 1번 모텔 1번방을 선택한다면 1번방에 대한 대한 데이터만 Room_Detail 가는거
            Debug.WriteLine(h.getquery() +"  AAA  "+ d.getquery());
            JArray j = App.DM.Open("select * from shop_room where shop_id = " + h.getquery()+" and room_id = "+d.getquery()+";");
            dsRoom_Info = JsonConvert.DeserializeObject<List<Room_Info>>(j.ToString());
        //    RoomData.ItemsSource = dsRoom_Info;
        }
    }
}