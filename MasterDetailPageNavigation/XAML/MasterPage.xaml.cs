using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Collections;
using System.Text.RegularExpressions;
using System;
using System.Globalization;
using Newtonsoft.Json;  
using System.Collections.ObjectModel; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SnowGrain
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
		private const string Url = "https://whitelabel-dxebr.d.epsilon.com/api/sitecore/mobileapp/navigation";
		public ObservableCollection<SnowGrain.MasterPageItem> masterpageItem { get; set; }
		private readonly HttpClient client = new HttpClient();
		public bool IsInProgress = true;
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
		protected override async void OnAppearing()
		{
			string content = await client.GetStringAsync(Url);
            masterpageItem = new ObservableCollection<MasterPageItem>();
			MenuItemResponse response = JsonConvert.DeserializeObject<MenuItemResponse>(content);
			foreach(MenuItem item in response.NavigationList) {
				MasterPageItem mItem = new MasterPageItem();
				mItem.IconSource = "https://whitelabel-dxebr.d.epsilon.com/sitecore" + item.iconUrl;
				mItem.Title = item.Title;
				mItem.TargetType = null;
				mItem.Guid = item.Guid;
				mItem.IsInProgress = false;
				masterpageItem.Add(mItem);
			}
			listView.ItemsSource = masterpageItem;
			base.OnAppearing();
		}
	}
    
	class MenuItem {
		public string Guid { get; set; }
		public string Title { get; set; }
		public string iconUrl { get; set; }
		public string IsInProgress { get; set; }
	}
	class MenuItemResponse {
		public List<MenuItem> NavigationList { get; set; }
	}
}
