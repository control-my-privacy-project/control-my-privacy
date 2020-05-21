using MaterialDesignThemes.Wpf;
using PostSharp.Patterns.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ControlMyPrivacy.Models
{
    [NotifyPropertyChanged]
    public class Profile
    {

        public ImageSource Avatar { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public SocialMedia SocialMedia { get; set; }

        public Profile(string name, string url, string avatar, SocialMedia socialMedia) : this(name, url, new BitmapImage(new Uri(avatar)), socialMedia)
        {
        }

        public Profile(string name, string url, ImageSource avatar, SocialMedia socialMedia)
        {
            Name = name;
            Url = url;
            Avatar = avatar;
            SocialMedia = socialMedia;
        }
    }
}
