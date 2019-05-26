using SSO.Models;
using SSO.Models.SsoDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Repositories.IRepositories
{
    public class MobileVerificationCodeRepository : Repository<MobileVerificationCode>, IMobileVerificationCodeRepository
    {
        private readonly SsoDbContext _context;

        public MobileVerificationCodeRepository(SsoDbContext context) : base(context)
        {
            _context = context;
        }

        public SsoDbContext SsoDbContext => Context as SsoDbContext;
    }
}
