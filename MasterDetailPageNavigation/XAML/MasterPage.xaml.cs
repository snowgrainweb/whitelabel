using Xamarin.Forms;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SnowGrain
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }

		public ObservableCollection<SnowGrain.MasterPageItem> masterpageItem { get; set; }
        public MasterPage()
        {
            InitializeComponent();

			masterpageItem = new ObservableCollection<SnowGrain.MasterPageItem>();
			masterpageItem.Add(new SnowGrain.MasterPageItem
            {
                Title = "Home",
				TargetType = typeof(SnowGrain.HomePage),
				IconSource = "https://png.icons8.com/material/50/FFFFFF/home-page.png"
            });

			masterpageItem.Add(new SnowGrain.MasterPageItem
            {
                Title = "Articles",
				TargetType = typeof(SnowGrain.Articles),
				IconSource = "https://png.icons8.com/material/50/FFFFFF/news-filled.png"
            });

			masterpageItem.Add(new SnowGrain.MasterPageItem
            {
                Title = "Products",
				TargetType = typeof(SnowGrain.ProductsPage),
				IconSource = "https://png.icons8.com/material/50/FFFFFF/box.png"
            });

			masterpageItem.Add(new SnowGrain.MasterPageItem
            {
                Title = "Offers",
				TargetType = typeof(SnowGrain.OffersPage),
				IconSource = "https://png.icons8.com/material/50/FFFFFF/discount.png"
            });

			masterpageItem.Add(new SnowGrain.MasterPageItem
            {
                Title = "Contact Us",
				TargetType = typeof(SnowGrain.HomePage),
				IconSource = "https://png.icons8.com/material/50/FFFFFF/contacts.png"
            });

			masterpageItem.Add(new SnowGrain.MasterPageItem
            {
                Title = "Privacy Policy",
				TargetType = typeof(SnowGrain.HomePage),
				IconSource = "https://png.icons8.com/material/50/FFFFFF/privacy.png"
            });

			masterpageItem.Add(new SnowGrain.MasterPageItem
            {
                Title = "M-Pay",
				TargetType = typeof(SnowGrain.HomePage),
				IconSource = "https://png.icons8.com/metro/50/FFFFFF/bank-cards.png"
            });

			masterpageItem.Add(new SnowGrain.MasterPageItem
            {
                Title = "Preferences and Settings",
                TargetType = typeof(SnowGrain.HomePage),
				IconSource = "https://png.icons8.com/metro/50/FFFFFF/services.png"
            });

			masterpageItem.Add(new SnowGrain.MasterPageItem
            {
                Title = "Login",
				TargetType = typeof(SnowGrain.HomePage),
				IconSource = "https://png.icons8.com/material/50/FFFFFF/user-credentials.png"
            });

            listView.ItemsSource = masterpageItem;
        }
    }
}
