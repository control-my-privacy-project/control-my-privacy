using ControlMyPrivacy.Models;
using MaterialDesignThemes.Wpf;
using PostSharp.Patterns.Xaml;
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
    /// Interaction logic for ProfileSelectionScreen.xaml
    /// </summary>
    public partial class ProfileSelectionScreen : UserControl
    {
        public event EventHandler<ProfileAddEventArgs> ProfileAdd;

        public event EventHandler<ProfileSelectedEventArgs> ProfileSelected;

        [DependencyProperty]
        public string RealName { get; set; }
        [DependencyProperty]
        public ObservableCollection<Profile> Profiles { get; set; }

        public ProfileSelectionScreen() => InitializeComponent();

        private void ProfileCard_Click(object sender, ProfileSelectedEventArgs e) => ProfileSelected?.Invoke(this, e);

        private void ProfileAddButton_Click(object sender, ProfileAddEventArgs e) => ProfileAdd?.Invoke(this, e);
    }
}
