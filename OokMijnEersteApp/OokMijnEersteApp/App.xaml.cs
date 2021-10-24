using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OokMijnEersteApp
{
    public partial class App : Application
    {
        public App()
        {
            DependencyService.RegisterSingleton<IDataStore<Creature>>(new RemoteCreatureStore());

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()){ BarBackgroundColor = Color.Black };
        }

        protected override void OnStart()
        {
            var sleepTime = Preferences.Get("SleepTime", DateTime.Now);
            var wakeTime = DateTime.Now;

            TimeSpan timeAsleep = wakeTime - sleepTime;
            float timeAsleepInMilli = timeAsleep.Milliseconds;
            float timeSpend = (float)Math.Floor(timeAsleepInMilli / (60000 * 120));
            float timerOfset = timeAsleepInMilli % (60000 * 120);
            Preferences.Set("TimeSpend", timeSpend);
            Preferences.Set("TimerOfset", timerOfset);
        }

        protected override void OnSleep()
        {
            var sleepTime = DateTime.Now;
            Preferences.Set("SleepTime", sleepTime);
        }

        protected override void OnResume()
        {
        }
    }
}
