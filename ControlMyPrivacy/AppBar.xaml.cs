using PostSharp.Patterns.Xaml;
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

namespace ControlMyPrivacy
{
    /// <summary>
    /// Interaction logic for AppBar.xaml
    /// </summary>
    public partial class AppBar : UserControl
    {
        [DependencyProperty]
        public bool ReturnBackVisibility { get; set; } = false;

        public Window AttachedWindow => WindowAccess.DataContext is Window window ? window : null;

        public event EventHandler<RoutedEventArgs> ReturnBackClick;

        public AppBar() => InitializeComponent();

        private void Space_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!(e.ChangedButton == MouseButton.Left && e.LeftButton == MouseButtonState.Pressed)) return;
            AttachedWindow.DragMove();
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e) => AttachedWindow.WindowState = WindowState.Minimized;

        private void CloseButton_Click(object sender, RoutedEventArgs e) => AttachedWindow.Close();

        private void ReturnBackButton_Click(object sender, RoutedEventArgs e) => ReturnBackClick?.Invoke(this, e);
    }
}
