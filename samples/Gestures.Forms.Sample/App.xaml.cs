using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Velocity.Gestures.Forms.Sample.Services;
using Velocity.Gestures.Forms.Sample.Views;

namespace Velocity.Gestures.Forms.Sample
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
