using ControlMyPrivacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMyPrivacy.ProfileSelectionScreen
{
    public class ProfileAddEventArgs : EventArgs
    {
        public SocialMedia SocialMedia { get; }

        public ProfileAddEventArgs(SocialMedia socialMedia) => SocialMedia = socialMedia;
    }
}
