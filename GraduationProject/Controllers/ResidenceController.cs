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

        [HttpGet("{id:Guid}", Name = "get_residence_by_information_id")]
        public async Task<Residence?> GetResidenceByInformationIdAsync(Guid id)
        {
            return await _residenceService.GetResidenceByIdAsync(id);
        }

        [HttpPost("create_new_user_residence")]
        public async Task AddResidenceAsync([FromForm] CreateUserResidenceDto request)
        {
            var user = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault().Value;

            await _residenceService.AddUserResidenceAsync(request, user);
        }
    }
}
