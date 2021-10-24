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
    public partial class StatsPage : ContentPage
    {
        public Creature creature { get; set; }

        public StatsPage()
        {
            BindingContext = this;
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creature = await creatureDataStore.ReadItem();
            if (creature == null)
            {
                creature = new Creature { hunger = 0.8f, thirst = 0.8f, loneliness = 1f, boredom = 1f, id = 0, stimulated = 1f, tired = 1f }; //fill in starting data;
                creatureDataStore.CreateItem(creature);
            }
        }


    }
}