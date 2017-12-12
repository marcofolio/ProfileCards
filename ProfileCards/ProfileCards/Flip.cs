using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProfileCards
{
    public class Flip : ProfileCardBase
    {
        public Flip() : base("Flip",
                                 new Profile("Elizabeth", "elizabeth@mail.net", "102 - 54 910 231", "elizabeth.jpg"))
        {
            // Initially rotate the Profile
            Profile.RotationY = -90;
        }

        public override async Task HideProfileAsync()
        {
            await Profile.RotateYTo(-90, 400, Easing.CubicIn);
            Profile.Opacity = 0;
            await Picture.RotateYTo(0, 400, Easing.CubicOut);
        }

        public override async Task ShowProfileAsync()
        {
            await Picture.RotateYTo(90, 400, Easing.CubicIn);
            Profile.Opacity = 1;
            await Profile.RotateYTo(0, 400, Easing.CubicOut);
        }
    }
}

