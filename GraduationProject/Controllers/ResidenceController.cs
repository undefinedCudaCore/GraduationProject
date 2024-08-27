using GraduationProject.Domain.Models;
using GraduationProject.Dto;
using GraduationProject.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GraduationProject.Controllers
{
    [Route("api/user_residence")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0ad9ab6d-d7dd-4089-9b60-052e603889a7, User")]
    public class ResidenceController : ControllerBase
    {
        private readonly IResidenceService _residenceService;
        public ResidenceController(IResidenceService residenceService)
        {

            _residenceService = residenceService;
        }

        [HttpGet("get_residence_from_all_user_informations")]
        public async Task<IEnumerable<Residence>> GetResidencesAsync()
        {
            return await _residenceService.GetAllResidencesAsync();
        }

        [HttpGet("get_residence_by_information_id/{id:Guid}")]
        public async Task<Residence?> GetResidenceByInformationIdAsync(Guid id)
        {
            return await _residenceService.GetResidenceByInfoIdAsync(id);
        }

        [HttpPost("create_new_user_residence")]
        public async Task AddResidenceAsync([FromForm] CreateUserResidenceDto request)
        {
            var user = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault().Value;

            await _residenceService.AddUserResidenceAsync(request, user);
        }

        [HttpPut("update_user_city")]
        public async Task UpdateUserCityAsync([FromForm] Guid residenceId, [FromForm] string city)
        {
            await _residenceService.UpdateUserCityAsync(residenceId, city);
        }

        [HttpPut("update_user_street")]
        public async Task UpdateUserStreetAsync([FromForm] Guid residenceId, [FromForm] string street)
        {
            await _residenceService.UpdateUserStreetAsync(residenceId, street);
        }

        [HttpPut("update_user_house_number")]
        public async Task UpdateUserHouseNumberAsync([FromForm] Guid residenceId, [FromForm] string houseNumber)
        {
            await _residenceService.UpdateUserHouseNumberAsync(residenceId, houseNumber);
        }

        [HttpPut("update_user_apartment_number")]
        public async Task UpdateUserApartmentNumberAsync([FromForm] Guid residenceId, [FromForm] string apartmentNumber)
        {
            await _residenceService.UpdateUseApartmentNumberAsync(residenceId, apartmentNumber);
        }
    }
}
