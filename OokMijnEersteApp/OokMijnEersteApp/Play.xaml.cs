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
    public partial class Play : ContentPage
    {
        public Creature creature { get; set; }
        private float test;
        public Play(Creature tempCreature)
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
        private void DragGestureRecognizer_DragStarting(object sender, DragStartingEventArgs e)
        {

        }

        private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
        {
            creature.boredom = Math.Min(creature.boredom + 0.2f, 1);
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(creature);
        }
    }
}