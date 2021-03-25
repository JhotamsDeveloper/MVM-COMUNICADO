using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<AuditSystem> AuditSystemRepository { get; }
        IRepository<CompanyStatement> CompanyStatementRepository { get; }
        IRepository<Roles> RolesRepository { get; }
        IRepository<UserSystem> UserSystemRepository { get; }
        IRepository<UserSystemRoles> UserSystemRolesRepository { get; }
        void saveChanges();
        Task saveChangesAsync();
    }
}
