using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository
{
    public class UOW:BaseDataContext<DatabaseContext>
    {
        private IUserRepository<Users> _IUserRepository;
        private IRoleRepository<Roles> _IRoleRepository;
        
        public UOW()
        {

        }

        public IUserRepository<Users> _iUserRepository
        {
            get
            {
                if (_IUserRepository == null)
                    _IUserRepository = new UserRepository(_TContext);
                return _IUserRepository;
            }
        }

        public IRoleRepository<Roles> _iRoleRepository
        {
            get
            {
                if (_IRoleRepository == null)
                    _IRoleRepository = new RoleRepository(_TContext);
                return _IRoleRepository;
            }
        }
    }
}