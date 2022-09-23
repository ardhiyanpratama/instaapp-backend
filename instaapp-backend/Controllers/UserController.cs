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

namespace instaapp_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashids _hashids;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserController(IUnitOfWork unitOfWork, IMapper mapper, IHashids hashids, IPasswordHasher<User> passwordHasher, ILogger<UserController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _hashids = hashids;
            _passwordHasher = passwordHasher;
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
    }
}
