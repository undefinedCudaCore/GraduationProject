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
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<InformationController> _logger;

        public InformationService(IUserInformationRepository userRepository, IWebHostEnvironment environment, ILogger<InformationController> logger)
        {
            _userInformationRepository = userRepository;
            _environment = environment;
            _logger = logger;
        }
        public async Task<FileStream> CreateInformationAsync(CreateUserInformationDto request)
        {
            if (string.IsNullOrEmpty(request.FirstName)
                || string.IsNullOrEmpty(request.LastName)
                || string.IsNullOrEmpty(request.PhoneNumber)
                || string.IsNullOrEmpty(request.EmailAddress))
            {
                _logger.LogError("Username or smth is missing");
            }
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
                FirstName = request.FirstName,
                LastName = request.LastName,
                PersonalCode = request.PersonalCode,
                PhoneNumber = request.PhoneNumber,
                EmailAddress = request.EmailAddress,
                FileName = request.Image?.FileName,
                FileData = await FileUtils.ConvertToByteArray(request.Image),
            };

            await _userInformationRepository.AddUserInformationAsync(userInformation);
            return stream;
        }
    }
}
