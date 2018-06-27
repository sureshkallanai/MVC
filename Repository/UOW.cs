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
        private IEventsRepository<EventsName> _IEventsRepository;
        private IEventsDataRepository<EventData> _IEventsDataRepository;
               
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


        public IEventsRepository<EventsName> _iEventsRepository
        {
            get
            {
                if (_IEventsRepository == null)
                    _IEventsRepository = new EventsRepository(_TContext);
                return _IEventsRepository;
            }
        }

        public IEventsDataRepository<EventData> _iEventsDataRepository
        {
            get
            {
                if (_IEventsDataRepository == null)
                    _IEventsDataRepository = new EventsDataRepository(_TContext);
                return _IEventsDataRepository;
            }
        }
    }
}