using SSO.Models;
using SSO.Models.SsoDbContext;
using SSO.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Repositories.IRepositories
{
    public class AuthenticationStepRepository : Repository<AuthenticationStep>, IAuthenticationStepRepository
    {
        private readonly SsoDbContext _context;

        public AuthenticationStepRepository(SsoDbContext context) : base(context)
        {
            _context = context;
        }

        public SsoDbContext SsoDbContext => Context as SsoDbContext;
    }
}
