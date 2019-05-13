using SSO.Models;
using SSO.Models.SsoDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Repositories.IRepositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly SsoDbContext _context;

        public RoleRepository(SsoDbContext context) : base(context)
        {
            _context = context;
        }

        public SsoDbContext SsoDbContext => Context as SsoDbContext;
    }
}
