using comfybed.view.user;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace comfybed.view
{
    class MainFrm: TabbedPage
    {
       public MainFrm()
        {
            Title = "ComfyBed";
            var frHome = new NavigationPage(new HomeFrm() { Title = "Home" });
            var frMyInfo = new NavigationPage(new MyInfoFrm() { Title = "내정보" });

            frHome.Title = "Home";
            frMyInfo.Title = "내정보";

            Children.Add(frHome);
            Children.Add(frMyInfo);
            
        }
    }
}
