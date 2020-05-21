using SocialMediaProvider.Providers.VK.Response;
using System.Threading;
using System.Threading.Tasks;
using SocialMediaProvider.Providers.VK.Request;

namespace SocialMediaProvider.Providers.VK
{
    public class API
    {
        public Network Network { get; set; }

        public API(Network network) => Network = network;
        public API(string remixsid, string hash = null) : this(new Network(remixsid, hash)) { }

        public async Task<NetworkResponse> ChangeCloseProfile(bool closed, CancellationToken cancelationToken = default) =>
            await ChangeSettings(new CloseProfileSettingData(closed), cancelationToken);

        public async Task<NetworkResponse> ChangePrivacy(OptionSettingKey key, OptionSettingValue value, CancellationToken cancelationToken = default) =>
            await ChangePrivacy(key.ToSetting(value), cancelationToken);
        public async Task<NetworkResponse> ChangePrivacy(OptionSetting setting, CancellationToken cancelationToken = default) =>
            await ChangeSettings(setting.ToChangeSettingData(SettingAction.SavePrivacy), cancelationToken);

        public async Task<NetworkResponse> ChangeSettings(SettingData data, CancellationToken cancelationToken = default) => 
            await Network.Get(Constants.SettingsEndpoint, data, cancelationToken);
    }
}
