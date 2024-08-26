using GraduationProject.Controllers;
using GraduationProject.Domain.Models;
using GraduationProject.Dto;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;
using GraduationProject.Services.Interfaces;

namespace GraduationProject.Services
{
    public class ResidenceService : IResidenceService
    {
        private readonly IUserResidenceRepository _userResidenceRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<InformationController> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly IUserInformationRepository _userInformationRepository;

        public ResidenceService(IUserResidenceRepository userResidenceRepository, ILogger<InformationController> logger, IWebHostEnvironment environment, IUserRepository userRepository, IUserInformationRepository userInformationRepository)
        {
            _userResidenceRepository = userResidenceRepository;
            _logger = logger;
            _environment = environment;
            _userRepository = userRepository;
            _userInformationRepository = userInformationRepository;
        }
        public async Task<IEnumerable<Residence>> GetAllResidencesAsync()
        {
            var userResidence = await _userResidenceRepository.GetUserResidencesAsync();

            if (userResidence.Count < 2)
            {
                _logger.LogWarning("There are no user residence information in database");
                _logger.LogInformation("Returning {0} users ", userResidence.Count);
            }

            return userResidence;
        }

        public async Task<Residence?> GetResidenceByInfoIdAsync(Guid id)
        {
            return await _userResidenceRepository.GetUserResidenceByInformationIdAsync(id);
        }

        public async Task AddUserResidenceAsync(CreateUserResidenceDto request, string user)
        {
            if (string.IsNullOrEmpty(request.City)
                || string.IsNullOrEmpty(request.Street)
                || string.IsNullOrEmpty(request.HouseNumber)
                || string.IsNullOrEmpty(request.ApartmentNumber))
            {
                _logger.LogError("Some user input information is missing");
                return;
            }

            var userResidence = new Residence
            {
                ResidenceId = Guid.NewGuid(),
                City = request.City.Trim(),
                Street = request.Street.Trim(),
                HouseNumber = request.HouseNumber.Trim(),
                ApartmentNumber = request.ApartmentNumber.Trim(),
                //UserId = _userRepository.GetUserId(UserId),
            };

            var currUser = _userRepository.Get(user);
            var currUserInformation = _userInformationRepository.Get(currUser.InformationId);

            if (currUserInformation != null)
            {
                userResidence.InformationId = currUserInformation.InformationId;
            }

            await _userResidenceRepository.AddUserResidenceAsync(userResidence);
        }

        public async Task UpdateUserCityAsync(Guid informationId, string street)
        {
            var userResidence = GetResidenceByInfoIdAsync(informationId).Result;
            if (userResidence != null)
            {
                userResidence.City = street;
            }

            await _userResidenceRepository.UpdateAsync(userResidence);
        }

        public async Task UpdateUserStreetAsync(Guid informationId, string street)
        {
            var userResidence = GetResidenceByInfoIdAsync(informationId).Result;
            if (userResidence != null)
            {
                userResidence.Street = street;
            }

            await _userResidenceRepository.UpdateAsync(userResidence);
        }

        public async Task UpdateUserHouseNumberAsync(Guid informationId, string houseNumber)
        {
            var userResidence = GetResidenceByInfoIdAsync(informationId).Result;
            if (userResidence != null)
            {
                userResidence.HouseNumber = houseNumber;
            }

            await _userResidenceRepository.UpdateAsync(userResidence);
        }

        public async Task UpdateUseApartmentNumberAsync(Guid informationId, string apartmentNumber)
        {
            var userResidence = GetResidenceByInfoIdAsync(informationId).Result;
            if (userResidence != null)
            {
                userResidence.ApartmentNumber = apartmentNumber;
            }

            await _userResidenceRepository.UpdateAsync(userResidence);
        }
    }
}
