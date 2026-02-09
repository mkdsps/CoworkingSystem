using CoworkingSystem.backend.dbConnection;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend.Repositories
{
    internal class UserRepository
    {
        private readonly DbManager _dbManager;
        public UserRepository() 
        {
            _dbManager = DbManager.GetInstance();
        }

        public void InsertUser() // odradi ako hoces da proveris adaptere
        {

        }
    }
}
