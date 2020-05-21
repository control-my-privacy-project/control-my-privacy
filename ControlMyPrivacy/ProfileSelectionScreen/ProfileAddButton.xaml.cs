using ControlMyPrivacy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ControlMyPrivacy.ProfileSelectionScreen
{
    /// <summary>
    /// Interaction logic for ProfileAddButton.xaml
    /// </summary>
    public partial class ProfileAddButton : UserControl
    {
        public event EventHandler<ProfileAddEventArgs> Click;

        public static readonly DependencyProperty SocialMediasProperty = DependencyProperty.Register("SocialMedias", typeof(ObservableCollection<SocialMedia>), typeof(ProfileAddButton));
        public ObservableCollection<SocialMedia> SocialMedias
        {
            get => GetValue(SocialMediasProperty) as ObservableCollection<SocialMedia>;
            set => SetValue(SocialMediasProperty, value);
        }

        public ProfileAddButton() => InitializeComponent();

        public override void EndInit()
        {
            base.EndInit();
            SocialMedias = new ObservableCollection<SocialMedia>() {
                SocialMedia.VK,
                SocialMedia.FaceBook,
                SocialMedia.Twitter
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.Tag is SocialMedia socialMedia)
                Click?.Invoke(this, new ProfileAddEventArgs(socialMedia));
        }
    }
}
