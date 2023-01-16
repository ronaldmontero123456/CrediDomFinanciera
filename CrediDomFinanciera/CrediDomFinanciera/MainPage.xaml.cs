using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace CrediDomFinanciera
{
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {


        public MainPage()
        {
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom)
             .SetBarItemColor(Color.FromHex("#F0A845"))
             .SetBarSelectedItemColor(Color.Red);

            InitializeComponent();
        }

    }
}
