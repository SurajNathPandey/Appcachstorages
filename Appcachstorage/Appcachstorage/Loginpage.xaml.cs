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

            
            InitializeComponent();

            btnStore.Clicked += BtnStore_Clicked;
            if (Application.Current.Properties.ContainsKey("Name"))
            {
                txtName.Text = Application.Current.Properties["Name"].ToString();

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
            if (Application.Current.Properties.ContainsKey("Name"))
            {

                //txtId.Text = Application.Current.Properties["Name"].ToString();
                txtName.Text = Application.Current.Properties["Name"].ToString();
            }
            // Store all  Values
           // Application.Current.Properties["ID"] = txtId.Text;
            Application.Current.Properties["Name"] = txtName.Text;
            Application.Current.Properties["IsChecked"] = Checkbox.Checked;
            // txtId.Text = string.Empty;
            // txtName.Text = string.Empty;
            Navigation.PushAsync(new MainPage());
        }
    }
}