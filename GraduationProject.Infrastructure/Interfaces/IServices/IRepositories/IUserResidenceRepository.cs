﻿using GraduationProject.Domain.Models;

namespace GraduationProject.Infrastructure.Interfaces.IServices.IRepositories
{
    public interface IUserResidenceRepository
    {
        public Task AddUserResidenceAsync(Residence residence);
        public Task<Residence?> GetUserResidenceByInformationIdAsync(Guid id);
        public Task<IList<Residence>> GetUserResidencesAsync();

    }
}
