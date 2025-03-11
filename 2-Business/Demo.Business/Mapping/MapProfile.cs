using AutoMapper;
using Demo.DTO.Auth;
using Demo.Business.Helpers;
using Demo.Core.Utilities.Extensions;
using Demo.Entities.Models;
using Demo.DTO.Address;
using Demo.DTO.Messages;
using Demo.DTO.JWT;
using Demo.DTO.User;

namespace Demo.Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Auth
            CreateMap<LoginUser, LoginUser>().ForMember(x => x.Password, map => map.MapFrom(p => PasswordHelper.ComputeHash(p.Password)));
            CreateMap<JWTDto, CurrentJwt>().ForMember(x => x.CreatedDate, map => map.MapFrom(p => DateTime.UtcNow.GetDateTimeNow()));
            #endregion

            #region User
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<InsertTUserDto, User>()
                .ForMember(x => x.Id, map => map.MapFrom(p => Guid.NewGuid()))
                .ForMember(x => x.Password, map => map.MapFrom(p => PasswordHelper.ComputeHash(p.Password)))
                .ForMember(x => x.CreatedDate, map => map.MapFrom(p => DateTime.UtcNow.GetDateTimeNow()));

            CreateMap<User, TUserDto>();
            CreateMap<UserDetailDto, UserLoginResponseDto>()
                .ForMember(x => x.UserId, map => map.MapFrom(p => p.Id));

            CreateMap<InsertTUserDto, TUserDto>();
            #endregion

            

            #region Messages
            CreateMap<MessagesDto, Message>()
                .ForMember(x => x.Desc, map => map.MapFrom(p => p.Message)).ReverseMap();

            #endregion

            #region Address
            CreateMap<City, CityDto>();
            CreateMap<County, CountyDto>();
            CreateMap<Hometown, HometownDto>();
            #endregion

        }
    }
}
