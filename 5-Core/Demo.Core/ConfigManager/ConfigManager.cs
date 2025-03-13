using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace Demo.Core.ConfigManager
{
    public class ConfigManager : IConfigManager
    {
        private readonly IConfiguration _configuration;

        public ConfigManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string HubName => _configuration["HubName"]!;
        public string SocketKey => _configuration["JWT:SocketKey"]!;
        public string JwtKey => _configuration["JWT:key"]!;
        public string JwtIssuer => _configuration["JWT:Issuer"]!;
        public string JwtAudience => _configuration["JWT:Audience"]!;
        public int JwtDurationInMinutes => int.Parse(_configuration["JWT:DurationInMinutes"]!.ToString());
        public string SqlConnection => _configuration["ConnectionStrings:SqlConnection"]!;
        public string Version => _configuration["Version"]!;
        public string RecaptchaSecretKey => _configuration["RecaptchaSettings:RecaptchaSecretKey"]!;
        public string RecaptchaApi => _configuration["RecaptchaSettings:RecaptchaApi"]!;
        public float ScoreForIsRequired
        {
            get
            {
                return float.Parse(_configuration["RecaptchaSettings:ScoreForIsRequired"]!, new CultureInfo("en-us"));
            }
        }
        public float ScoreForIsNotRequired
        {
            get
            {
                return float.Parse(_configuration["RecaptchaSettings:ScoreForIsNotRequired"]!, new CultureInfo("en-us"));
            }
        }
        public int MaxTryCountIsNotRequired
        {
            get
            {
                return int.Parse(_configuration["ScreenActionSettings:MaxTryCountIsNotRequired"]!);
            }
        }
        public int SecondsDefinedToDelete
        {
            get
            {
                return int.Parse(_configuration["ScreenActionSettings:SecondsDefinedToDelete"]!);
            }
        }


        public int CacheExpireDay
        {
            get
            {
                return int.Parse(_configuration["CacheExpireDay"]!);
            }
        }

        public string ProfilePhotoFilePath => _configuration["Paths:ProfilePhotoFilePath"]!;
        public string MeetingFilePath => _configuration["Paths:MeetingFilePath"]!;

        public string MobilParkUsername => _configuration["MobilParkInfo:Username"];

        public string MobilParkPassword => _configuration["MobilParkInfo:Password"];

        public int FormId => int.Parse(_configuration["MobilParkInfo:FormId"]);

        public int ListId => int.Parse(_configuration["MobilParkInfo:ListId"]);

        public string SenderId => _configuration["MobilParkInfo:SenderId"];

        public string OtpUsername => _configuration["MobilParkInfo:OtpUsername"];

        public string OtpPassword => _configuration["MobilParkInfo:OtpPassword"];
        public string EmailFrom => _configuration["Email:From"]!;
        public string EmailFromTitle => _configuration["Email:FromTitle"]!;
        public string EmailPassword => _configuration["Email:Password"]!;
        public string EmailHost => _configuration["Email:Host"]!;
        public bool EmailUseSSL => bool.Parse(_configuration["Email:UseSSL"]!);
        public int EmailPort => int.Parse(_configuration["Email:Port"]!);
    }
}
