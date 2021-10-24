using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OokMijnEersteApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tuin : ContentPage
    {
        public Tuin()
        {
            InitializeComponent();
        }

        private void FoodOneDrag(object sender, DragStartingEventArgs e)
        {

        }
    }
}