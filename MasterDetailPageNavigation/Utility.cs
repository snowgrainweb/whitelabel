using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Collections;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace SnowGrain
{
	public class Utility
	{
		private const string Url = "https://whitelabel-dxebr.d.epsilon.com/sitecore/api/ssc/aggregate/content/Items('%7b{id}%7d')/Children?$expand=Fields($select=Name,Value,Url)&sc_apikey={3EF5CA5D-52D4-4FCF-A614-6260D5E52522}";
		public static ArticleResponse Articles { get; set; }
        private readonly HttpClient client = new HttpClient();
		public static ObservableCollection<SnowGrain.ContentListItem> contentListItems { get; set; }
        public Utility()
        {
        }
		public static ObservableCollection<SnowGrain.ContentListItem> GetItemList(string content) {
			ArticleResponse response = JsonConvert.DeserializeObject<ArticleResponse>(content);
			contentListItems = new ObservableCollection<SnowGrain.ContentListItem>();
			foreach (ArticleData adata in response.value)
            {
                ContentListItem item = new ContentListItem();
                item.Title = adata.TemplateName;
                item.Date = adata.Updated.ToShortDateString();
				item.ColorCode = GetColorCodeForTemplate(adata.TemplateName);
                foreach (NameValue pair in adata.Fields)
                {
					if(pair.Name == "Abstract"){
                        item.Content = Regex.Replace(pair.Value, "<.*?>", "");
                    }
                    if(pair.Name == "App Details Image") {
                        item.Image = "https://whitelabel-dxebr.d.epsilon.com/sitecore" + pair.Url;
                    }
                    if(pair.Name == "App Name") {
                        item.Name = pair.Value;
                    }
                    if (pair.Name == "App Description")
                    {
                        item.DetailContent = Regex.Replace(pair.Value, "<.*?>", "");
                    }
                    if(pair.Name == "App Published Date") {
						try
						{
							string formatString = "yyyyMMddTHHmmssZ";
							DateTime dt = DateTime.ParseExact(pair.Value, formatString, null);
							string formattedDate = dt.ToString("dd-MM-yyyy");
							item.Date = formattedDate;
						}catch(Exception e){
							item.Date = "[Date]";
						}
                    }      
                }
                contentListItems.Add(item);
            }
			return contentListItems;
		}

		public static ObservableCollection<SnowGrain.ContentListItem> GetItemList(ArticleResponse response)
        {            
            contentListItems = new ObservableCollection<SnowGrain.ContentListItem>();
            foreach (ArticleData adata in response.value)
            {
                ContentListItem item = new ContentListItem();
                item.Title = adata.TemplateName;
                item.Date = adata.Updated.ToShortDateString();
                item.ColorCode = GetColorCodeForTemplate(adata.TemplateName);
                foreach (NameValue pair in adata.Fields)
                {
                    if (pair.Name == "Abstract")
                    {
                        item.Content = Regex.Replace(pair.Value, "<.*?>", "");
                    }
                    if (pair.Name == "App Details Image")
                    {
                        item.Image = "https://whitelabel-dxebr.d.epsilon.com/sitecore" + pair.Url;
                    }
                    if (pair.Name == "App Name")
                    {
                        item.Name = pair.Value;
                    }
                    if (pair.Name == "App Description")
                    {
                        item.DetailContent = Regex.Replace(pair.Value, "<.*?>", "");
                    }
                    if (pair.Name == "App Published Date")
                    {
                        try
                        {
                            string formatString = "yyyyMMddTHHmmssZ";
                            DateTime dt = DateTime.ParseExact(pair.Value, formatString, null);
                            string formattedDate = dt.ToString("dd-MM-yyyy");
                            item.Date = formattedDate;
                        }
                        catch (Exception e)
                        {
                            item.Date = "[Date]";
                        }
                    }
                }
                contentListItems.Add(item);
            }
            return contentListItems;
        }

		public static string GetColorCodeForTemplate(string templateName) {
			switch(templateName) {
				case "Article Details" :
					return "#1e1e70";
				case "Product Details" :
					return "#961338";
				case "Author" :
					return "#000000";
				case "Offer Details":
					return "#8914ad";
			}
			return "#000000";
		}
		public static Type GetTargetType(string templateName) {
			switch (templateName)
            {
				case "Article Category":
					return typeof(Articles);
				case "Product Category":
					return typeof(ProductsPage);
                case "Author":
					return typeof(ProductsPage);
				case "Offer Category":
					return typeof(OffersPage);
            }
			return typeof(HomePage);
		}
    }
	public class ArticleResponse
    {
        public string context { get; set; }
        public List<ArticleData> value { get; set; }
    }
}
