using System;
using System.Collections;
namespace SnowGrain
{
    public class ArticleData
    {
		public string Name { get; set; }
		public string DisplayName { get; set; }
		public string TemplateName { get; set; }
		public DateTime Updated { get; set; }
		public System.Collections.Generic.List<NameValue> Fields { get; set; }
    }
}
