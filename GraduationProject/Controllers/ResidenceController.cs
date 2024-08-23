using GraduationProject.Domain.Models;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduationProject.Controllers
{
    [Route("api/user_residence")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0ad9ab6d-d7dd-4089-9b60-052e603889a7, User")]
    public class ResidenceController : ControllerBase
    {
        private readonly IUserResidenceRepository _userResidenceRepository;
        private readonly ILogger<InformationController> _logger;
        public ResidenceController(IUserResidenceRepository userResidenceRepository, ILogger<InformationController> logger)
        {
            _userResidenceRepository = userResidenceRepository;
            _logger = logger;
        }

        [HttpGet("get_residence_from_all_user_informations")]
        public async Task<IEnumerable<Residence>> GetInformationsAsync()
        {
            var userResidence = await _userResidenceRepository.GetUserResidencesAsync();

            if (userResidence.Count < 2)
            {
                _logger.LogWarning("There are no user residence information in database");
                _logger.LogInformation("Returning {0} users ", userResidence.Count);
            }

            return userResidence;
        }
    }
}
