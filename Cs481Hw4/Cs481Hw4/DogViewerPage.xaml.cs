using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cs481Hw4.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cs481Hw4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DogViewerPage : ContentPage
    {
        public DogViewerPage(DogModel model)
        {
            InitializeComponent();
            BindingContext = model;

            
        }
    }
}