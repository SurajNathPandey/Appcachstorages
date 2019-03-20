using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appcachstorage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loginpage : ContentPage
    {
        public Loginpage()
        {
#if __ANDROID__
		showDialog loading;
		WjivAlertDialog alert;
        //Production Flurry key Android
        //public static String flurryKey = "9GGMKJNK27T4BYY8ZHX7";
        public static String flurryKey = "7WKRBTQW3K6SVHZHNKKB";
#endif

            InitializeComponent();

            btnStore.Clicked += BtnStore_Clicked;
            if (Application.Current.Properties.ContainsKey("Name"))
            {
                userNameEntry.Text = Application.Current.Properties["Name"].ToString();

                //btnStore.Clicked += BtnStore_Clicked;
                //Checkbox.Checked += Checked_Event
            }
        }
        private void Checked_Event(object sender, ToggledEventArgs e)
        {
            Application.Current.Properties["IsChecked"] = Checkbox.Checked;
        }
        private void BtnStore_Clicked(object sender, EventArgs e)
        {
            callLogin(true);
           // if (Application.Current.Properties.ContainsKey("Name"))
           // {

           //     //txtId.Text = Application.Current.Properties["Name"].ToString();
           //     userNameEntry.Text = Application.Current.Properties["Name"].ToString();
           // }
           // // Store all  Values
           //// Application.Current.Properties["ID"] = txtId.Text;
           // Application.Current.Properties["Name"] = userNameEntry.Text;
           // Application.Current.Properties["IsChecked"] = Checkbox.Checked;
           // // txtId.Text = string.Empty;
           // // txtName.Text = string.Empty;
           // Navigation.PushAsync(new MainPage());
        }

        
		private void callLogin( bool isChecked)
        {

			if (string.IsNullOrEmpty (userNameEntry.Text) && string.IsNullOrEmpty (passwordEntry.Text)) {
				DisplayAlert ("", "The Username and Password fields are required.", "OK");
				return;
			} else if (string.IsNullOrEmpty (userNameEntry.Text)) {
				DisplayAlert ("", "The Username field is required.", "OK");
				return;
			} else if (string.IsNullOrEmpty (passwordEntry.Text)) {
				DisplayAlert ("", "The Password field is required.", "OK");
				return;
			}
            if (Application.Current.Properties.ContainsKey("Name"))
                 {

                //     //txtId.Text = Application.Current.Properties["Name"].ToString();
                    userNameEntry.Text = Application.Current.Properties["Name"].ToString();
                 }
                Application.Current.Properties["Name"] = userNameEntry.Text;
                Application.Current.Properties["IsChecked"] = Checkbox.Checked;

            callLoginService(userNameEntry.Text, passwordEntry.Text,isChecked);

		}



		private async void callLoginService(string userNameEntry, string
            passwordEntry, bool isChecked)
        {
			var crypt = new CryptLib ();
			string userAuth = crypt.EncryptString (userNameEntry + ":" + passwordEntry, "1QA2WS3ED4RF5TG6");
            //userNameEntry.Unfocus ();
            //passwordEntry.Unfocus ();
#if __IOS__
			UtilityClass.userAuth = userAuth;
			App.showBusyView();
			var appVersion = NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"].ToString();
#else
            //  loading.showLaoding();
            var appVersion = "2.0";// new Util(Forms.Context).versionCode;
#endif

            var urlString = WebService.GetUserService;
			urlString = urlString.Replace ("%a",appVersion);
			string responsString =await WebService.PostLoginRequestWithUsernamePasswordAsync (urlString, userAuth);
            var val = responsString;
			//HideBusyView ();
			//bool isValideLogin = false;
			//if (!responsString.Contains ("WebResponseErrorMessage")) {
			//	Dictionary<string, string> responsDict = JsonConvert.DeserializeObject<Dictionary<string, string>> (responsString);

			//	if (responsDict.ContainsKey ("UserID")) {
			//		if (string.Equals (responsDict ["IslatestVersion"], "False", StringComparison.CurrentCultureIgnoreCase)) {
			//			await DisplayAlert ("", responsDict ["ErrorMessage"], "OK");
			//		} else if (responsDict ["roleId"].ToString () == "3") {
			//			if (responsDict ["AgreementStatus"] == null || responsDict ["AgreementStatus"].ToString () != "Accept")
			//				await DisplayAlert ("", "Organization setup needs to be completed to access the mobile application", "OK");
			//			else
			//				isValideLogin = true;

			//			#if __IOS__

			//			Flurry.Analytics.Portable.AnalyticsApi.LogTimedEvent("App Sessions", new Dictionary<string, string> {
			//				{  "Total Sessions", "Login/Logout" }
			//			} );

			//			#endif

			//		} else {
			//			isValideLogin = true;

			//			#if __IOS__

			//			Flurry.Analytics.Portable.AnalyticsApi.LogTimedEvent("App Sessions", new Dictionary<string, string> {
			//				{  "Total Sessions", "Login/Logout" }
			//			} );

			//			#endif
			//		}

			//	} else {
			//		await DisplayAlert ("", responsDict ["Message"].ToString (), "OK");
			//	}
			//} else {
			//	Dictionary<string, string> responsDict = JsonConvert.DeserializeObject<Dictionary<string, string>> (responsString);

			//	await DisplayAlert ("", responsDict ["WebResponseErrorMessage"].ToString (), "OK");
			//}

          //  if (isValideLogin)
          //  {

          //  }
            //loadDashBoardViewController (userNameEntry.Text, responsString, isChecked, userAuth);
          //  else
          //  {
         //       passwordEntry = "";
         //   }
		}

        void HideBusyView()
        {
#if __IOS__
			App.hideBusyView();
#else
           // loading.dismissLoading();
#endif
        }
    }
}