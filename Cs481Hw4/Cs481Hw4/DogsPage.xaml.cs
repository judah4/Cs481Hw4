using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Cs481Hw4.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cs481Hw4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DogsPage : ContentPage
    {
        public ObservableCollection<RecipeModel> Items { get; set; }

        public DogsPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<RecipeModel>();

            Items = new ObservableCollection<RecipeModel> ();
            BuildRecipes(false);
		    lstView.ItemsSource = Items;
        }


        async void BuildRecipes(bool hotdog)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://www.dogsonly.org/feed.xml");
            var data = await response.Content.ReadAsStringAsync();
            XDocument.Parse(data);
            var reader = XmlReader.Create(TextReader.Null);
            var channel = reader["channel"];
            Items.Add(new RecipeModel()
            {
                Name = data,
                Type = "All"
                
            });
            Items.Add(new RecipeModel()
            {
                Name = channel.ToString(),
                Type = "Channel"
                
            });
            //for (int cnt = 3; cnt < channel.Length; cnt++)
            //{
            //    var item = channel[cnt];
            //}
            
        }

        void Handle_NavigateToUrl(object sender, System.EventArgs e)
		{
            var listViewItem = (MenuItem)sender;
            var url = (string)listViewItem.CommandParameter;
            Device.OpenUri(new Uri(url));
		}

        void Handle_Delete(object sender, System.EventArgs e)
		{
            var listViewItem = (MenuItem)sender;
            var item = (RecipeModel)listViewItem.BindingContext;
		    Items.Remove(item);
		}

        void OpenWebsite(string url)
        {
            Device.OpenUri(new Uri(url));
        }

        private void Handle_Refreshing(object sender, EventArgs e)
        {
            Items.Clear();
            BuildRecipes(true);
            lstView.EndRefresh();
        }

        private void Cell_OnTapped(object sender, EventArgs e)
        {
            var cell = (ImageCell)sender;
            var item = (RecipeModel)cell.BindingContext;
            OpenWebsite(item.Website);
        }
    }
}