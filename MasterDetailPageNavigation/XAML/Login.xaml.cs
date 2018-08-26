using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhiteLabel
{
    public partial class Login : ContentPage
    {
        public Login()
        {
			NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();
        }

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			
			HomePage productDetail = new HomePage();
			GlobalData.language = picker.SelectedItem.ToString();
            Navigation.PushAsync(productDetail);
		}
    }
}
