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
        public async Task UpdateUserFirstNameAsync(Guid userId, string firstName, string user)
        {
            try
            {
                var userInformation = GetOneUserInformationByUserIdAsync(userId).Result;

                var currUser = _userRepository.Get(user);
                if (userId == currUser.UserId)
                {
                    if (userInformation != null)
                    {
                        userInformation.FirstName = firstName;
                    }
                }
                else
                {
                    return;
                }

                await _userInformationRepository.UpdateAsync(userInformation);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task UpdateUserLastNameAsync(Guid userId, string lastName, string user)
        {
            try
            {
                var userInformation = GetOneUserInformationByUserIdAsync(userId).Result;

                var currUser = _userRepository.Get(user);
                if (userId == currUser.UserId)
                {
                    if (userInformation != null)
                    {
                        userInformation.LastName = lastName;
                    }
                }
                else
                {
                    return;
                }

                await _userInformationRepository.UpdateAsync(userInformation);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task UpdateUserPersonalCodeAsync(Guid userId, long personalCode, string user)
        {
            try
            {
                var userInformation = GetOneUserInformationByUserIdAsync(userId).Result;

                var currUser = _userRepository.Get(user);
                if (userId == currUser.UserId)
                {
                    if (userInformation != null)
                    {
                        userInformation.PersonalCode = personalCode;
                    }
                }
                else
                {
                    return;
                }

                await _userInformationRepository.UpdateAsync(userInformation);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task UpdateUserPhoneNumberAsync(Guid userId, string phoneNumber, string user)
        {
            try
            {
                var userInformation = GetOneUserInformationByUserIdAsync(userId).Result;

                var currUser = _userRepository.Get(user);
                if (userId == currUser.UserId)
                {
                    if (userInformation != null)
                    {
                        userInformation.PhoneNumber = phoneNumber;
                    }
                }
                else
                {
                    return;
                }

                await _userInformationRepository.UpdateAsync(userInformation);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task UpdateUserEmailAddressAsync(Guid userId, string emailAddress, string user)
        {
            try
            {
                var userInformation = GetOneUserInformationByUserIdAsync(userId).Result;

                var currUser = _userRepository.Get(user);
                if (userId == currUser.UserId)
                {
                    if (userInformation != null)
                    {
                        userInformation.EmailAddress = emailAddress;
                    }
                }
                else
                {
                    return;
                }

                await _userInformationRepository.UpdateAsync(userInformation);
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(ex.Message);
            }
        }

        public async Task UpdateUserImageAsync(Guid userId, UserImageDto image, string user)
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

                var currUser = _userRepository.Get(user);
                if (userId == currUser.UserId)
                {
                    if (userInformation != null)
                    {
                        string updatedFile = "updated_avatar.jpg";

                        userInformation.FileName = updatedFile;
                        userInformation.FileData = imageBytes;
                    }
                }
                else
                {
                    return;
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
