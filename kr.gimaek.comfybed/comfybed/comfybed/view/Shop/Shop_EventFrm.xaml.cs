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
    public partial class Shop_Event : ContentPage
    {
        List<ShopEvent_Info> dsShopEvent_Info= new List<ShopEvent_Info>();
        HomeFrm h = new HomeFrm();
        public Shop_Event()
        {
            InitializeComponent();

            JArray j = App.DM.Open("select * from Shop_Info left join Shop_Event on Shop_Info.id=Shop_Event.ssid where Shop_Event.ssid="+h.getquery()+";");
            dsShopEvent_Info = JsonConvert.DeserializeObject<List<ShopEvent_Info>>(j.ToString());
            eventData.ItemsSource = dsShopEvent_Info;
        }
    }
}