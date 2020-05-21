using ControlMyPrivacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlMyPrivacy.ProfileSelectionScreen
{
    public class ProfileSelectedEventArgs : EventArgs
    {
        public Profile Profile { get; set; }
        public ProfileSelectedEventArgs(Profile profile)
        {
            Profile = profile;
        }
    }
}
