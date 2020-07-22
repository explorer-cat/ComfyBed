using comfybed.models;
using comfybed.views;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace comfybed.view.Shop
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewFrm : ContentPage
    {

        List<Review_Info> dsReview_Info = new List<Review_Info>();

        public ReviewFrm(Review_Info info)
        {

            //mysql 을 연결해서 seletct 해준후 result값만 받아오는 함수를 만들어서 뿌릴수있다면?
            //json 형식으로 값을 받아와야 하는가?

            JArray j = App.DM.Open("select * from Shop_Info left join Shop_review on Shop_Info.id=Shop_review.ssid where Shop_review.ssid="+info.ssid+" ORDER BY Shop_review.id DESC; ");
            dsReview_Info = JsonConvert.DeserializeObject<List<Review_Info>>(j.ToString());

            InitializeComponent();

            lvData1.ItemsSource = dsReview_Info;

            avgrade.Text = String.Format("{0:0.00} 점", getGradeAvg());

            if (getGradeAvg() > 0 && getGradeAvg() <= 1)
            {
                starpoint.Text = String.Format("★☆☆☆☆");
            }
              else if(getGradeAvg() > 1 && getGradeAvg() < 3 )
            {
                starpoint.Text = String.Format("★★☆☆☆");
            }
            else if (getGradeAvg() >= 3 && getGradeAvg() < 4 )
            {
                starpoint.Text = String.Format("★★★☆☆");
            }
            else if (getGradeAvg() >= 4 && getGradeAvg() < 5 )
            {
                starpoint.Text = String.Format("★★★★☆");
            }
            else if (getGradeAvg() >= 5)
            {
                starpoint.Text = String.Format("★★★★★");
            }
        }
        
         int click_check1 = -1 , click_check2 = -1 , click_check3 = -1 , click_check4 = -1 , click_check5 = -1;   // 번갈아가면서 나옴

        private void star1_Clicked(object sender, EventArgs e)
        {
            click_check1 *= -1;   // 상태 변수를 바꿈
            if (click_check1 == 1) // 상태 변수 값에 따라 인사함
                star1.Text = "★";   else star1.Text = "☆";
            graded.Text = "1점";
        }


        private void Review_Clicked(object sender, EventArgs e)
        {
            Review_Info info = new Review_Info();
            string url = $"http://211.105.113.166:50002/api/OpenBED/INSERT INTO Shop_review(ssid, User_Name,date,review,grade) VALUES ('{info.ssid}', '최성우',  '2020-01-02', '{comment.Text}','{graded.Text}');";//테스트 사이트
            string responseText = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Timeout = 30 * 1000; // 30초
            request.Headers.Add("Authorization", "BASIC SGVsbG8="); // 헤더 추가 방법 

            using (HttpWebResponse resp = (HttpWebResponse)request.GetResponse())
            {
                HttpStatusCode status = resp.StatusCode;
                Console.WriteLine(status);  // 정상이면 "OK"

                Stream respStream = resp.GetResponseStream();
                using (StreamReader sr = new StreamReader(respStream))
                {
                    responseText = sr.ReadToEnd();
                }
            }
            DisplayAlert("완료", "리뷰가 등록되었어요", "확인");

            /*리뷰가 등록되는순간 List를 다시 불러와 작성한글과 평균 평점 바로 보여줌*/
            JArray j = App.DM.Open("select * from Shop_Info left join Shop_review on Shop_Info.id=Shop_review.ssid where Shop_review.ssid=" + info.ssid+ " ORDER BY Shop_review.id DESC; ");
            dsReview_Info = JsonConvert.DeserializeObject<List<Review_Info>>(j.ToString());
            lvData1.ItemsSource = dsReview_Info;

            avgrade.Text = String.Format("{0:0.00} 점", getGradeAvg());

        }

        private void star2_Clicked(object sender, EventArgs e)
        {
            click_check2 *= -1;   
            if (click_check2 == 1) 
                star2.Text = "★"; else star2.Text = "☆";
            graded.Text = "2점";
        }
        private void star3_Clicked(object sender, EventArgs e)
        {
            click_check3 *= -1;   
            if (click_check3 == 1) 
                star3.Text = "★";  else star3.Text = "☆";
            graded.Text = "3점";
        }
        private void star4_Clicked(object sender, EventArgs e)
        {
            click_check4 *= -1;  
            if (click_check4 == 1) 
                star4.Text = "★";  else star4.Text = "☆";
            graded.Text = "4점";
        }
        private void star5_Clicked(object sender, EventArgs e)
        {
            click_check5 *= -1;  
            if (click_check5 == 1) 
                star5.Text = "★"; else star5.Text = "☆";
            graded.Text = "5점";
        }

        /*
        * 리뷰 페이지 관련 method
        * 1. 현재 상점에 등록되어있는 리뷰수를 가져오는 메서드 getReviewCount
        */
        public int getReviewCount()
        {
            return dsReview_Info.Count();
        }

        public double getGradeAvg()
        {
            double gradesum = dsReview_Info.Sum(item => item.grade);
            double avg = gradesum / dsReview_Info.Count();
            return avg;
        }
    }
}