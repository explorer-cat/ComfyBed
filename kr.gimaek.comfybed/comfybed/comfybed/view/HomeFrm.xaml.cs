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
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace comfybed.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeFrm : ContentPage
    {
        List<Shop_Info> dsShop_Info = new List<Shop_Info>();
        List<Shop_Info> newdsShop_Info = new List<Shop_Info>();


        public HomeFrm()
        {
            InitializeComponent( );
            /*홈화면을 불러옴*/

            JArray j = App.DM.Open("select * from Shop_Info; ");
            dsShop_Info = JsonConvert.DeserializeObject<List<Shop_Info>>(j.ToString());
            lvData.ItemsSource = dsShop_Info;
            /*새로고침*/
                RefreshData();

    }



    public void RefreshData()
    {
            JArray j = App.DM.Open("select * from Shop_Info; ");
            dsShop_Info = JsonConvert.DeserializeObject<List<Shop_Info>>(j.ToString());
                Debug.WriteLine("뭔가가 업데이트 된거같아요");
                lvData.RefreshCommand = new Command(() =>
                {
                    RefreshData();
                    lvData.IsRefreshing = false;
                });
      }


    public void lvData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var shop_info1 = e.SelectedItem as Shop_Info;

            //query 변수에 선택된 ssid 번호를 저장한다.

            setquery(shop_info1.ssid);

            var nextPage = new Shop_DetailFrm();
            nextPage.BindingContext = e.SelectedItem as Shop_Info;
            Navigation.PushAsync(nextPage);
            System.Diagnostics.Debug.WriteLine(getquery() + "  : 번 셀렉트가 선택됨");
        }
        static int query = 0;

        public int getquery()
        {
            return query;
        }

        public void setquery(int q)
        {
            query = q;
        }


    }
}