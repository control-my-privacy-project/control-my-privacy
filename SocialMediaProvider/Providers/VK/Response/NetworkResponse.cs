using Newtonsoft.Json;

namespace SocialMediaProvider.Providers.VK.Response
{
    public class NetworkResponse
    {
        public NetwordResponseType Type { get; set; }

        // Arguments
        public dynamic LmData { get; set; } // +Page, { lm, counters }
        public dynamic Data { get; set; } // +Confirm, [{"error":false,"result":1}], [{"error": true,"code": 11,"message": "You have tried to open several similar pages too fast. Please go back and try again."}],

        // Redirect
        public string Location { get; set; } // +Captcha, +FailedAuth
        public bool? Hard { get; set; } // bool ??, hard && hard_go(Location)
        public bool? Frame { get; set; } // bool ??, !frame && window.isNewMail && onBeforeRedirect(Location), iframe...
        public bool? Clear { get; set; } // bool ??, clear && l.clear()
        public bool? Restore { get; set; } // need_restore

        // Captcha
        public string Img { get; set; }
        public ResponseCaptchaPost Post { get; set; }
        public string Key { get; set; }

        // Page
        public string Title { get; set; }
        public string Html { get; set; }
        public string Js { get; set; }
        public string BodyClass { get; set; }
        public string TopBar { get; set; }
        public dynamic Env { get; set; } // { pe: { dynamic } }
        public dynamic StaticFiles { get; set; }

        // All ??
        public dynamic _snackbar { get; set; }
        public dynamic Snackbar { get; set; }

        [JsonConverter(typeof(ResponseCountersConverter))]
        public int[] Counters { get; set; } // Counters[3] - messages, bool || int[]
        public string Version { get; set; } // vk cache version
    }

    public class ResponseCaptchaPost
    {
        public string CaptchaSid { get; set; }
        public string RandomId { get; set; }
        public string Entrypoint { get; set; }
        public string Message { get; set; }
        public string _ajax { get; set; }
    }

    public enum NetwordResponseType
    {
        Arguments,
        Redirect,
        Captcha,
        Page,
        FailedAuth,
        Confirm
    }
}
