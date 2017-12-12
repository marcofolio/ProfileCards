using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProfileCards
{
    public class Explode : ProfileCardBase
    {
        public Explode() : base("Explode",
                                    new Profile("Grace", "grace@mail.net", "157 - 86 918 305", "grace.jpg"))
        {
            // Initially make the Profile smaller
            Profile.Scale = 0.8;
        }

        public override async Task ShowProfileAsync()
        {
            await Task.WhenAll(
                Profile.FadeTo(1, 700, Easing.CubicInOut),
                Profile.ScaleTo(1, 700, Easing.CubicInOut),

                Picture.FadeTo(0, 700, Easing.CubicInOut),
                Picture.ScaleTo(1.4, 700, Easing.CubicInOut)
            );
        }

        public override async Task HideProfileAsync()
        {
            await Task.WhenAll(
                Profile.FadeTo(0, 700, Easing.CubicInOut),
                Profile.ScaleTo(0.8, 700, Easing.CubicInOut),

                Picture.FadeTo(1, 700, Easing.CubicInOut),
                Picture.ScaleTo(1, 700, Easing.CubicInOut)
            );
        }
    }
}

