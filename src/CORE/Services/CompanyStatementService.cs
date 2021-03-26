using CORE.Entities;
using CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Services
{
    public class CompanyStatementService : ICompanyStatementService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyStatementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CompanyStatement> GetAll()
        {
            var _getAll = _unitOfWork.CompanyStatementRepository.GetAll();
            return (_getAll);
        }
        public async Task InsertCompanyStatement(CompanyStatement companyStatement)
        {

            var _currentRelease = GetAll().Reverse().Take(1).Select(x => x.TotalReleases);
            int _filingNumber = _currentRelease.FirstOrDefault();
            if (_currentRelease != null)
            {
                _filingNumber = _filingNumber + 1;
            }
            else
            {
                _filingNumber = 0;
            }

            CompanyStatement _companyStatement = new CompanyStatement();
            _companyStatement.Id = companyStatement.Id;
            _companyStatement.NameFile = companyStatement.NameFile;
            _companyStatement.Remitent = companyStatement.Remitent;
            _companyStatement.Destinatary = companyStatement.Destinatary;
            _companyStatement.IsItInternally = companyStatement.IsItInternally;
            
            if (companyStatement.IsItInternally)
            {
                _companyStatement.FilingNumber = $"CI{_filingNumber:D8}";
            }
            else
            {
                _companyStatement.FilingNumber = $"CE{_filingNumber:D8}";
            }
            _companyStatement.TotalReleases = _filingNumber;

            //Implementar Radicación
            await _unitOfWork.CompanyStatementRepository.Add(_companyStatement);
            await _unitOfWork.saveChangesAsync();
        }
        public async Task<bool> DeleteCompanyStatement(int id)
        {
            await _unitOfWork.CompanyStatementRepository.Delete(id);
            await _unitOfWork.saveChangesAsync();
            return true;
        }
        public async Task<CompanyStatement> GetCompanyStatement(int id)
        {
            return await _unitOfWork.CompanyStatementRepository.GetById(id);
        }
        public async Task<IEnumerable<CompanyStatement>> GetAllByRemitent(int remitent)
        {
            var _userId = await _unitOfWork.UserSystemRepository.GetById(remitent);

            var _getAll = _unitOfWork.CompanyStatementRepository.GetAll().Where(x => x.Remitent == _userId.Id);
            return (_getAll);
        }
        public async Task<IEnumerable<CompanyStatement>> GetAllByDestinatary(int destinatary)
        {
            var _userId = await _unitOfWork.UserSystemRepository.GetById(destinatary);

            var _getAll = _unitOfWork.CompanyStatementRepository.GetAll().Where(x => x.Remitent == _userId.Id);
            return (_getAll);
        }

    }
}
