using CoworkingSystem.backend.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Repositories
{
    interface IAdminRepo
    {
        Administrator? GetActiveByUsername(string username);
    }
}
