using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Repository
{
    public class RoleRepository:BaseCRUD<Roles,DbContext>, IRoleRepository<Roles>
    {
        public RoleRepository(DbContext _DbContext):base(_DbContext)
        {

        }
    }
}