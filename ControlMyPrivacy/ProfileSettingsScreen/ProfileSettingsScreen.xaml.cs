using ControlMyPrivacy.Models;
using PostSharp.Patterns.Xaml;
using SocialMediaProvider.Providers.VK.Request;
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

namespace ControlMyPrivacy.ProfileSettingsScreen
{
    /// <summary>
    /// Interaction logic for ProfileSettingsScreen.xaml
    /// </summary>
    public partial class ProfileSettingsScreen : UserControl
    {
        [DependencyProperty]
        public ObservableCollection<OptionSettingKey> SettingKeys { get; set; }

        [DependencyProperty]
        public OptionSettingKey AllSettingsKey { get; set; } = new OptionSettingKey("test", new[] { 
           new OptionSettingValue(0, "Bad"),
           new OptionSettingValue(0, "Ok"),
           new OptionSettingValue(0, "Nice"),
           new OptionSettingValue(0, "Excellent"),
        }, "Estimated profile privacy");

        [DependencyProperty]
        public Profile Profile { get; set; }

        public ProfileSettingsScreen() => InitializeComponent();

        public override void EndInit()
        {
            base.EndInit();
            var settingsKeys = OptionSettingKey.DefaultKeys;
            SettingKeys = new ObservableCollection<OptionSettingKey>(settingsKeys);
        }

        private void ProfileSettingCard_OnSelectedSettingChanged(object sender, EventArgs e)
        {
            var newNumber = EstimatedPrivacyCard.SelectedSettingValueNumber;

            for (var i = 0; i < SettingKeys.Count; ++i)
            {
                var container = SettingCards.ItemContainerGenerator.ContainerFromIndex(i);
                var child = container.GetChild<ProfileSettingCard>();
                if(child != null)
                    child.SelectedSettingValueNumber = Math.Min(child?.SettingKey?.PossibleValues?.Length ?? 0, newNumber);
            }


            
        }

        public event EventHandler DeleteProfile;

        private void DeleteProfileButton_Click(object sender, RoutedEventArgs e) => DeleteProfile?.Invoke(this, new EventArgs());
    }

    public static class ItemContainerChild
    {
        public static T GetChild<T>(this DependencyObject obj) where T : DependencyObject
        {
            DependencyObject child = null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child.GetType() == typeof(T))
                {
                    break;
                }
                else if (child != null)
                {
                    child = GetChild<T>(child);
                    if (child != null && child.GetType() == typeof(T))
                    {
                        break;
                    }
                }
            }
            return child as T;
        }
    }
}
