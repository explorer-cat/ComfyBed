using comfybed.models;
using comfybed.views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace comfybed.view.Shop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shop_test : ContentPage
    {

        List<Shop_Test> dsShop_Test = new List<Shop_Test>();


        public Shop_test()
        {
            var tmp = new HomeFrm();
            InitializeComponent();
            JArray j = App.DM.Open("select * from Shop_Info left join shop_room on Shop_Info.ssid=shop_room.shop_id where shop_room.shop_id=1;");
            dsShop_Test = JsonConvert.DeserializeObject<List<Shop_Test>>(j.ToString());
           // System.Diagnostics.Debug.WriteLine(HomeFrm.query + "   샵테스트");
            lvData1.ItemsSource = dsShop_Test;
        }
    }
}