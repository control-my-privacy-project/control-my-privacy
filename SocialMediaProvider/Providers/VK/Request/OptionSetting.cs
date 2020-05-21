namespace SocialMediaProvider.Providers.VK.Request
{
    public class OptionSetting
    {
        public OptionSettingKey Key { get; }
        public OptionSettingValue Value { get; }

        public OptionSetting(OptionSettingKey key, OptionSettingValue value)
        {
            Key = key;
            Value = value;
        }

        public OptionSettingData ToChangeSettingData(SettingAction action) => new OptionSettingData(action, this);
    }

    public class OptionSettingKey
    {
        private readonly static OptionSettingValue[] DefaultValuesOnlyMe = new[] {
            OptionSettingValue.AllUsers,
            OptionSettingValue.FriendsOnly,
            OptionSettingValue.FriendsOfFriends,
            OptionSettingValue.OnlyMe,
            OptionSettingValue.CertainFriends
        };

        private readonly static OptionSettingValue[] DefaultValuesNobody = new[] {
            OptionSettingValue.AllUsers,
            OptionSettingValue.FriendsOnly,
            OptionSettingValue.FriendsOfFriends,
            OptionSettingValue.Nobody,
            OptionSettingValue.CertainFriends
        };

        private readonly static OptionSettingValue[] DefaultValuesApps = new[] {
            OptionSettingValue.AllFriends,
            OptionSettingValue.Nobody,
            OptionSettingValue.CertainFriends
        };

        public readonly static OptionSettingKey Profile = new OptionSettingKey("profile", DefaultValuesOnlyMe, "Who can view the main information on my profile");
        public readonly static OptionSettingKey PhotosWith = new OptionSettingKey("photos_with", DefaultValuesOnlyMe, "Who can view photos of me");
        public readonly static OptionSettingKey PhotosSaved = new OptionSettingKey("photos_saved", DefaultValuesOnlyMe, "Who can view the Saved photos album");
        public readonly static OptionSettingKey Groups = new OptionSettingKey("groups", DefaultValuesOnlyMe, "Who can view my list of groups");
        public readonly static OptionSettingKey Audios = new OptionSettingKey("audios", DefaultValuesOnlyMe, "Who can view my music");
        public readonly static OptionSettingKey Gifts = new OptionSettingKey("gifts", DefaultValuesOnlyMe, "Who can view my gifts");
        public readonly static OptionSettingKey Places = new OptionSettingKey("places", DefaultValuesOnlyMe, "Who can view my photos location");

        public readonly static OptionSettingKey Wall = new OptionSettingKey("wall", DefaultValuesOnlyMe, "Who can view other users' posts on my wall");
        public readonly static OptionSettingKey WallSend = new OptionSettingKey("wall_send", DefaultValuesOnlyMe, "Who can post to my wall");
        public readonly static OptionSettingKey RepliesView = new OptionSettingKey("replies_view", DefaultValuesOnlyMe, "Who can view comments on my posts");
        public readonly static OptionSettingKey StatusReplies = new OptionSettingKey("status_replies", DefaultValuesOnlyMe, "Who can comment on my posts");
        public readonly static OptionSettingKey PhotosTagMe = new OptionSettingKey("photos_tagme", DefaultValuesOnlyMe, "Who can tag me in photos");
        
        public readonly static OptionSettingKey MailSend = new OptionSettingKey("mail_send", DefaultValuesNobody, "Who can send me private messages");
        public readonly static OptionSettingKey Calls = new OptionSettingKey("calls", DefaultValuesNobody, "Who can call me");
        public readonly static OptionSettingKey AppsCall = new OptionSettingKey("appscall", DefaultValuesApps, "Who can invite me to open apps");
        public readonly static OptionSettingKey GroupsInvite = new OptionSettingKey("groups_invite", DefaultValuesNobody, "Who can invite me to communities");
        public readonly static OptionSettingKey AppsInvite = new OptionSettingKey("apps_invite", DefaultValuesApps, "Who can invite me to use apps");
        public readonly static OptionSettingKey FriendsRequests = new OptionSettingKey("friends_requests", new[] {
            OptionSettingValue.AllUsers,
            OptionSettingValue.FriendsOfFriends,
        }, "Which friend requests I am notified of");
        public readonly static OptionSettingKey ChatInviteUser = new OptionSettingKey("chat_invite_user", DefaultValuesOnlyMe, "Who can invite me to chats");
        public readonly static OptionSettingKey SearchByRegPhone = new OptionSettingKey("search_by_reg_phone", new[] {
            OptionSettingValue.AllUsers,
            OptionSettingValue.FriendsOfFriends,
            OptionSettingValue.Nobody
        }, "Who can find me by contacts import by phone number");

        public readonly static OptionSettingKey Stories = new OptionSettingKey("stories", DefaultValuesOnlyMe, "Who can view my stories");
        public readonly static OptionSettingKey StoriesReplies = new OptionSettingKey("stories_replies", DefaultValuesOnlyMe, "Who can reply to my stories");
        public readonly static OptionSettingKey StoriesQuestions = new OptionSettingKey("stories_questions", DefaultValuesOnlyMe, "Who can give feedback on my stories");

        public readonly static OptionSettingKey SearchAccess = new OptionSettingKey("search_access", new[] {
            OptionSettingValue.Everyone,
            OptionSettingValue.EveryoneExcludingSearcgEngines,
            OptionSettingValue.OnlyVKUsers
        }, "Who can see my profile on the internet");

        public readonly static OptionSettingKey[] DefaultKeys = new[] {
            Profile,
            PhotosWith,
            PhotosSaved,
            Groups,
            Audios,
            Gifts,
            Places,

            Wall,
            WallSend,
            RepliesView,
            StatusReplies,
            PhotosTagMe,

            MailSend,
            Calls,
            AppsCall,
            GroupsInvite,
            AppsInvite,
            FriendsRequests,
            ChatInviteUser,
            SearchByRegPhone,

            Stories,
            StoriesReplies,
            StoriesQuestions,

            SearchAccess
        };

        public string Key { get; }
        public string Description { get; }
        public OptionSettingValue[] PossibleValues { get; }

        public OptionSettingKey(string key, OptionSettingValue[] possibleValues, string description = default)
        {
            Key = key;
            Description = description;
            PossibleValues = possibleValues;
        }

        public OptionSetting ToSetting(OptionSettingValue value) => new OptionSetting(this, value);

        public override string ToString() => Key.ToString();
    }

    public class OptionSettingValue
    {
        public readonly static OptionSettingValue AllUsers = new OptionSettingValue(0, "All users");
        public readonly static OptionSettingValue AllFriends = new OptionSettingValue(0, "All friends");
        public readonly static OptionSettingValue Everyone = new OptionSettingValue(0, "Everyone");
        public readonly static OptionSettingValue FriendsOnly = new OptionSettingValue(1, "Friends only");
        public readonly static OptionSettingValue EveryoneExcludingSearcgEngines = new OptionSettingValue(1, "Everyone, excluding search engines");
        public readonly static OptionSettingValue FriendsOfFriends = new OptionSettingValue(2, "Friends of friends");
        public readonly static OptionSettingValue OnlyMe = new OptionSettingValue(3, "Only me");
        public readonly static OptionSettingValue Nobody = new OptionSettingValue(3, "Nobody");
        public readonly static OptionSettingValue OnlyVKUsers = new OptionSettingValue(3, "Only VK users");
        public readonly static OptionSettingValue CertainFriends = new OptionSettingValue(4, "Certain friends");

        public int Value { get; }
        public string Description { get; }
        public OptionSettingValue(int value, string description = default)
        {
            Value = value;
            Description = description;
        }

        public override string ToString() => Value.ToString();
    }
}
