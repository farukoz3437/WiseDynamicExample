using AutoMapper;
using DtoLayer.Dtos.UserDtos;
using Entities.Concrete;

namespace WiseDynamic.UI.AutoMapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
