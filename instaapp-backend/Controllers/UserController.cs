using AutoMapper;
using HashidsNet;
using instaapp_backend.Core.IConfiguration;
using instaapp_backend.Data;
using instaapp_backend.Helper.Identity;
using instaapp_backend.Helper;
using instaapp_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using instaapp_backend.Dto;
using Microsoft.AspNetCore.Authorization;
using instaapp_backend.Helper.Exceptions;
using instaapp_backend.Services.JwtServices;

namespace instaapp_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashids _hashids;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IJwtServices _jwtServices;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper, IHashids hashids, IPasswordHasher<User> passwordHasher, ILogger<UserController> logger, IJwtServices jwtServices)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _hashids = hashids;
            _passwordHasher = passwordHasher;
            _jwtServices = jwtServices;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserWriteDto userWriteDto)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequestResponse(ResponseMessageExtensions.Database.DATA_NOT_VALID);
            }

            var newUser = _mapper.Map<User>(userWriteDto);

            var isSuccess = await _unitOfWork.Users.AddAsync(newUser);
            if (!isSuccess)
            {
                return this.BadRequestResponse(ResponseMessageExtensions.SYSTEM_ERROR, errorcode: (long)ErrorCode.SystemError);
            }

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<UserReadDto>(newUser);

            return this.OkResponse(ResponseMessageExtensions.Database.WRITE_SUCCESS, data: result);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequestResponse(ResponseMessageExtensions.Database.DATA_NOT_VALID);
            }

            var userLogged = await _unitOfWork.Users.AuthenticateAsync(userDto.UserName, userDto.Password);
            if (userLogged is null)
            {
                throw new AppException("Username Atau Password Salah");
            }

            var token = _jwtServices.GenerateJwtToken(userLogged, HttpContext);

            var responseToken = new AuthenDto
            {
                Id = _hashids.EncodeLong(userLogged.Id),
                access_token = token,
                token_type = "Bearer",
                ispost = userLogged.Ispost,
                iscomment = userLogged.Iscomment,
                islike = userLogged.Islike,
                name = userLogged.Fullname,
                token = userLogged.Uuid
            };

            return Ok(responseToken);
        }

    }
}
