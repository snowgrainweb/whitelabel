using Xamarin.Forms;
using System.Collections.Generic;  
using System.Net.Http;  
using Newtonsoft.Json;  
using System.Collections.ObjectModel;  
namespace SnowGrain
{

	public partial class HomePage : ContentPage
	{
		public ListView ListView { get { return listView1; } }

		public ObservableCollection<SnowGrain.ContentListItem> contentListItems { get; set; }

		public HomePage ()
		{
			InitializeComponent ();
			contentListItems = new ObservableCollection<SnowGrain.ContentListItem>();
			contentListItems.Add(new SnowGrain.ContentListItem
            {
				Title = "Product",
				Image = "http://www.millaboratories.in/wp-content/uploads/2015/10/banner1.png",
				Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque est ex, gravida quis varius in, pretium et augue. Donec bibendum rutrum enim, vitae ultricies tortor semper nec.",
                Date = "23-07-2018",
				ColorCode = "#66cc88"
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
                ColorCode = "#66cc88"
            });

                     
			listView1.ItemsSource = contentListItems;
		}
	}
}

