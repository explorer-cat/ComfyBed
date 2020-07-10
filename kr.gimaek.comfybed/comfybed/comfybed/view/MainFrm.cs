using comfybed.view.user;
using frontdoor.views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace comfybed.view
{


    public partial class MainFrm: Xamarin.Forms.TabbedPage
    {

        public MainFrm()
        {



            //On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            //     NavigationPage.SetHasNavigationBar(this, false);  // Hide nav bar
            //     On<Android>().SetToolbarPlacement(ToolbarPlacement.Default).SetBarItemColor(Color.Black) .SetBarSelectedItemColor(Color.White);


            this.BarBackgroundColor = Color.White;
          //  this.BarTextColor = Color.Gray;


            var frHome = new NavigationPage(new HomeFrm(){ Title = "홈" });
            var MyPlace = new NavigationPage(new MyInfoFrm() { Title = "내주변"}); 
            var Place = new NavigationPage(new MyInfoFrm() { Title = "지도"});
            var wishList = new NavigationPage(new MyInfoFrm()  {  Title = "찜"});
            var frMyInfo = new NavigationPage(new MyInfoFrm() { Title = "내정보" });


            frHome.Title = "홈";
            MyPlace.Title = "내주변";
            Place.Title = "지도";
            wishList.Title = "찜";
            frMyInfo.Title = "내정보";


            Children.Add(frHome);
            Children.Add(MyPlace);
            Children.Add(Place);
            Children.Add(wishList);
            Children.Add(frMyInfo);

        }
    }
}
