using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OokMijnEersteApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sleep : ContentPage
    {
        public Creature creature { get; set; }
        public Sleep(Creature tempCreature)
        {
            tempCreature = creature;
            BindingContext = this;
            InitializeComponent();
            sleepTimer.Elapsed += SleepTimer_Elapsed;
            sleepTimer.Start();
        }

        Timer sleepTimer = new Timer
        {
            Interval = 1000 * 60,
            AutoReset = true
        };
        private async void SleepTimer_Elapsed(object sender, ElapsedEventArgs e) 
        {
            creature.tired = Math.Min(creature.tired + 0.2f, 1);
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(creature);
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creature = await creatureDataStore.ReadItem();
        }
    }
}