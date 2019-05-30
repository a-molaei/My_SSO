using SSO.Models.SsoDbContext;
using SSO.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        SsoDbContext GetDbContext();
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        IActionRepository ActionRepository { get; }
        IApplicationRepository ApplicationRepository { get; }
        IRoleActionRepository RoleActionRepository { get; }
        IRoleApplicationRepository RoleApplicationRepository { get; }
        IRoleGroupRepository RoleGroupRepository { get; }
        ISettingRepository SettingRepository { get; }
        ISessionRepository SessionRepository { get; }
        IHardwareTokenCodeRepository HardwareTokenCodeRepository { get; }
        IMobileVerificationCodeRepository MobileVerificationCodeRepository { get; }
        IUserRestrictedIpRepository UserRestrictedIpRepository { get; }
        ISecurityLevelRepository SecurityLevelRepository { get; }
        ISecurityModeRepository SecurityModeRepository { get; }
        ISecurityLevelModelRepository SecurityLevelModelRepository { get; }
        IAuthenticationStepRepository AuthenticationStepRepository { get; }



    }
}
