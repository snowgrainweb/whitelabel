using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Collections;
using System.Text.RegularExpressions;
using Newtonsoft.Json;  
using System.Collections.ObjectModel; 

namespace SnowGrain
{
    public partial class OffersPage : ContentPage
    {
		private const string Url = "https://whitelabel-dxebr.d.epsilon.com/sitecore/api/ssc/aggregate/content/Items('%7b1CCBAD59-52A6-4767-9DC7-AC5575E15D12%7d')/Children?$expand=Fields($select=Name,Value,Url)&sc_apikey={3EF5CA5D-52D4-4FCF-A614-6260D5E52522}";

        private readonly HttpClient client = new HttpClient();

        public ListView ListView { get { return listView1; } }

        public bool IsBusy = true;

		public ObservableCollection<SnowGrain.ContentListItem> contentListItems { get; set; }

		public OffersPage()
        {
            InitializeComponent();
			contentListItems = new ObservableCollection<SnowGrain.ContentListItem>();
			contentListItems.Add(new SnowGrain.ContentListItem
            {
                Title = "Product",
                Image = "http://www.millaboratories.in/wp-content/uploads/2015/10/banner1.png",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque est ex, gravida quis varius in, pretium et augue. Donec bibendum rutrum enim, vitae ultricies tortor semper nec.",
                Date = "23-07-2018",
                ColorCode = "#6688cc"
            });
			contentListItems.Add(new SnowGrain.ContentListItem
            {
                Title = "Article",
                Image = "https://www.solidworks.com/sites/default/files/2017-12/PRODUCT-CATEGORY-TECH-COM-inspection-MBD-shop%20floor-composer-edrawings-hero-001.jpg",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque est ex, gravida quis varius in, pretium et augue. Donec bibendum rutrum enim, vitae ultricies tortor semper nec.",
                Date = "23-07-2018",
                ColorCode = "#6688cc"
            });
			contentListItems.Add(new SnowGrain.ContentListItem
            {
                Title = "Product",
                Image = "https://yj4dfcucm3mswcd2nbkkg14m-wpengine.netdna-ssl.com/wp-content/uploads/2017/11/featureimagesArtboard-1-100.jpg",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque est ex, gravida quis varius in, pretium et augue. Donec bibendum rutrum enim, vitae ultricies tortor semper nec.",
                Date = "23-07-2018",
                ColorCode = "#6688cc"
            });


            //listView1.ItemsSource = contentListItems;
        }

        protected override async void OnAppearing()
        {
            Device.BeginInvokeOnMainThread(() => { listView1.IsRefreshing = true; listView1.BeginRefresh(); });
            string content = await client.GetStringAsync(Url);
			contentListItems = new ObservableCollection<SnowGrain.ContentListItem>();
            ArticleResponse response = JsonConvert.DeserializeObject<ArticleResponse>(content);
            System.Diagnostics.Debug.WriteLine(content);
            foreach (ArticleData adata in response.value)
            {
                ContentListItem item = new ContentListItem();
                item.Title = adata.TemplateName;
                item.Date = adata.Updated.ToShortDateString();
				item.ColorCode = "#8914ad";
                foreach (NameValue pair in adata.Fields)
                {
                    if (pair.Name == "Abstract")
                    {
                        item.Content = Regex.Replace(pair.Value, "<.*?>", "");
                    }
                    if (pair.Name == "Tile Image")
                    {
                        item.Image = "https://whitelabel-dxebr.d.epsilon.com/sitecore" + pair.Url;
                    }
					if (pair.Name == "Title")
                    {
                        item.Name = pair.Value;
                    }
                }
                contentListItems.Add(item);
            }
            InitializeComponent();
            listView1.IsVisible = false;
            listView1.ItemsSource = null;
            listView1.ItemsSource = contentListItems;
            Device.BeginInvokeOnMainThread(() => { listView1.IsRefreshing = false; listView1.EndRefresh(); });
            IsBusy = false;
            listView1.IsVisible = true;
            base.OnAppearing();
        }
        class ArticleResponse
        {
            public string context { get; set; }
            public List<ArticleData> value { get; set; }
        }
    }
}
