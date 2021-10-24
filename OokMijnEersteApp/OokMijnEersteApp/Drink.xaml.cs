using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OokMijnEersteApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Drink : ContentPage, INotifyPropertyChanged
    {
        public Creature creature { get; set; } = new Creature();
        public string WaterLevel => SecondsPassed switch 
        {
            >= 5 => "OverVolGlas.png",
            > 3 => "VolGlas.png",
            > 2 => "DrieVierdeGlas.png",
            > 1 => "HalfGlas.png",
            > 0 => "EenVierdeGlas.png",
            <= 0 => "LeegGlas.png"
        };

        private Stopwatch ButtonPressTime = new Stopwatch();
        private int SecondsPassed { get; set; }
        public Drink(Creature tempCreature)
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

        private void Button_Pressed(object sender, EventArgs e)
        {
            ButtonPressTime.Start();
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                SecondsPassed = ButtonPressTime.Elapsed.Seconds;
                if (!ButtonPressTime.IsRunning)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            });

            }

        private void Button_Released(object sender, EventArgs e)
        {
            ButtonPressTime.Stop();
            if(ButtonPressTime.Elapsed.Seconds == 4)
            {
                creature.thirst = Math.Min(creature.thirst + 0.2f, 1);
            }
            SecondsPassed = 0;
            ButtonPressTime.Reset();
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(creature); 
        }
    }
}