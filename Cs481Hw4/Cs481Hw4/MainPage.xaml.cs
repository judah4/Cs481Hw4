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
			veggies.Add (new RecipeModel{ Name="Octopus with Black Bean-Pear Sauce", Type="Octopus", Image="beanoct.jpg", Website="http://www.foodandwine.com/recipes/octopus-with-black-bean-pear-sauce"});
			veggies.Add (new RecipeModel{ Name="Octopus Salad with Potatoes and Green Beans", Type="Octopus", Image="saladoct.jpg", Website="http://www.foodandwine.com/recipes/octopus-salad-with-potatoes-and-green-beans"});
			veggies.Add (new RecipeModel{ Name="Red Wine-Braised Baby Octopus with Black Olives", Type="Octopus", Image="wineoct.jpg", Website="http://www.foodandwine.com/recipes/red-wine-braised-baby-octopus-with-black-olives"});
            veggies.Add (new RecipeModel{ Name="Spanish Braised Octopus in Paprika Sauce", Type="Octopus", Image="spanishoct.jpg", Website="https://www.thespruce.com/spanish-braised-octopus-in-paprika-sauce-1300677"});
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
            veggies.Add (new RecipeModel{ Name="Octopus and Seaweed Recipe", Type="Hot Dog", Image="hotdogoct.jpg", Website="https://www.tasteofhome.com/recipes/octopus-and-seaweed"});
            lstView.EndRefresh();
        }
    }
}
