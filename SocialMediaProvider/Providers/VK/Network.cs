using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

using Flurl;
using Flurl.Http;
using SocialMediaProvider.Providers.VK.Request;
using SocialMediaProvider.Providers.VK.Response;
using SocialMediaProvider.Utils;

namespace SocialMediaProvider.Providers.VK
{
    public class Network : IDisposable
    {
        private IFlurlClient Client { get; set; } = new FlurlClient(Constants.BaseAddress)
            .WithHeader("x-requested-with", "XMLHttpRequest")
            .WithTimeout(10);

        public string Hash { get; set; }
        public string RemixSid
        {
            get => Client.Cookies.GetValue(Constants.SessionCookie)?.Value;
            set => Client.WithCookie(Constants.SessionCookie, value);
        }

        public Network(string remixsid, string hash = null)
        {
            RemixSid = remixsid;
            Hash = hash;
        }

        private static readonly Regex RefreshHashRegex = new Regex(@"hash=([\d\w]+)");

        public async Task<string> RefreshHash(CancellationToken cancelationToken = default)
        {
            var resp = await Get(Constants.SettingsEndpoint, new { act = "privacy", privacy_edit = "profile" }, cancelationToken);
            var match = RefreshHashRegex.Match(resp.Html);
            if(match.Success && match.Groups.Count > 1)
            {
                var group = match.Groups[1];
                if(group.Success)
                {
                    Hash = group.Value;
                    return Hash;
                }
            }
            return null;
        }

        public async Task<NetworkResponse> Get(string endpont, object query, CancellationToken cancelationToken = default) =>
            await GenerateRequest(endpont, query).GetJsonAsync<NetworkResponse>(cancelationToken);

        public IFlurlRequest GenerateRequest(string endpont, object query)
        {
            var url = new Url(Client.BaseUrl);
            url.AppendPathSegment(endpont);

            if (query is SettingData settingData)
            {
                url.SetQueryParam(Constants.ActionParam, settingData.Action);
                url.SetQueryParams(settingData.ToQuery());
            }
            else
            {
                url.SetQueryParams(query);
            }

            if(Hash != null && Hash != string.Empty)
                url.SetQueryParam(Constants.HashParam, Hash);

            return url.WithClient(Client);
        }

        public void Dispose() => Client.Dispose();
    }
}
