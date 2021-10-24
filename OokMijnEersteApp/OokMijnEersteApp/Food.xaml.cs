using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OokMijnEersteApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Food : ContentPage, INotifyPropertyChanged
    {
        public Creature creature { get; set; }
        public int TestLOL{ get; set; } = 200;
        public string CreatureImage { get; set; } = "VibeoVriend.png";
        private float test = 0;
        public Food(Creature tempCreature)
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

        private void FoodDrag(object sender, DragStartingEventArgs e)
        {
            test = 0.1f;
        }
        private void FoodDrag2(object sender, DragStartingEventArgs e)
        {
            test = 0.2f;
        }

        private void FoodGiven(object sender, DropEventArgs e)
        {
            if(creature.hunger < 1)
            {
                   creature.hunger += test;
                if(creature.hunger > 1)
                {
                    creature.hunger = 1;
                }
                var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
                creatureDataStore.UpdateItem(creature);
            }
        }
    }
}