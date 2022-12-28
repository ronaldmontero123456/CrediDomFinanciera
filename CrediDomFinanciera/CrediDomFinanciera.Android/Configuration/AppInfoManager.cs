using Android.Telephony;
using CrediDomFinanciera.Abstraction;
using CrediDomFinanciera.Droid.Configuration;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppInfoManager))]
namespace CrediDomFinanciera.Droid.Configuration
{
    public class AppInfoManager : IDeviceInfo
    {
        public string GetMyPhoneNumber()
        {
            var tMgr = (TelephonyManager)Forms.Context
                .ApplicationContext.GetSystemService
                (Android.Content.Context.TelephonyService);

            return tMgr.Line1Number;
        }
    }

}