using SocialMediaProvider.Providers.VK.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ControlMyPrivacy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
       

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AppBar_ReturnBackClick(object sender, RoutedEventArgs e) => ScreenController.ReturnBack();
    }
}
