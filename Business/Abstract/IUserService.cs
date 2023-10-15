using Core.ResponseResult;
using DtoLayer.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IResponseResult<UserDto>> GetById(Guid id);
        Task<IResponseResult<List<UserDto>>> GetList();
        Task<IResponseResult<UserDto>> Add(UserDto user);
        Task<IResponseResult<UserDto>> Update(UserDto user);
    }
}
