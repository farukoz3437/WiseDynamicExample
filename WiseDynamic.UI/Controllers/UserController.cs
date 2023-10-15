using Azure;
using Business.Abstract;
using Core.ResponseResult;
using DataAccess.Concrete;
using DtoLayer.Dtos.UserDtos;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;
using WiseDynamic.UI.HelperMethods;

namespace WiseDynamic.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _environment;
        private IValidator<UserDto> _validator;

        public UserController(IUserService userService, IWebHostEnvironment environment, IValidator<UserDto> validator)
        {
            _userService = userService;
            _environment = environment;
            _validator = validator;
        }
        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            List<UserDto> userList = _userService.GetList().Result.Data;

            return View(userList);
        }
        [HttpPost]
        [Route("User/AddUpdateUser")]
        public async Task<IActionResult> AddUpdateUser(UserDto userDto)
        {
            ValidationResult result = await _validator.ValidateAsync(userDto);
            if (!result.IsValid)
            {
                TempData["message"] = "Boş alanları giriniz" + "|" + false;
                return RedirectToAction("UserList");
            }

            userDto.Photo = ImageUpload.Upload(_environment.WebRootPath+"\\assets\\dist\\img", userDto.Photo); 


            if (userDto.Id == null)
            {
                IResponseResult<UserDto> response = await _userService.Add(userDto);

                TempData["message"] = response.Message + "|" + response.IsSuccess;

            }
            else
            {
                IResponseResult<UserDto> response = await _userService.Update(userDto);
                TempData["message"] = response.Message + "|" + response.IsSuccess;
            }


            return RedirectToAction("UserList");
        }
        [HttpGet]
        public async Task<JsonResult> GetById(Guid id)
        {
            UserDto user = _userService.GetById(id).Result.Data;

            return Json(user);
        }
    }
}
