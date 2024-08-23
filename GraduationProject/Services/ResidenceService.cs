using GraduationProject.Controllers;
using GraduationProject.Domain.Models;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;
using GraduationProject.Services.Interfaces;

namespace GraduationProject.Services
{
    public class ResidenceService : IResidenceService
    {
        private readonly IUserResidenceRepository _userResidenceRepository;
        private readonly ILogger<InformationController> _logger;

        public ResidenceService(IUserResidenceRepository userResidenceRepository, ILogger<InformationController> logger)
        {
            _userResidenceRepository = userResidenceRepository;
            _logger = logger;
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

        public async Task<Residence?> GetResidenceByIdAsync(Guid id)
        {
            return await _userResidenceRepository.GetUserResidenceByInformationIdAsync(id);
        }
    }
}
