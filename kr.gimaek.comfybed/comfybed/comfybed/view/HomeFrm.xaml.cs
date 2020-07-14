using comfybed;
using comfybed.common;
using comfybed.models;
using comfybed.view;
using comfybed.view.Shop;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace comfybed.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeFrm : ContentPage
    {
        ObservableCollection<Shop_Info> dsShop_Infos = new ObservableCollection<Shop_Info>();
        List<Shop_Info> dsShop_Info = new List<Shop_Info>();
        public HomeFrm()
        {
            InitializeComponent();
            RefreshData();

            lvData.RefreshCommand = new Command(() =>
            {
                RefreshData();
                lvData.IsRefreshing = false;
            });
        }


        public void RefreshData()
        {
            JArray j = App.DM.Open("select * from Shop_Info left join shop_room on Shop_Info.id = shop_room.shop_id;");
            dsShop_Info = JsonConvert.DeserializeObject<List<Shop_Info>>(j.ToString());
            lvData.ItemsSource = dsShop_Info;
        }

        private async void lvData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            if (e.SelectedItem == null) return;
            var shop_info = e.SelectedItem as Shop_Info;

            var nextPage = new Shop_DetailFrm();
            nextPage.BindingContext = shop_info;
            await Navigation.PushAsync(nextPage);
        }
    }
}