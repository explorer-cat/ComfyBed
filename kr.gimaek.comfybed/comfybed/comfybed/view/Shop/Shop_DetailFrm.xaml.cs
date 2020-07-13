using comfybed.common;
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
    public partial class Shop_DetailFrm : ContentPage
    {

        List<Shop_Info> dsShop_Info = new List<Shop_Info>();

        public Shop_DetailFrm()
        {
            InitializeComponent();

            JArray j = App.DM.Open("select * from Shop_Info ");
            dsShop_Info = JsonConvert.DeserializeObject<List<Shop_Info>>(j.ToString());
            var stack = new StackLayout();
            BindableLayout.SetItemsSource(stack, dsShop_Info);


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
            if(timeSpan.Days == 1)
            {
                resultLabel.Text = String.Format("당일치기 여행이시군요!");
            } else
            {
                resultLabel.Text = String.Format("{0}일 여행 예정 맞으신가요?",  timeSpan.Days);
            }
        }

    }
}