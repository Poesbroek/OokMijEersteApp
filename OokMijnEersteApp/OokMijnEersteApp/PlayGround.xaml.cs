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
    public partial class PlayGround : ContentPage
    {
        public Creature creature { get; set; }
        public PlayGround(Creature tempCreature)
        {
            tempCreature = creature;
            BindingContext = this;
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creature = await creatureDataStore.ReadItem();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            creature.loneliness = Math.Min(creature.loneliness + 0.1f, 1);
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(creature);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            creature.stimulated = Math.Min(creature.stimulated + 0.1f, 1);
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(creature);
        }
    }
}