using System;

using Xamarin.Forms;

namespace ProfileCards
{
    public class ProfileCardHolder : TabbedPage
    {
        public ProfileCardHolder()
        {
            var pushPage = new Push();
            pushPage.Padding = GetPagePadding();
            pushPage.Title = "Push";
            Children.Add(pushPage);

            var slidePage = new Slide();
            slidePage.Padding = GetPagePadding();
            slidePage.Title = "Slide";
            Children.Add(slidePage);

            var flipPage = new Flip();
            flipPage.Padding = GetPagePadding();
            flipPage.Title = "Flip";
            Children.Add(flipPage);

            var explodePage = new Explode();
            explodePage.Padding = GetPagePadding();
            explodePage.Title = "Explode";
            Children.Add(explodePage);
        }

        private Thickness GetPagePadding()
        {
            double topPadding;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    topPadding = 30;
                    break;
                default:
                    topPadding = 0;
                    break;
            }

            return new Thickness(0, topPadding, 0, 0);
        }
    }
}

