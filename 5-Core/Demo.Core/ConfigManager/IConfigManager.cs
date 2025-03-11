namespace Demo.Core.ConfigManager
{
    public interface IConfigManager
    {
        public string SocketKey { get; }
        public string JwtKey { get; }
        public string JwtIssuer { get; }
        public string JwtAudience { get; }
        public int JwtDurationInMinutes { get; }
        public string SqlConnection { get; }
        public string Version { get; }
        public int CacheExpireDay { get; }
        public string RecaptchaSecretKey { get; }
        public string RecaptchaApi { get; }
        float ScoreForIsRequired { get; }
        float ScoreForIsNotRequired { get; }
        public string HubName { get; }
        public int MaxTryCountIsNotRequired { get; }
        public int SecondsDefinedToDelete { get; }
        public string ProfilePhotoFilePath { get; }
        public string MobilParkUsername { get; }
        public string MobilParkPassword { get; }
        public int FormId { get; }
        public int ListId { get; }
        public string SenderId { get; }
        public string OtpUsername { get; }
        public string OtpPassword { get; }
        public string EmailFrom { get; }
        public string EmailFromTitle { get; }
        public string EmailPassword { get; }
        public string EmailHost { get; }
        public int EmailPort { get; }
        public bool EmailUseSSL { get; }
    }
}
