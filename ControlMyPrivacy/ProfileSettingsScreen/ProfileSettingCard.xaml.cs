using ControlMyPrivacy.Models;
using PostSharp.Patterns.Xaml;
using SocialMediaProvider.Providers.VK.Request;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ProfileSettingCard.xaml
    /// </summary>
    public partial class ProfileSettingCard : UserControl
    {
        [DependencyProperty]
        public OptionSettingKey SettingKey { get; set; }
        [DependencyProperty]
        public OptionSettingValue SelectedSettingValue { get; set; }
        [DependencyProperty]
        public int SelectedSettingValueNumber { get; set; }

        public event EventHandler OnSelectedSettingChanged;

        public ProfileSettingCard() => InitializeComponent();

        public void OnSettingKeyChanged()
        {
            Render();
            SelectedSettingValueNumber = random.Next(1, SettingKey?.PossibleValues?.Length ?? 0);
        }

        public void OnSelectedSettingValueNumberChanged()
        {
            OnSelectedSettingChanged?.Invoke(this, new EventArgs());
            Render();
        }

        public void Render()
        {
            SelectedSettingValue = SettingKey?.PossibleValues?[Math.Max(0, SelectedSettingValueNumber - 1)];
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) => SelectedSettingValueNumber = (int)e.NewValue;


        private static Random random = new Random();
    }
}
