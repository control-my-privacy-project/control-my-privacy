using ControlMyPrivacy.Models;
using PostSharp.Patterns.Xaml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ControlMyPrivacy.ScreenController
{
    /// <summary>
    /// Interaction logic for ScreenController.xaml
    /// </summary>
    public partial class ScreenController : UserControl
    {
        private static readonly PossibleScreen[] ReturnBackScreens = new[] {
            PossibleScreen.ProfileSettings,
            PossibleScreen.ProfileSignIn
        };

        [DependencyProperty]
        public PossibleScreen CurrentScreen { get; set; }

        [DependencyProperty]
        public bool ReturnBackVisibility { get; set; }

        [DependencyProperty]
        public Profile CurrentProfile { get; set; }

        [DependencyProperty]
        public ObservableCollection<Profile> DisplayedProfiles { get; set; }

        [DependencyProperty]
        public string RealName { get; set; }

        public ScreenController()
        {
            InitializeComponent();
        }

        public override void EndInit()
        {
            base.EndInit();
            DisplayedProfiles = new ObservableCollection<Profile>() {
                new Profile("Archie Andrews", "@archi.andrews.395", @"https://scontent-frt3-1.xx.fbcdn.net/v/t1.0-1/p320x320/60177257_104130784157181_5477439760446259200_n.jpg?_nc_cat=106&_nc_sid=dbb9e7&_nc_ohc=MX6niBsR5r0AX_2Ju6g&_nc_ht=scontent-frt3-1.xx&_nc_tp=6&oh=30ff511933faeca8f0ad38d8a1d49aa0&oe=5EEE08BA", SocialMedia.FaceBook),
                new Profile("Jughead Jones", "@alwaysravenous", @"https://pbs.twimg.com/profile_images/1080283355411824641/Dy-1KW0C_400x400.jpg", SocialMedia.Twitter)
            };
            RealName ="Archie";
        }

        public void ReturnBack() => CurrentScreen = PossibleScreen.ProfileSelection;

        public void OnCurrentScreenChanged() => ReturnBackVisibility = ReturnBackScreens.Contains(CurrentScreen);

        private void ProfileSelectionScreen_ProfileSelected(object sender, ProfileSelectionScreen.ProfileSelectedEventArgs e)
        {
            CurrentProfile = e.Profile;
            CurrentScreen = PossibleScreen.ProfileSettings;
        }

        private void ProfileSelectionScreen_ProfileAdd(object sender, ProfileSelectionScreen.ProfileAddEventArgs e)
        {
            ProfileSignInScreen.SocialMedia = e.SocialMedia;
            CurrentScreen = PossibleScreen.ProfileSignIn;
        }

        private readonly List<Profile> ProfilesToDisplay = new List<Profile>() {
            new Profile("Betty Cupper", "@id583115220", @"https://sun2-3.userapi.com/4PIJ_ZUSLgc35NZbMDbF12d3IJ6kIA2f4LhWPw/nzc_pXNbBjI.jpg", SocialMedia.VK)
        };

        private void ProfileSignInScreen_ProfileSignedIn(object sender, ProfileSignInScreen.ProfileSignedInEventArgs e)
        {
            if (e.SocialMedia == SocialMedia.VK) {
                Debug.WriteLine(e.Parameters.session as string);
            }

            if (ProfilesToDisplay.Count > 0) {

                var profile = ProfilesToDisplay[0];
                DisplayedProfiles.Add(profile);
                ProfilesToDisplay.Remove(profile);

                ReturnBack();
            }
        }

        private void ProfileSettingsScreen_DeleteProfile(object sender, System.EventArgs e)
        {
            if (sender is ProfileSettingsScreen.ProfileSettingsScreen proflesettingsscreen)
            {
                DisplayedProfiles.Remove(proflesettingsscreen.Profile);
                ReturnBack();
            }
        }
    }
}
