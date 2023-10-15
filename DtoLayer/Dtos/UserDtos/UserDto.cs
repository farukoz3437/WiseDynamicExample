using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.UserDtos
{
    public class UserDetailDto
    {
        public UserDto User { get; set; }
        public List<UserDto> UserList { get; set; }
    }
    public class UserDto
    {
        public Guid? Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }
        public int? Gender { get; set; }
    }
}
