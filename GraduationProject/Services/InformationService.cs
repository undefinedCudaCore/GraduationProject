using GraduationProject.Controllers;
using GraduationProject.Domain.Models;
using GraduationProject.Dto;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;
using GraduationProject.Services.Interfaces;

namespace GraduationProject.Services
{
    public class InformationService : IInformationService
    {
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<InformationController> _logger;
        private readonly IImageEditionService _imageEditionService;

        public InformationService(IUserInformationRepository userInformationRepository, IWebHostEnvironment environment, ILogger<InformationController> logger, IUserRepository userRepository, IImageEditionService imageEditionService)
        {
            _userInformationRepository = userInformationRepository;
            _environment = environment;
            _logger = logger;
            _userRepository = userRepository;
            _imageEditionService = imageEditionService;
        }

        public async Task<IEnumerable<Information>> GetAllInformationsAsync()
        {
            try
            {
                var userInformations = await _userInformationRepository.GetUserInformationsAsync();

                if (userInformations.Count < 1)
                {
                    _logger.LogWarning("There are no users in database");
                    _logger.LogInformation("Returning {0} users ", userInformations.Count);
                }

                return userInformations;
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task AddUserInformationAsync(CreateUserInformationDto request, string user)
        {
            try
            {
                var uploadFolderPath = Path.Combine(_environment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                UserImageDto img = new UserImageDto { Image = request.Image };
                var imageBytes = await _imageEditionService.ResizeImageAsync(img);

                var userInformation = new Information
                {
                    InformationId = Guid.NewGuid(),
                    FirstName = request.FirstName.Trim(),
                    LastName = request.LastName.Trim(),
                    PersonalCode = request.PersonalCode,
                    PhoneNumber = request.PhoneNumber.Trim(),
                    EmailAddress = request.EmailAddress.Trim(),
                    FileName = request.Image?.FileName,
                    FileData = imageBytes,
                    UserId = _userRepository.GetUserId(user),
                };

                var currUser = _userRepository.Get(user);
                if (currUser != null)
                {
                    currUser.InformationId = userInformation.InformationId;
                }

                await _userInformationRepository.AddUserInformationAsync(userInformation);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task<Information?> GetOneUserInformationByUserIdAsync(Guid id)
        {
            try
            {
                return await _userInformationRepository.GetUserInformationByUserIdAsync(id);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }
        public async Task UpdateUserFirstNameAsync(Guid userId, string firstName)
        {
            try
            {
                var userInformation = GetOneUserInformationByUserIdAsync(userId).Result;
                if (userInformation != null)
                {
                    userInformation.FirstName = firstName;
                }

                await _userInformationRepository.UpdateAsync(userInformation);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task UpdateUserLastNameAsync(Guid userId, string lastName)
        {
            try
            {
                var userInformation = GetOneUserInformationByUserIdAsync(userId).Result;
                if (userInformation != null)
                {
                    userInformation.LastName = lastName;
                }

                await _userInformationRepository.UpdateAsync(userInformation);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task UpdateUserPersonalCodeAsync(Guid userId, long personalCode)
        {
            try
            {
                var userInformation = GetOneUserInformationByUserIdAsync(userId).Result;
                if (userInformation != null)
                {
                    userInformation.PersonalCode = personalCode;
                }

                await _userInformationRepository.UpdateAsync(userInformation);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task UpdateUserPhoneNumberAsync(Guid userId, string phoneNumber)
        {
            try
            {
                var userInformation = GetOneUserInformationByUserIdAsync(userId).Result;
                if (userInformation != null)
                {
                    userInformation.PhoneNumber = phoneNumber;
                }

                await _userInformationRepository.UpdateAsync(userInformation);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task UpdateUserEmailAddressAsync(Guid userId, string emailAddress)
        {
            try
            {
                var userInformation = GetOneUserInformationByUserIdAsync(userId).Result;
                if (userInformation != null)
                {
                    userInformation.EmailAddress = emailAddress;
                }

                await _userInformationRepository.UpdateAsync(userInformation);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task UpdateUserImageAsync(Guid userId, UserImageDto image)
        {
            try
            {
                var uploadFolderPath = Path.Combine(_environment.WebRootPath, "uploads");

                if (!Directory.Exists(uploadFolderPath))
                {
                    Directory.CreateDirectory(uploadFolderPath);
                }

                var imageBytes = await _imageEditionService.ResizeImageAsync(image);

                var userInformation = GetOneUserInformationByUserIdAsync(userId).Result;


                if (userInformation != null)
                {
                    string updatedFile = "updated_avatar.jpg";

                    userInformation.FileName = updatedFile;
                    userInformation.FileData = imageBytes;
                }

                await _userInformationRepository.UpdateAsync(userInformation);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }
    }
}
