using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace comfybed.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeFrm : ContentPage
    {
        public HomeFrm()
        {
            InitializeComponent();
            Debug.WriteLine(App.DM.Open("select * from User_Info ").ToString());

        }
    }
}