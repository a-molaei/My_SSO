using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SSO.Models.SsoDbContext;
using SSO.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SsoDbContext _context;
        public UnitOfWork(SsoDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            RoleRepository = new RoleRepository(_context);
            UserRoleRepository = new UserRoleRepository(_context);
            ActionRepository = new ActionRepository(_context);
            RoleActionRepository = new RoleActionRepository(_context);
            ApplicationRepository = new ApplicationRepository(_context);
            RoleApplicationRepository = new RoleApplicationRepository(_context);
            SecurityLevelRepository = new SecurityLevelRepository(_context);
            SecurityModeRepository = new SecurityModeRepository(_context);
            SecurityLevelModelRepository = new SecurityLevelModelRepository(_context);
            SettingRepository = new SettingRepository(_context);
            SessionRepository = new SessionRepository(_context);
            UserRestrictedIpRepository = new UserRestrictedIpRepository(_context);
            HardwareTokenCodeRepository = new HardwareTokenCodeRepository(_context);
            PhoneVerificationCodeRepository = new PhoneVerificationCodeRepository(_context);
            RoleGroupRepository = new RoleGroupRepository(_context);
        }
        public SsoDbContext GetDbContext()
        {
            return _context;
        }
        public int Complete()
        {
            //try
            //{
            //    return _context.SaveChanges();
            //}
            //catch (DbEntityValidationException e)
            //{
            //    var newException = new FormattedDbEntityValidationException(e);
            //    return -1;
            //}
            try
            {
                var entities = from e in _context.ChangeTracker.Entries()
                               where e.State == EntityState.Added
                                   || e.State == EntityState.Modified
                               select e.Entity;
                foreach (var entity in entities)
                {
                    var validationContext = new ValidationContext(entity);
                    Validator.ValidateObject(entity, validationContext);
                }

                return _context.SaveChanges();
            }
            catch(ValidationException ex)
            {
                return -1;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public IUserRepository UserRepository { get; }
       public IRoleRepository RoleRepository { get; }
       public IUserRoleRepository UserRoleRepository { get; }
       public IActionRepository ActionRepository { get; }
       public IApplicationRepository ApplicationRepository { get; }
       public IRoleActionRepository RoleActionRepository { get; }
       public IRoleApplicationRepository RoleApplicationRepository { get; }
       public IRoleGroupRepository RoleGroupRepository { get; }
       public ISettingRepository SettingRepository { get; }
       public ISessionRepository SessionRepository { get; }
       public IHardwareTokenCodeRepository HardwareTokenCodeRepository { get; }
       public IPhoneVerificationCodeRepository PhoneVerificationCodeRepository { get; }
       public IUserRestrictedIpRepository UserRestrictedIpRepository { get; }
       public ISecurityLevelRepository SecurityLevelRepository { get; }
       public ISecurityModeRepository SecurityModeRepository { get; }
       public ISecurityLevelModelRepository SecurityLevelModelRepository { get; }
    }
}
