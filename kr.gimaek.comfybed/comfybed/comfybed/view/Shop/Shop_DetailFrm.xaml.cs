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
        List<Reserve_Info> reserve_room = new List<Reserve_Info>();
        List<Room_Info> dsRoom_Info = new List<Room_Info>();
        List<Review_Info> dsReview_Info = new List<Review_Info>();
        public Review_Info reviewinfo;
        public Shop_Info shopinfo;
        public ShopEvent_Info eventinfo;



        public Shop_DetailFrm(Shop_Info shop, Review_Info info)
        {

            shopinfo = shop;
            reviewinfo = info;


            InitializeComponent();
            JArray j = App.DM.Open("select * from Shop_Info left join shop_room on Shop_Info.ssid=shop_room.shop_id where shop_room.shop_id=" + shop.id + "; ");
            dsRoom_Info = JsonConvert.DeserializeObject<List<Room_Info>>(j.ToString());

            lvData1.ItemsSource = dsRoom_Info;

            show_review.Text = "리뷰 "+ getReviewCount() + "개";
            avgrade.Text = String.Format("평점 : {0:0.00} 점", getGradeAvg());
            
            RefreshData(shop);
        }


        public int getReviewCount()
        {
            JArray j = App.DM.Open("select * from Shop_Info left join Shop_review on Shop_Info.id=Shop_review.ssid where Shop_review.ssid=" + shopinfo.ssid + " ORDER BY Shop_review.id DESC; ");
            dsReview_Info = JsonConvert.DeserializeObject<List<Review_Info>>(j.ToString());

            return dsReview_Info.Count();
        }

        public double getGradeAvg()
        {
            double gradesum = dsReview_Info.Sum(item => item.grade);
            double avg = gradesum / dsReview_Info.Count();
            return avg;

        }

        public void RefreshData(Shop_Info shop)
        {
            JArray j = App.DM.Open("select * from Shop_Info left join shop_room on Shop_Info.ssid=shop_room.shop_id where shop_room.shop_id=" + shop.id + "; ");
            dsRoom_Info = JsonConvert.DeserializeObject<List<Room_Info>>(j.ToString());
            lvData1.ItemsSource = dsRoom_Info;
           

            Debug.WriteLine("뭔가가 업데이트 된거같아요");
                lvData1.RefreshCommand = new Command(() =>
                {
                    RefreshData(shop);
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
            var startTime = startDatePicker.Date.ToString("yyyy-MM-dd");
            var endTime = endDatePicker.Date.ToString("yyyy-MM-dd");


            TimeSpan timeSpan = endDatePicker.Date - startDatePicker.Date + TimeSpan.FromDays(1);
            Debug.WriteLine(startTime + " 시작날짜");
            Debug.WriteLine(endTime + "종료날짜");

            JArray j = App.DM.Open("select * from reserve_user left join shop_room on reserve_user.shop_id = shop_room.room_id where shop_room.shop_id = 1 and checkin_day between "+startTime+" and "+endTime+"; ");
            dsRoom_Info = JsonConvert.DeserializeObject<List<Room_Info>>(j.ToString());
            lvData1.ItemsSource = dsRoom_Info;

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
            var nextPage = new ReviewFrm(shopinfo);
            // nextPage.BindingContext = e.SelectedItem as Room_Info;
            Navigation.PushAsync(nextPage);

        }


        private void ShopEvent_Clicked(object sender, EventArgs e)
        {
            var nextPage = new Shop_Event(shopinfo);
            // nextPage.BindingContext = e.SelectedItem as Room_Info;
            Navigation.PushAsync(nextPage);
        }

        private void lvData1_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            var nextPage = new Room_DetailFrm(e.SelectedItem as Room_Info);
           // nextPage.BindingContext = e.SelectedItem as Room_Info;
            Navigation.PushAsync(nextPage);
        }
    }
}