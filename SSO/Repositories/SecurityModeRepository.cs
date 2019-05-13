using SSO.Models;
using SSO.Models.SsoDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Repositories.IRepositories
{
    public class SecurityModeRepository : Repository<SecurityMode>, ISecurityModeRepository
    {
        private readonly SsoDbContext _context;

        public SecurityModeRepository(SsoDbContext context) : base(context)
        {
            _context = context;
        }

        public SsoDbContext SsoDbContext => Context as SsoDbContext;
    }
}
