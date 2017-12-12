using System;

using Xamarin.Forms;

namespace ProfileCards
{
    public class App : Application
    {
        public App()
        {
            // Simple app showing the power of Xamarin.Forms Animations
            // https://developer.xamarin.com/guides/xamarin-forms/user-interface/animation/simple/

            // Based on the animations from
            // "CSS animated profile cards"
            // https://marcofolio.net/css-animated-profile-cards/

            MainPage = new ProfileCardHolder();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
