using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProfileCards
{
    public class Slide : ProfileCardBase
    {
        public Slide() : base("Slide",
                                  new Profile("Madison", "madison@mail.net", "071 - 32 098 242", "madison.jpg"))
        {
            // Initially move the Profile to the left
            Profile.TranslationX = -50;
        }

        public override async Task ShowProfileAsync()
        {
            await Task.WhenAll(
                Profile.FadeTo(1, 300, Easing.CubicInOut),
                Profile.TranslateTo(0, 0, 300, Easing.CubicInOut),

                Picture.FadeTo(0, 300, Easing.CubicInOut),
                Picture.TranslateTo(50, 0, 300, Easing.CubicInOut)
            );
        }

        public override async Task HideProfileAsync()
        {
            await Task.WhenAll(
                Profile.FadeTo(0, 300, Easing.CubicInOut),
                Profile.TranslateTo(-50, 0, 300, Easing.CubicInOut),

                Picture.FadeTo(1, 300, Easing.CubicInOut),
                Picture.TranslateTo(0, 0, 300, Easing.CubicInOut)
            );
        }

    }
}

