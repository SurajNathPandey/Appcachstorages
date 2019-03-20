using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Appcachstorage
{
   public class Util
    {
        public static bool isOffline;
        public static double inches;
        public const string unauthMessage = "Password has been changed, please login again";
        public const string logoutMessage = "You are logged out due to inactivity";
        public readonly string versionCode;
        public static bool showDialogOnLogin;
        public Util(Context context)
        {
            versionCode = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName.ToString();
        }
        public static bool connectivity(Context mContext)
        {
            bool status = false;
            ConnectivityManager connectivityManager = (ConnectivityManager)mContext.GetSystemService(Context.ConnectivityService);
            var activeConnection = connectivityManager.ActiveNetworkInfo;
            var mobileState = connectivityManager.GetNetworkInfo(ConnectivityType.Wifi).GetState();
            if (connectivityManager != null)
            {
                if (((activeConnection != null) && activeConnection.IsConnected) || mobileState == NetworkInfo.State.Connected)
                {

                    status = true;
                }
            }

            return status;
        }

        public static double DiagonalInches(Context mContext)
        {
            var metrics1 = mContext.Resources.DisplayMetrics;
            int widthInPixels1 = metrics1.WidthPixels;
            int heightInPixels1 = metrics1.HeightPixels;
            float widthDpi1 = metrics1.Xdpi;
            float heightDpi1 = metrics1.Ydpi;
            float widthInches1 = widthInPixels1 / widthDpi1;
            float heightInches1 = heightInPixels1 / heightDpi1;

            return (Math.Sqrt((widthInches1 * widthInches1)
                + (heightInches1 * heightInches1)));

        }
    }
}


