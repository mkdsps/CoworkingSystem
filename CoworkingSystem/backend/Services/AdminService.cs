using CoworkingSystem.backend.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Services
{
    internal class AdminService
    {
        private readonly IAdminRepo _adminRepo;

        public AdminService(IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo ?? throw new ArgumentNullException(nameof(adminRepo));
        }

        public bool Validate(string username, string password)
        {
            var admin = _adminRepo.GetActiveByUsername(username);
            if (admin == null)
            {
                return false;
            }
            return BCrypt.Net.BCrypt.Verify(password, admin.LozinkaHash);
        }
    }
}
