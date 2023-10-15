using DtoLayer.Dtos.UserDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.UserValidationRules
{
    public class UserAddValidator: AbstractValidator<UserDto>
    {
        public UserAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Cinsiyet boş geçilemez");
            string jpg = "image/jpg"; string jpeg = "jpeg"; string png = "image/png";
            RuleFor(x => x.Photo).Must(x => x.Contains(jpg)|| x.Contains(jpeg)|| x.Contains(png)).WithMessage("Fotoğraf yükleyiniz");
        }
    }
}
