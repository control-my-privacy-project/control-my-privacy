namespace SocialMediaProvider.Providers.VK.Request
{
    public abstract class SettingData
    {
        public SettingAction Action { get; set; }

        public SettingData(SettingAction action) => Action = action;

        public abstract object ToQuery();
    }


    public class OptionSettingData : SettingData
    {
        public OptionSetting Setting { get; set; }
        public OptionSettingData(SettingAction action, OptionSetting settings) : base(action) => Setting = settings;

        public override object ToQuery() => new {
            key = Setting.Key.ToString(),
            val = Setting.Value.ToString()
        };
    }

    public class CloseProfileSettingData : SettingData
    {
        public bool Closed { get; set; }

        public CloseProfileSettingData(bool closed) : base(SettingAction.SaveCloseProfile) => Closed = closed;

        public override object ToQuery() => new {
            is_closed = Closed ? 1 : 0
        };
    }

    public class SettingAction
    {
        public readonly static SettingAction SavePrivacy = new SettingAction("save_privacy");
        public readonly static SettingAction SaveCloseProfile = new SettingAction("save_close_profile");

        public string Action { get; }
        public SettingAction(string action) => Action = action;
        public override string ToString() => Action;
    }
}
