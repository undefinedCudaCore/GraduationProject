using GraduationProject.Controllers;
using GraduationProject.Domain.Models;
using GraduationProject.Dto;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;
using GraduationProject.Services.Interfaces;
using GraduationProject.Utilities;

namespace GraduationProject.Services
{
    public class InformationService : IInformationService
    {
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<InformationController> _logger;

        public InformationService(IUserInformationRepository userInformationRepository, IWebHostEnvironment environment, ILogger<InformationController> logger, IUserRepository userRepository)
        {
            _userInformationRepository = userInformationRepository;
            _environment = environment;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<Information>> GetAllInformationsAsync()
        {
            var userInformations = await _userInformationRepository.GetUserInformationsAsync();

            if (userInformations.Count < 1)
            {
                _logger.LogWarning("There are no users in database");
                _logger.LogInformation("Returning {0} users ", userInformations.Count);
            }

            return userInformations;
        }

        public async Task<FileStream> AddUserInformationAsync(CreateUserInformationDto request, string user)
        {
            var uploadFolderPath = Path.Combine(_environment.WebRootPath, "uploads");

            if (!Directory.Exists(uploadFolderPath))
            {
                Directory.CreateDirectory(uploadFolderPath);
            }

            var filePath = Path.Combine(uploadFolderPath, request.Image.FileName);
            var stream = new FileStream(filePath, FileMode.Create);

            await request.Image.CopyToAsync(stream);

            var userInformation = new Information
            {
                InformationId = Guid.NewGuid(),
                FirstName = request.FirstName.Trim(),
                LastName = request.LastName.Trim(),
                PersonalCode = request.PersonalCode,
                PhoneNumber = request.PhoneNumber.Trim(),
                EmailAddress = request.EmailAddress.Trim(),
                FileName = request.Image?.FileName,
                FileData = await FileUtils.ConvertToByteArray(request.Image),
                UserId = _userRepository.GetUserId(user),
            };

            var currUser = _userRepository.Get(user);
            if (currUser != null)
            {
                currUser.InformationId = userInformation.InformationId;
            }

            await _userInformationRepository.AddUserInformationAsync(userInformation);
            return stream;
        }

        public async Task<Information?> GetOneUserInformationByUserIdAsync(Guid id)
        {
            return await _userInformationRepository.GetUserInformationByUserIdAsync(id);
        }
    }
}
