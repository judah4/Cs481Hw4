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
        public ObservableCollection<DogModel> Items { get; set; }

        public DogsPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<DogModel>();

            Items = new ObservableCollection<DogModel> ();
            BuildRecipes(false);
		    lstView.ItemsSource = Items;
        }


        async void BuildRecipes(bool hotdog)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://www.dogsonly.org/feed.xml");
            var data = await response.Content.ReadAsStringAsync();
            var doc = XDocument.Parse(data);

            //Items.Add(new DogModel()
            //{
            //    Name = data,
            //    Desc = "All"
                
            //});

            foreach (var node in doc.Descendants("item"))
            {
                if (node.Name == "item")
                {
                    var model = new DogModel();
                    foreach (var descendant in node.Descendants())
                    {
                        if (descendant.Name == "title")
                        {
                            model.Title = descendant.Value;
                            model.Name = model.Title.Split(' ')[0];
                        }
                        else if (descendant.Name == "description")
                        {
                            model.Desc = descendant.Value;
                        }
                        else if (descendant.Name == "link")
                        {
                            model.Website = descendant.Value;
                        }
                    }

                     Items.Add(model);
                }
            }


        }

        async Task Handle_NavigateToUrl(object sender, EventArgs e)
		{
            var listViewItem = (MenuItem)sender;
            var item = (DogModel)listViewItem.BindingContext;
		    await Navigation.PushAsync(new DogViewerPage(item));
		    //await DisplayAlert("Item Tapped", item.Name, "OK"); 

		}

        void Handle_Delete(object sender, System.EventArgs e)
		{
            var listViewItem = (MenuItem)sender;
            var item = (DogModel)listViewItem.BindingContext;
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
            var item = (DogModel)cell.BindingContext;
            OpenWebsite(item.Website);
        }

    }
}