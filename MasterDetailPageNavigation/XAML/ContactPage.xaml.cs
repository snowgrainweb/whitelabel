using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WhiteLabel
{
    public partial class ContactPage : ContentPage
    {
        public ContactPage()
        {
            InitializeComponent();
        }
        
		void Handle_Clicked(object sender, System.EventArgs e)
		{
			Device.OpenUri(new Uri("mailto:support@whitelabel.com"));
		}

		void Handle_Clicked_1(object sender, System.EventArgs e)
		{
			Device.OpenUri(new Uri("tel:1800-123-987"));
		}
    }
}
