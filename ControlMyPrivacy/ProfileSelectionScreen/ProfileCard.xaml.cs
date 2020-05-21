using ControlMyPrivacy.Models;
using MaterialDesignThemes.Wpf;
using PostSharp.Patterns.Xaml;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ControlMyPrivacy.ProfileSelectionScreen
{
    /// <summary>
    /// Interaction logic for ProfileCard.xaml
    /// </summary>
    public partial class ProfileCard : UserControl
    {
        [DependencyProperty]
        public Profile Profile { get; set; }
        public event EventHandler<ProfileSelectedEventArgs> Click;

        public ProfileCard() => InitializeComponent();

        private void Space_Click(object sender, RoutedEventArgs e) => Click?.Invoke(this, new ProfileSelectedEventArgs(Profile));
    }
}
