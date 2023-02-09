using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrediDomFinanciera.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InitPage : ContentPage
    {
        public InitPage()
        {

            if(!string.IsNullOrEmpty(Argument._MyPhoneNumber))
            {
                Navigation.PushAsync(new MainPage());
            }

            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(ldlentry.Text))
            {
                return;
            }

            Argument._MyPhoneNumber = ldlentry.Text;
            Navigation.PushAsync(new MainPage());
        }
    }
}