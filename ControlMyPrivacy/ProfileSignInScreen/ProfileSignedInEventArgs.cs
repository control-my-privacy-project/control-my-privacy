using ControlMyPrivacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMyPrivacy.ProfileSignInScreen
{
    public class ProfileSignedInEventArgs : EventArgs
    {
        public SocialMedia SocialMedia { get; }

        public dynamic Parameters { get; }

        public ProfileSignedInEventArgs(SocialMedia socialMedia, dynamic parameters)
        {
            SocialMedia = socialMedia;
            Parameters = parameters;
        }
    }
}
