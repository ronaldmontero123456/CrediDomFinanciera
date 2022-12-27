using Android.Telephony;
using CrediDomFinanciera.Abstraction;
using System;
using Xamarin.Forms;

namespace CrediDomFinanciera.Droid.Configuration
{
    [assembly: Dependency(typeof(AppInfoManager))]
    internal class AppInfoManager : IDeviceInfo
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