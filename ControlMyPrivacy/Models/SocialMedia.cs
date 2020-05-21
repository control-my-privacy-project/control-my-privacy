using MaterialDesignThemes.Wpf;
using PostSharp.Patterns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMyPrivacy.Models
{
    [NotifyPropertyChanged]
    public class SocialMedia
    {
        public static readonly SocialMedia VK = new SocialMedia("VK", PackIconKind.Vk);
        public static readonly SocialMedia FaceBook = new SocialMedia("FaceBook", PackIconKind.Facebook);
        public static readonly SocialMedia Twitter = new SocialMedia("Twitter", PackIconKind.Twitter);

        public PackIconKind Icon { get; set; }
        public string Name { get; set; }
        public bool Available { get; set; }

        public SocialMedia(string name, PackIconKind icon, bool available = true)
        {
            Name = name;
            Icon = icon;
            Available = available;
        }
    }
}
