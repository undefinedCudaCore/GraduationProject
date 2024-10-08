﻿using GraduationProject.Domain.Models;

namespace GraduationProject.Infrastructure.Interfaces.IServices.IRepositories
{
    public interface IUserInformationRepository
    {

        public Task AddUserInformationAsync(Information information);
        public Task<IList<Information>> GetUserInformationsAsync();
        public Task<Information?> GetUserInformationByUserIdAsync(Guid id);
        public Information Get(Guid id);
        public Task UpdateAsync(Information information);
    }
}
