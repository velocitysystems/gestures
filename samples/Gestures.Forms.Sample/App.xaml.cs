using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Gestures.Forms.Sample.Services;
using Gestures.Forms.Sample.Views;

namespace Gestures.Forms.Sample
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
