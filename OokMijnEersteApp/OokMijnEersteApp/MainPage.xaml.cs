using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OokMijnEersteApp
{
    public partial class MainPage : ContentPage
    {
        public Creature creature { get; set; } = new Creature {};
        public string DisplayHunger { get; set; }


        Timer startTimer = new Timer
        {
            Interval = 60000 * 120 - Preferences.Get("TimerOfset", 0f),
            AutoReset = false
        };

        Timer loopTimer = new Timer
        {
            Interval = 60000 * 120,
            AutoReset = true
        };
        public MainPage()
        {                  
            BindingContext = this;
            InitializeComponent();

            startTimer.Elapsed += StartTimer_Elapsed;
            loopTimer.Elapsed += LoopTimer_Elapsed;

        }

        public void UpdateStats()
        {
            float timeSpend = Preferences.Get("TimeSpend", 12.3f);
            float StatOfset = .1f * timeSpend;
            creature.hunger = Math.Max(creature.hunger - StatOfset, 0);
            creature.thirst = Math.Max(creature.thirst - StatOfset, 0);
            creature.boredom = Math.Max(creature.boredom - StatOfset, 0);
            creature.tired = Math.Max(creature.tired - StatOfset, 0);
            creature.stimulated = Math.Max(creature.stimulated - StatOfset, 0);
            creature.loneliness = Math.Max(creature.loneliness - StatOfset, 0);
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            startTimer.Start();
            UpdateStats();

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creature = await creatureDataStore.ReadItem();
            if (creature == null)
            {
                creature = new Creature { hunger = 0.8f, thirst = 0.8f, loneliness = 1f, boredom = 1f, id = 0, stimulated = 1f, tired = 1f ,userName="Youri"}; //fill in starting data;
                await creatureDataStore.CreateItem(creature);
                creatureDataStore.UpdateItem(creature);
            }
        }

            private async void LoopTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creature = await creatureDataStore.ReadItem();
            if (creature == null)
            {
                creature = new Creature { }; //fill in starting data;
                creatureDataStore.CreateItem(creature);
            }
            creature.hunger = Math.Max(creature.hunger - .1f, 0);
            creature.thirst = Math.Max(creature.thirst - .1f, 0);
            creature.boredom = Math.Max(creature.boredom - .1f, 0); 
            creature.tired = Math.Max(creature.tired - .1f, 0);
            creature.stimulated = Math.Max(creature.stimulated - .1f, 0);
            creature.loneliness = Math.Max(creature.loneliness - .1f, 0);
            creatureDataStore.UpdateItem(creature);
        }

        private async void StartTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creature = await creatureDataStore.ReadItem();
            if (creature == null)
            {
                creature = new Creature { }; //fill in starting data;
                creatureDataStore.CreateItem(creature);
            }
            creature.hunger = Math.Max(creature.hunger - .1f, 0);
            creature.thirst = Math.Max(creature.thirst - .1f, 0);
            creature.boredom = Math.Max(creature.boredom - .1f, 0);
            creature.tired = Math.Max(creature.tired - .1f, 0);
            creature.stimulated= Math.Max(creature.stimulated - .1f, 0);
            creature.loneliness= Math.Max(creature.loneliness- .1f, 0);

            creatureDataStore.UpdateItem(creature);
            loopTimer.Start();
        }

        private void GotoStatPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new StatsPage());
        }

        private void Feed(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Food(creature));
        }

        private void Drink(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Drink(creature));
        }

        private void Play(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Play(creature));
        }

        private void Sleep(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Sleep(creature));
        }

        private void Playground(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PlayGround(creature));
        }
    }
}
