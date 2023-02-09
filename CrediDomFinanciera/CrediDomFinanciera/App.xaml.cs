using CrediDomFinanciera.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CrediDomFinanciera
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new InitPage());
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
