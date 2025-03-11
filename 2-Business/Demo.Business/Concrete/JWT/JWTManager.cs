using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Demo.Business.Abstract.JWT;
using Demo.Business.Abstract.Messages;
using Demo.Business.Helper;
using Demo.Core.ConfigManager;
using Demo.Core.Constants;
using Demo.Core.Utilities.Extensions;
using Demo.Core.Utilities.Results;
using Demo.Infrastructure.Abstract.JWT;
using Demo.DTO.JWT;

namespace Demo.Business.Concrete.JWT
{
    internal class JWTManager : ContextHelper, IJWTManager
    {

        private readonly IMapper _mapper;
        private readonly IConfigManager _config;
        private readonly IMessageManager _messageManager;
        private readonly IJWTRepository _jwtRepository;
        public JWTManager(IHttpContextAccessor httpContextAccessor, IMapper mapper, IConfigManager config, IMessageManager messageManager, IJWTRepository jwtRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _config = config;
            _messageManager = messageManager;
            _jwtRepository = jwtRepository;
        }

        public IDataResult<string> GetToken(Guid userId)
        {
            var token = GenerateJwtToken(userId);
            if (!string.IsNullOrWhiteSpace(token))
            {
                if (Add(token, userId))
                    return new SuccessDataResult<string>(token, Constants.Ok);
            }
            return new ErrorDataResult<string>(Constants.InternalServer, (ModuleMessageCodes.Jwt + MethodMessagesCodes.GetToken).ToString(), TransactionId, MessageCodes.TokenCreationFail);
        }
        public IDataResult<Guid> GetUserGuidFromValidatedToken(string token)
        {
            var messageCode = (ModuleMessageCodes.Jwt + MethodMessagesCodes.GetToken).ToString();
            if (string.IsNullOrWhiteSpace(token) || token.Equals("Bearer null"))
                return new ErrorDataResult<Guid>(Constants.UnAuthorized, messageCode, TransactionId, MessageCodes.TokenIsRequired);

            if (!IsSchemeValid(token))
                return new ErrorDataResult<Guid>(Constants.UnAuthorized, messageCode, TransactionId, MessageCodes.BearerIsRequired);
           
            token = token.Replace("Bearer", "").Trim();
            if (!TokenExpireIsValid(token))
                return new ErrorDataResult<Guid>(Constants.UnAuthorized, messageCode, TransactionId, MessageCodes.TokenTimeout);

            var jwtToken = GetToken(token);
            if (jwtToken == null)
                return new ErrorDataResult<Guid>(Constants.UnAuthorized, messageCode, TransactionId, MessageCodes.InvalidToken);

            var userGuid = Guid.Parse(jwtToken.Claims.First(x => x.Type == "UserGuid").Value);
            var isTheSame = _jwtRepository.CheckTokenIsTheSame(token, userGuid);
            if (!isTheSame)
                return new ErrorDataResult<Guid>(Constants.UnAuthorized, messageCode, TransactionId, MessageCodes.TokenDoesNotMatch);

            return new SuccessDataResult<Guid>(userGuid, Constants.Ok);
        }

        #region "Private Methods"
        private string GenerateJwtToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            List<Claim> claims = new()
                {
                    new Claim("UserGuid",userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var subject = new ClaimsIdentity(claims.ToArray());

            var key = Encoding.ASCII.GetBytes(_config.JwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Issuer = _config.JwtIssuer,
                Audience = _config.JwtAudience,
                Expires = DateTime.UtcNow.GetDateTimeNow().AddMinutes(_config.JwtDurationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
        private JwtSecurityToken GetToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config.JwtKey);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _config.JwtIssuer,
                    ValidateAudience = true,
                    ValidAudience = _config.JwtAudience
                }, out SecurityToken validatedToken);

                return (JwtSecurityToken)validatedToken;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        private static bool IsSchemeValid(string scheme)
        {
            return scheme.StartsWith("Bearer ");
        }
        private static long GetTokenExpirationTime(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var tokenExp = jwtSecurityToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
            var ticks = long.Parse(tokenExp);
            return ticks;
        }
        private static bool TokenExpireIsValid(string token)
        {
            var tokenTicks = GetTokenExpirationTime(token);
            var tokenDate = DateTimeOffset.FromUnixTimeSeconds(tokenTicks).UtcDateTime;
            var now = DateTime.UtcNow.GetDateTimeNow().ToUniversalTime();
            var valid = tokenDate >= now;
            return valid;
        }
        private bool Add(string token, Guid userId)
        {
            var dto = new JWTDto { Token = token, UserId = userId };
            var data = _mapper.Map<JWTDto, Entities.Models.CurrentJwt>(dto, opt => opt.AfterMap((src, dest) => dest.CreatedBy = userId));

            var currentJwt = _jwtRepository.GetCurrentTokenByUser(data.UserId);
            if (currentJwt == null)
                return _jwtRepository.Add(data);
            else
                return _jwtRepository.AddJwtIfExist(data, currentJwt);
        }
        #endregion

    }
}
