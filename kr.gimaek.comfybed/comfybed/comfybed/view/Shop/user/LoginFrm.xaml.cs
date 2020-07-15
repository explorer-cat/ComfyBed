using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace comfybed.view.user
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginFrm : ContentPage
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainFrm();
        }

        private void BtnNewRegister_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new UserJoinFrm();
        }
    }
}