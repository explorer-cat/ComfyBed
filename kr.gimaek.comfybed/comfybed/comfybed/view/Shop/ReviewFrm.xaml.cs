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
    public partial class ReviewFrm : ContentPage
    {

        List<Review_Info> dsReview_Info = new List<Review_Info>();
        HomeFrm h = new HomeFrm();


        public ReviewFrm()
        {

            //mysql 을 연결해서 seletct 해준후 result값만 받아오는 함수를 만들어서 뿌릴수있다면?
            //json 형식으로 값을 받아와야 하는가?

            InitializeComponent();
            JArray j = App.DM.Open("select * from Shop_Info left join Shop_review on Shop_Info.id=Shop_review.ssid where Shop_review.ssid=" + h.getquery() + ";");
            dsReview_Info = JsonConvert.DeserializeObject<List<Review_Info>>(j.ToString());
            lvData1.ItemsSource = dsReview_Info;
        }
    }

}