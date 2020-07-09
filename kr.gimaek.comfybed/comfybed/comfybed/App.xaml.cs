using comfybed.common;
using comfybed.view.user;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace comfybed
{
    public partial class App : Application
    {
        public static common.User_Info UI;
        public static common.DataMod DM;
        public App()
        {
            InitializeComponent();
            UI = new common.User_Info();
            DM = new common.DataMod();

            MainPage = new LoginFrm();
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
