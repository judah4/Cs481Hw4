using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs481Hw4.Models;
using Xamarin.Forms;

namespace Cs481Hw4
{
    public partial class MainPage : ContentPage
    {

        public ObservableCollection<RecipeModel> veggies { get; set; }


        public MainPage()
        {
            InitializeComponent();

            veggies = new ObservableCollection<RecipeModel> ();
			veggies.Add (new RecipeModel{ Name="Grilled Octopus with Ancho Chile Sauce", Type="Octopus", Image="grilledoct.jpg", Website="http://www.foodandwine.com/recipes/grilled-octopus-ancho-chile-sauce"});
			veggies.Add (new RecipeModel{ Name="Octopus with Chorizo and Potatoes", Type="Octopus", Image="chorizooct.jpg", Website="http://www.foodandwine.com/recipes/octopus-chorizo-and-potatoes"});
			veggies.Add (new RecipeModel{ Name="Octopus Turnovers with Spicy Creole Mayonnaise", Type="Octopus", Image="turnoveroct.jpg", Website="http://www.foodandwine.com/recipes/octopus-turnovers-with-spicy-creole-mayonnaise"});
            veggies.Add (new RecipeModel{ Name="Pan-Seared Octopus with Italian Vegetable Salad", Type="Octopus", Image="searedoct.jpg", Website="http://www.foodandwine.com/recipes/pan-seared-octopus-with-italian-vegetable-salad"});
			veggies.Add (new RecipeModel{ Name="Grilled Octopus with Ancho Chile Sauce", Type="Octopus", Image="grilledoct.jpg", Website="http://www.foodandwine.com/recipes/grilled-octopus-ancho-chile-sauce"});
			veggies.Add (new RecipeModel{ Name="Grilled Octopus with Ancho Chile Sauce", Type="Octopus", Image="grilledoct.jpg", Website="http://www.foodandwine.com/recipes/grilled-octopus-ancho-chile-sauce"});
			veggies.Add (new RecipeModel{ Name="Grilled Octopus with Ancho Chile Sauce", Type="Octopus", Image="grilledoct.jpg", Website="http://www.foodandwine.com/recipes/grilled-octopus-ancho-chile-sauce"});

            lstView.ItemsSource = veggies;
        }

        void Handle_NavigateToUrl(object sender, System.EventArgs e)
		{
            var listViewItem = (MenuItem)sender;
            var url = (string)listViewItem.CommandParameter;
            Device.OpenUri(new Uri(url));
		}

        void OpenWebsite(string url)
        {
            Device.OpenUri(new Uri(url));
        }

        private void LstView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var lister = ((ListView)sender);
            var item = (RecipeModel)lister.SelectedItem;
            OpenWebsite(item.Website);
        }

        private void Handle_Refreshing(object sender, EventArgs e)
        {
            
        }
    }
}
