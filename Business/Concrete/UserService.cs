using AutoMapper;
using Business.Abstract;
using Core.ResponseResult;
using DataAccess.Abstract;
using DtoLayer.Dtos.UserDtos;
using Entities.Concrete;
using System.IO;


namespace Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public UserService(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }
        public async Task<IResponseResult<UserDto>> Add(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var userResponse = await _userDal.Add(user);
            return new ResponseResult<UserDto> (isSuccess:true, message: Messages.Messages.UserAddSuccess);
        }

        public async Task<IResponseResult<UserDto>> GetById(Guid id)
        {
            var user=await _userDal.Get(x=>x.Id==id);
            var userDto = _mapper.Map<UserDto>(user);
            return new ResponseResult<UserDto>(data: userDto);
        }

        public async Task<IResponseResult<List<UserDto>>> GetList()
        {
            var userListResponse = await _userDal.GetList();
            var userList = _mapper.Map<List<UserDto>>(userListResponse);
            return new ResponseResult<List<UserDto>>(data: userList);
        }

        public async Task<IResponseResult<UserDto>> Update(UserDto userDto)
        {
            var user = await _userDal.Get(x => x.Id == userDto.Id);
            if (user == null)
            {
                return new ResponseResult<UserDto>(message: Messages.Messages.UserNotFound, isSuccess:false);
            }
            string path = "wwwroot\\assets\\dist\\img\\"+user.Photo;
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            var userUpdate = _mapper.Map<UserDto,User>(userDto);
            var userResponse = await _userDal.Update(userUpdate);
            return new ResponseResult<UserDto>(isSuccess: true,message:Messages.Messages.UserUpdateSuccess);
        }
    }
}
