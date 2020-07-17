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
        List<Review_Info> dsReview_Info = new List<Review_Info>();

        ReviewFrm r = new ReviewFrm();
        HomeFrm h = new HomeFrm();

        public Shop_DetailFrm()
        {
            InitializeComponent();
            JArray j = App.DM.Open("select * from Shop_Info left join shop_room on Shop_Info.ssid=shop_room.shop_id where shop_room.shop_id=" + h.getquery() + "; ");
            dsRoom_Info = JsonConvert.DeserializeObject<List<Room_Info>>(j.ToString());

            lvData1.ItemsSource = dsRoom_Info;

            show_review.Text = "리뷰 "+ r.getReviewCount() + "개";
            avgrade.Text = String.Format("평점 : {0:0.00} 점", r.getGradeAvg());
            
            RefreshData();
        }

        public void RefreshData()
        {
            JArray j = App.DM.Open("select * from Shop_Info left join shop_room on Shop_Info.ssid=shop_room.shop_id where shop_room.shop_id=" + h.getquery() + "; ");
            dsRoom_Info = JsonConvert.DeserializeObject<List<Room_Info>>(j.ToString());
            lvData1.ItemsSource = dsRoom_Info;

            Debug.WriteLine("뭔가가 업데이트 된거같아요");
                lvData1.RefreshCommand = new Command(() =>
                {
                    RefreshData();
                    lvData1.IsRefreshing = false;
                });
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
            var ReviewData = new Review_Info();
            var nextPage = new ReviewFrm();

            nextPage.BindingContext = ShopData;
            nextPage.BindingContext = ReviewData;
            Navigation.PushAsync(nextPage);
        }


        private void ShopEvent_Clicked(object sender, EventArgs e)
        {
            var nextPage = new Shop_Event();
            Navigation.PushAsync(nextPage);
        }

        private void lvData1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            var room_info = e.SelectedItem as Room_Info;

           setquery(room_info.ssid);

            var nextPage = new Room_DetailFrm();
            nextPage.BindingContext = e.SelectedItem as Room_Info;
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