using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace comfybed.view.user
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyInfoFrm : ContentPage
    {
        public MyInfoFrm()
        {
            InitializeComponent();
          //  App.DM.Open("select * from User_Info ");
        }
    }
}