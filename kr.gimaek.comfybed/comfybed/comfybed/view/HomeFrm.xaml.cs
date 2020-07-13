using comfybed;
using comfybed.common;
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
        List<Shop_Info> dsShop_Info = new List<Shop_Info>();
        public HomeFrm()
        {
            InitializeComponent();
            JArray j = App.DM.Open("select * from Shop_Info ");
            dsShop_Info = JsonConvert.DeserializeObject<List<Shop_Info>>(j.ToString());
            lvData.ItemsSource = dsShop_Info;

 


            lvData.RefreshCommand = new Command(() =>
            {
                RefreshData();
                lvData.IsRefreshing = false;
            });
        }


        public void RefreshData()
        {
            lvData.ItemsSource = null;
            lvData.ItemsSource = dsShop_Info;
          //  ObservableCollection<Shop_Info> dsShop_Infos = new ObservableCollection<Shop_Info>();
         //  lvData.ItemsSource = dsShop_Infos;
        }
    }
}