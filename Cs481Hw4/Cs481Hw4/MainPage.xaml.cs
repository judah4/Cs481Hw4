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
			veggies.Add (new RecipeModel{ Name="Tomato", Type="Fruit", Image="tomato.png"});
			veggies.Add (new RecipeModel{ Name="Romaine Lettuce", Type="Vegetable", Image="lettuce.png"});
			veggies.Add (new RecipeModel{ Name="Zucchini", Type="Vegetable", Image="zucchini.png"});
            lstView.ItemsSource = veggies;
        }
    }
}
