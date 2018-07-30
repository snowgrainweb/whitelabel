using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
namespace SnowGrain
{
	public class ContentListItem: INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;

		private string _Title;

		private string _Image;

		private string _Content;

		private string _Date;

		private string _Name;

		private string _ColorCode;

		private string _DetailImage;

		public string Title { get { return _Title; } set { OnPropertyChanged("Title"); _Title = value; }}

		public string Content { get { return _Content; } set { OnPropertyChanged("Title"); _Content = value; } }

		public string Date { get { return _Date; } set { OnPropertyChanged("Title"); _Date = value; } }

		public string Image { get { return _Image; } set { OnPropertyChanged("Title"); _Image = value; } }

		public string DetailImage { get { return _DetailImage; } set { OnPropertyChanged("Title"); _DetailImage = value; } }

		public string ColorCode { get { return _ColorCode; } set { OnPropertyChanged("Title"); _ColorCode = value; } }

		public string Name { get { return _Name; } set { OnPropertyChanged("Title"); _Name = value; }}

		protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                       new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
