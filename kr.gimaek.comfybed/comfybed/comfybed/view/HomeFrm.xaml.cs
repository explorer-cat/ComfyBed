using comfybed;
using comfybed.common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace frontdoor.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeFrm : ContentPage
    {
        List<Shop_Info> dsShop_Info = new List<Shop_Info>();

        public HomeFrm()
        {
            InitializeComponent();
            JArray j = App.DM.Open("select * from Shop_Info ");
            dsShop_Info = JsonConvert.DeserializeObject<List<Shop_Info>>(j.ToString());
           lvData.ItemsSource = dsShop_Info;


        }

    }
}