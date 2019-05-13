using SSO.Models;
using SSO.Models.SsoDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Repositories.IRepositories
{
    public class HardwareTokenCodeRepository : Repository<HardwareTokenCode>, IHardwareTokenCodeRepository
    {
        private readonly SsoDbContext _context;

        public HardwareTokenCodeRepository(SsoDbContext context) : base(context)
        {
            _context = context;
        }

        public SsoDbContext SsoDbContext => Context as SsoDbContext;
    }
}
