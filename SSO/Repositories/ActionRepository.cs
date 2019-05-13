using SSO.Models.SsoDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Action = SSO.Models.Action;
namespace SSO.Repositories.IRepositories
{
    public class ActionRepository : Repository<Action>, IActionRepository
    {
        private readonly SsoDbContext _context;

        public ActionRepository(SsoDbContext context) : base(context)
        {
            _context = context;
        }

        public SsoDbContext SsoDbContext => Context as SsoDbContext;
    }
}
