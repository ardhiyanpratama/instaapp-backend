using AutoMapper;
using HashidsNet;
using instaapp_backend.Core.IConfiguration;
using instaapp_backend.Dto;
using instaapp_backend.Helper;
using instaapp_backend.Models;
using instaapp_backend.Services.JwtServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sodium;

namespace instaapp_backend.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PostingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHashids _hashids;
        private readonly IMapper _mapper;
        private readonly ILogger<PostingController> _logger;

        public PostingController(IUnitOfWork unitOfWork, IMapper mapper, IHashids hashids,ILogger<PostingController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _hashids = hashids;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostingWriteDto postingWriteDto)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequestResponse(ResponseMessageExtensions.Database.DATA_NOT_VALID);
            }

            var newPosting = _mapper.Map<Posting>(postingWriteDto);

            var isSuccess = await _unitOfWork.Posting.AddAsync(newPosting);
            if (!isSuccess)
            {
                return this.BadRequestResponse(ResponseMessageExtensions.SYSTEM_ERROR, errorcode: (long)ErrorCode.SystemError);
            }

            await _unitOfWork.CompleteAsync();

            var result = _mapper.Map<PostingReadDto>(newPosting);

            return this.OkResponse(ResponseMessageExtensions.Database.WRITE_SUCCESS, data: result);
        }

    }
}
