﻿using GraduationProject.Domain.Models;
using GraduationProject.Dto;
using GraduationProject.Infrastructure.Interfaces.IServices.IRepositories;
using GraduationProject.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GraduationProject.Controllers
{
    [Route("api/user_information")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "0ad9ab6d-d7dd-4089-9b60-052e603889a7, User")]
    public class InformationController : ControllerBase
    {
        private readonly IInformationService _informationService;
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<InformationController> _logger;

        public InformationController(IUserInformationRepository userInformationRepository, IWebHostEnvironment environment, ILogger<InformationController> logger, IUserRepository userRepository, IInformationService informationService)
        {
            _userInformationRepository = userInformationRepository;
            _environment = environment;
            _logger = logger;
            _userRepository = userRepository;
            _informationService = informationService;
        }

        [HttpGet("get_info_from_all_users")]
        public async Task<IEnumerable<Information>> GetInformationsAsync()
        {
            return await _informationService.GetAllInformationsAsync();
        }

        [HttpPost("add_user_information")]
        public async Task CreateUserInformationAsync([FromForm] CreateUserInformationDto request)
        {
            var user = ((ClaimsIdentity)User.Identity).Claims.FirstOrDefault().Value;

            if (string.IsNullOrEmpty(request.FirstName)
                || string.IsNullOrEmpty(request.LastName)
                || string.IsNullOrEmpty(request.PhoneNumber)
                || request.FirstName.Length == 0
                || string.IsNullOrEmpty(request.EmailAddress))
            {
                _logger.LogError("Some user input information is missing");
                return;
            }
            await _informationService.AddUserInformationAsync(request, user);
        }

        [HttpGet("download_image_by_user_id/{id:Guid}")]
        public async Task<IActionResult> DownloadUserAvatarAsync(Guid id)
        {
            var userInformation = await _userInformationRepository.GetUserInformationByUserIdAsync(id);

            if (userInformation == null)
            {
                return NotFound();
            }

            return File(userInformation.FileData, "image/jpeg", userInformation.FileName);
        }

        [HttpGet("get_user_information_by_user_id/{id:Guid}")]
        public async Task<Information?> GetInformationByUserIdAsync(Guid id)
        {
            return await _informationService.GetOneUserInformationByUserIdAsync(id);
        }
    }
}
