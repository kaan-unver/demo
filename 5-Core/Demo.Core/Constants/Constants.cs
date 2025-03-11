using System.Globalization;

namespace Demo.Core.Constants
{
    public class Constants
    {

        #region HttpStatusCodes
        public const int BadRequest = 400;
        public const int NotFound = 404;
        public const int Ok = 200;
        public const int InternalServer = 500;
        public const int UnAuthorized = 401;
        public const int UnAuthorizedForEndpoint = 405;
        public const int CaptchaUnVerified = 400;
        public const int MethodNotAllowed = 405;
        public const int UnsupportedMediaType = 415;
        public const int NotImplemented = 501;
        #endregion

        public const string DefaultLangu = "TR";
        public static readonly CultureInfo TR_Culture = new CultureInfo("tr-TR");

        public const string LoginEndpoint = "/api/Auth/login";
        public const string TokenJW = "JWT";
        public const string TokenAnonymous = "ANO";

        public class RequestLog
        {
            public class UserType
            {
                //public const string SERVICE_USER = "SERVICE_USER";
                public const string USER = "USER";
                public const string NOT_EXIST = "NOT_EXIST";
            }
        }

        public const string TC = "TUR";
        public const string JPG = ".jpg";
        public const string ContentTypeJpg = "image/jpeg";
        public const string ContetntTypePdf = "application/pdf";
        public const string PDF = ".pdf";
        public const int MarginOfDelay = 2;
        public const int SuccessCode = 0;
        public const int MarginOfDelayOfDeliverable = 10;

    }
}
