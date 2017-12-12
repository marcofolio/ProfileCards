using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProfileCards
{
    public abstract class ProfileCardBase : ContentPage
    {
        private bool _profileIsShowing;

        // The Profile and Picture are properties the several Animations will use to animate
        public Grid Profile { get; set; }
        public Image Picture { get; set; }

        // These methods will be called when the uses Taps
        public abstract Task ShowProfileAsync();
        public abstract Task HideProfileAsync();

        public ProfileCardBase(string headerText, Profile profile)
        {
            var grid = CreateBackgroundGrid();

            var header = CreateHeader(headerText);
            Picture = CreateProfilePicture(profile);
            Profile = CreateProfileGrid(profile);
            var tapFrame = CreateTapFrame();

            grid.Children.Add(header, 0, 0);

            // The Picture, Profile and tapFrame are placed in the same Cell of the Grid
            // which causes them to stack on top of eachother
            grid.Children.Add(Picture, 0, 1);
            grid.Children.Add(Profile, 0, 1);
            grid.Children.Add(tapFrame, 0, 1);

            Content = grid;
        }

        private Grid CreateBackgroundGrid()
        {
            var grid = new Grid()
            {
                BackgroundColor = Color.FromHex("1B272C")
            };
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Star });
            grid.RowDefinitions.Add(new RowDefinition());
            return grid;
        }

        private Label CreateHeader(string headerText)
        {
            return new Label
            {
                Text = headerText,
                FontSize = 40,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.White,
                Margin = new Thickness(0, 50, 0, 0)
            };
        }

        private Image CreateProfilePicture(Profile profile)
        {
            return new Image()
            {
                Source = ImageSource.FromResource("ProfileCards.images." + profile.Picture),
                WidthRequest = 150,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
        }

        private Grid CreateProfileGrid(Profile profile)
        {
            var profileGrid = new Grid()
            {
                WidthRequest = 150,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Opacity = 0,
                BackgroundColor = Color.FromRgba(55, 168, 80, 178) // Alpha in Xam. Forms is 0-255, not a 0-1 value.
            };
            var name = new Label()
            {
                Text = profile.Name,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.End,
                FontSize = 25,
                Margin = new Thickness(5, 5, 5, 0)
            };

            var mail = new Label()
            {
                Text = profile.Mail,
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.End,
                FontSize = 16,
                Margin = new Thickness(5, 0, 5, 0)
            };
            var phone = new Label()
            {
                Text = profile.Phone,
                TextColor = Color.White,
                HorizontalTextAlignment = TextAlignment.End,
                FontSize = 16,
                Margin = new Thickness(5, 0, 5, 0)
            };

            profileGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            profileGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
            profileGrid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            profileGrid.Children.Add(name, 0, 0);
            profileGrid.Children.Add(mail, 0, 1);
            profileGrid.Children.Add(phone, 0, 2);

            return profileGrid;
        }

        private Frame CreateTapFrame()
        {
            var frame = new Frame()
            {
                WidthRequest = 150,
                HeightRequest = 200,
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HasShadow = false
            };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += OnFrameTapped;
            frame.GestureRecognizers.Add(tapGestureRecognizer);
            return frame;
        }

        private async void OnFrameTapped(object sender, EventArgs e)
        {
            if (_profileIsShowing)
            {
                await HideProfileAsync();
                _profileIsShowing = false;
            }
            else
            {
                await ShowProfileAsync();
                _profileIsShowing = true;
            }
        }
    }
}
