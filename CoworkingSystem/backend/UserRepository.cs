using System;
using System.Collections.Generic;
using System.Text;

namespace CoworkingSystem.backend
{
    internal class UserRepository
    {
        public UserRepository() { }

        public int getId() { return 1; }

        public override int getId()
        {
            throw new NotImplementedException();
        }
    }
}
