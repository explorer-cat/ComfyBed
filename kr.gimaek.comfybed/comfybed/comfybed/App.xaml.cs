using comfybed.common;
using comfybed.view;
using comfybed.view.Shop;
using comfybed.view.user;
using comfybed.views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace comfybed
{
    public partial class App : Application
    {
        public static User_Info UI;
        public static DataMod DM;
        public App()
        {
            InitializeComponent();
            UI = new User_Info();
            DM = new DataMod();
            MainPage = new MainFrm();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
