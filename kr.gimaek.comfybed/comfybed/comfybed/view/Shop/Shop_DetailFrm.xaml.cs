using comfybed.common;
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
    public partial class Shop_DetailFrm : ContentPage

    {

        List<Room_Info> dsRoom_Info = new List<Room_Info>();

        public Shop_DetailFrm()
        {
            InitializeComponent();
            HomeFrm h = new HomeFrm();
            JArray j = App.DM.Open("select * from Shop_Info left join shop_room on Shop_Info.ssid=shop_room.shop_id where shop_room.shop_id="+ h.getquery()+"; ");
            dsRoom_Info = JsonConvert.DeserializeObject<List<Room_Info>>(j.ToString());
            System.Diagnostics.Debug.WriteLine(h.getquery() +  "실제 전송되는 번호 하위");
            lvData1.ItemsSource = dsRoom_Info;
        }



            void OnDateSelected(object sender, DateChangedEventArgs args)
            {
                Recalculate();
            }

            void OnSwitchToggled(object sender, ToggledEventArgs args)
            {
                Recalculate();
            }

            void Recalculate()
            {
                TimeSpan timeSpan = endDatePicker.Date - startDatePicker.Date + TimeSpan.FromDays(1);
                if (timeSpan.Days == 1)
                {
                    resultLabel.Text = String.Format("당일치기 여행이시군요!");
                }
                else
                {
                    resultLabel.Text = String.Format("{0}일 여행 예정 맞으신가요?", timeSpan.Days);
                }
            }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            var ShopData = new Shop_Info();

            var nextPage = new ReviewFrm();
            nextPage.BindingContext = ShopData;
            Navigation.PushAsync(nextPage);
        }
    }
}