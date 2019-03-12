using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Appcachstorage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //if (Application.Current.Properties.ContainsKey("ID"))
            //{

            //    txtId.Text = Application.Current.Properties["Name"].ToString();
            //    txtName.Text = Application.Current.Properties["ID"].ToString();
            //}
            //btnStore.Clicked += BtnStore_Clicked;
            //btnGet.Clicked += BtnGet_Clicked;
            //btnRemove.Clicked += BtnRemove_Clicked;
           // btnClear.Clicked += BtnClear_Clicked;
            //switch1.Toggled += Switch1_Toggled;
        }
        
        //private void BtnRemove_Clicked(object sender, EventArgs e)
        //{
        //    //Remove all Properties
        //    if (Application.Current.Properties.ContainsKey("ID"))
        //    {
        //        Application.Current.Properties.Remove("ID");
        //        Application.Current.Properties.Remove("Name");
        //        Application.Current.Properties.Remove("IsMVP");
        //        ClearAll();
        //        DisplayAlert("Success", "All Vaues Removed", "OK");
        //    }
        //}
        //private void Switch1_Toggled(object sender, ToggledEventArgs e)
        //{
        //    Application.Current.Properties["IsMVP"] = switch1.IsToggled;
        //}
        
        //private void BtnStore_Clicked(object sender, EventArgs e)
        //{
        //   if(Application.Current.Properties.ContainsKey("ID"))
        //    {

        //        txtId.Text = Application.Current.Properties["Name"].ToString();
        //        txtName.Text = Application.Current.Properties["ID"].ToString();
        //    }
        //    // Store all  Values
        //    Application.Current.Properties["ID"] = txtId.Text;
        //    Application.Current.Properties["Name"] = txtName.Text;
        //    Application.Current.Properties["IsMVP"] = switch1.IsToggled;
        //   // txtId.Text = string.Empty;
        //   // txtName.Text = string.Empty;
        //    DisplayAlert("Success", "All Vaues stored", "OK");
        //}
        //public void ClearAll()
        //{
        //    lblId.Text = string.Empty;
        //    lblName.Text = string.Empty;
        //    lblIsMVP.Text = string.Empty;
        //}
    }
}
