using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProfileCards
{
    public class Push : ProfileCardBase
    {
        public Push() : base("Push",
                                 new Profile("Sophia", "sophia@mail.net", "004 - 41 290 428", "sophia.jpg")) { }

        public override async Task ShowProfileAsync()
        {
            await Task.WhenAny
            (
                Task.WhenAll(
                              Picture.FadeTo(0.7, 500, Easing.CubicInOut),
                              Picture.ScaleTo(0.7, 500, Easing.CubicInOut),
                              Picture.RotateTo(10, 500, Easing.CubicInOut)),
                Task.Delay(200) // The delay finishes first
            );

            await Profile.FadeTo(1, 150);
        }

        public override async Task HideProfileAsync()
        {
            await Task.WhenAny
            (
                Task.WhenAll(
                              Picture.FadeTo(1, 500, Easing.CubicInOut),
                              Picture.ScaleTo(1, 500, Easing.CubicInOut),
                              Picture.RotateTo(0, 500, Easing.CubicInOut)),
                Task.Delay(200) // The delay finishes first
            );

            await Profile.FadeTo(0, 150);
        }
    }
}

