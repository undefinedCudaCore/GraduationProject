using GraduationProject.Domain.Models;
using GraduationProject.Dto;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;
using GraduationProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    [Route("api/user_information")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0ad9ab6d-d7dd-4089-9b60-052e603889a7")]
    public class InformationController : ControllerBase
    {
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly IInformationService _informationService;
        private readonly ILogger<InformationController> _logger;

        public InformationController(IUserInformationRepository userRepository, IInformationService informationService, ILogger<InformationController> logger)
        {
            _userInformationRepository = userRepository;
            _informationService = informationService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Information>> GetInformationsAsync()
        {
            var userInformations = await _userInformationRepository.GetUserInformationsAsync();

            if (userInformations.Count < 5)
            {
                _logger.LogWarning("There are less than 5 users in teh database");
                _logger.LogInformation("Returning {0} users ", userInformations.Count);
            }

            return userInformations;
        }

        [HttpPost]
        public async Task CreateUserInformation([FromForm] CreateUserInformationDto request)
        {
            using FileStream stream = await _informationService.CreateInformationAsync(request);
        }

        [HttpGet("DownloadImage")]
        public async Task<IActionResult> DownloadUserAvatarAsync([FromQuery] Guid id)
        {
            var userInformation = await _userInformationRepository.GetUserInformationByIdAsync(id);

            if (userInformation == null)
            {
                return NotFound();
            }

            return File(userInformation.FileData, "image/jpeg", userInformation.FileName);
        }
    }
}
