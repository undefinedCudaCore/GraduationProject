using GraduationProject.Domain.Models;
using GraduationProject.Dto;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;
using GraduationProject.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GraduationProject.Controllers
{
    [Route("api/user_information")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0ad9ab6d-d7dd-4089-9b60-052e603889a7")]
    public class InformationController : ControllerBase
    {
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<InformationController> _logger;

        public InformationController(IUserInformationRepository userInformationRepository, IWebHostEnvironment environment, ILogger<InformationController> logger, IUserRepository userRepository)
        {
            _userInformationRepository = userInformationRepository;
            _environment = environment;
            _logger = logger;
            _userRepository = userRepository;
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
            var UserId = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault().Value;

            if (string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.FirstName) || string.IsNullOrEmpty(request.EmailAddress))
            {
                _logger.LogError("Username or email is missing");
            }
            var uploadFolderPath = Path.Combine(_environment.WebRootPath, "uploads");

            if (!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }

            var filePath = Path.Combine(uploadFolderPath, request.Image.FileName);

            using var stream = new FileStream(filePath, FileMode.Create);

            await request.Image.CopyToAsync(stream);

            var userInformation = new Information
            {
                InformationId = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                PersonalCode = request.PersonalCode,
                PhoneNumber = request.PhoneNumber,
                EmailAddress = request.EmailAddress,
                FileName = request.Image?.FileName,
                FileData = await FileUtils.ConvertToByteArray(request.Image),
                UserId = _userRepository.GetUserId(UserId),
            };

            var currUser = _userRepository.Get(UserId);
            if (currUser != null)
            {
                currUser.InformationId = userInformation.InformationId;
            }

            await _userInformationRepository.AddUserInformationAsync(userInformation);
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
