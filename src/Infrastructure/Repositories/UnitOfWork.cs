using CORE.Entities;
using CORE.Interfaces;
using Infrastructure.Data;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly dbMVMComunicadoContext _contex;
        private readonly IRepository<UserSystem> _userSystemRepository;
        private readonly IRepository<Roles> _rolesRepository;
        private readonly IRepository<UserSystemRoles> _userSystemRolesRepository;
        private readonly IRepository<CompanyStatement> _companyStatementRepository;
        private readonly IRepository<AuditSystem> _auditSystemRepository;
  
        public UnitOfWork(dbMVMComunicadoContext contex)
        {
            _contex = contex;
        }

        public IRepository<AuditSystem> AuditSystemRepository =>
            _auditSystemRepository ?? new BaseRepository<AuditSystem>(_contex);

        public IRepository<CompanyStatement> CompanyStatementRepository =>
            _companyStatementRepository ?? new BaseRepository<CompanyStatement>(_contex);
        public IRepository<Roles> RolesRepository =>
             _rolesRepository ?? new BaseRepository<Roles>(_contex);

        public IRepository<UserSystemRoles> UserSystemRolesRepository =>
             _userSystemRolesRepository ?? new BaseRepository<UserSystemRoles>(_contex);

        public IRepository<UserSystem> UserSystemRepository =>
            _userSystemRepository ?? new BaseRepository<UserSystem>(_contex);

        public void Dispose()
        {
            if (_contex != null)
            {
                _contex.Dispose();
            }
        }

        public void saveChanges()
        {
            _contex.SaveChanges();
        }

        public async Task saveChangesAsync()
        {
            await _contex.SaveChangesAsync();
        }
    }
}
