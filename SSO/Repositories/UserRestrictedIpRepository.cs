﻿using SSO.Models;
using SSO.Models.SsoDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Repositories.IRepositories
{
    public class UserRestrictedIpRepository : Repository<UserRestrictedIp>, IUserRestrictedIpRepository
    {
        private readonly SsoDbContext _context;

        public UserRestrictedIpRepository(SsoDbContext context) : base(context)
        {
            _context = context;
        }

        public SsoDbContext SsoDbContext => Context as SsoDbContext;
    }
}
