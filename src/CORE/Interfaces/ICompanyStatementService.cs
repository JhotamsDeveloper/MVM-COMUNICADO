using CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    public interface ICompanyStatementService
    {
        IEnumerable<CompanyStatement> GetAll();
        Task InsertCompanyStatement(CompanyStatement companyStatement);
        Task<bool> DeleteCompanyStatement(int id);
        Task<CompanyStatement> GetCompanyStatement(int id);
        Task<IEnumerable<CompanyStatement>> GetAllByRemitent(int remitent);
        Task<IEnumerable<CompanyStatement>> GetAllByDestinatary(int destinatary);

    }
}
