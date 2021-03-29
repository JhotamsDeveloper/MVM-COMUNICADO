using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebClient.ModelResponse;
using WebClient.Models;

namespace WebClient
{
    internal static class GlobalApp
    {
        public static void SetUserSystemResponseR(ISession session, UserSystemModel userSystemModel)
        {
            session.SetString("idR", userSystemModel.Id.ToString());
            session.SetString("NameUserR", userSystemModel.NameUser.ToString());
            session.SetString("TypeDocumentR", userSystemModel.TypeDocument.ToString());
            session.SetString("DocumentR", userSystemModel.Document.ToString());
            session.SetString("PhoneR", userSystemModel.Phone.ToString());
            session.SetString("EmailR", userSystemModel.Email.ToString());
            session.SetString("AddressUserR", userSystemModel.AddressUser.ToString());

        }

        public static UserSystemModel GetUserSystemResponseR(ISession session)
        {
            UserSystemModel _userSystemModel = new UserSystemModel();

            _userSystemModel.Id = Convert.ToInt16(session.GetString("idR"));
            _userSystemModel.NameUser = session.GetString("NameUserR");
            _userSystemModel.TypeDocument = Convert.ToInt16(session.GetString("TypeDocumentR"));
            _userSystemModel.Document = session.GetString("DocumentR");
            _userSystemModel.Phone = session.GetString("PhoneR");
            _userSystemModel.Email = session.GetString("EmailR");
            _userSystemModel.AddressUser = session.GetString("AddressUserR");

            return _userSystemModel;

        }

        public static void SetUserSystemResponseD(ISession session, UserSystemModel userSystemModel)
        {
            session.SetString("idD", userSystemModel.Id.ToString());
            session.SetString("NameUserD", userSystemModel.NameUser.ToString());
            session.SetString("TypeDocumentD", userSystemModel.TypeDocument.ToString());
            session.SetString("DocumentD", userSystemModel.Document.ToString());
            session.SetString("PhoneD", userSystemModel.Phone.ToString());
            session.SetString("EmailD", userSystemModel.Email.ToString());
            session.SetString("AddressUserD", userSystemModel.AddressUser.ToString());

        }

        public static UserSystemModel GetUserSystemResponseD(ISession session)
        {
            UserSystemModel _userSystemModel = new UserSystemModel();

            _userSystemModel.Id = Convert.ToInt16(session.GetString("idD"));
            _userSystemModel.NameUser = session.GetString("NameUserD");
            _userSystemModel.TypeDocument = Convert.ToInt16(session.GetString("TypeDocumentD"));
            _userSystemModel.Document = session.GetString("DocumentD");
            _userSystemModel.Phone = session.GetString("PhoneD");
            _userSystemModel.Email = session.GetString("EmailD");
            _userSystemModel.AddressUser = session.GetString("AddressUserD");

            return _userSystemModel;

        }
        public static void SetTypeUser(ISession session, string typeUser)
        {
            session.SetString("typeUser", typeUser.ToString());
        }

        public static string GetTypeUser(ISession session)
        {
            return session.GetString("typeUser"); ;
        }

        public static void SetDocument(ISession session, string document)
        {
            session.SetString("documentRegister", document.ToString());
        }

        public static string GetDocument(ISession session)
        {
            return session.GetString("documentRegister"); ;
        }

        public static void SetCompanyStatement(ISession session, CompanyStatementModel companyStatementModel)
        {
            session.SetString("CompanyStatementId", companyStatementModel.Id.ToString());
            session.SetString("RemitentId", companyStatementModel.Remitent.ToString());
            session.SetString("DestinataryId", companyStatementModel.Destinatary.ToString());
            session.SetString("FilingNumber", companyStatementModel.FilingNumber.ToString());
        }

        public static CompanyStatementModel GetCompanyStatement(ISession session)
        {
            CompanyStatementModel companyStatementModel = new CompanyStatementModel();

            companyStatementModel.Id = Convert.ToInt16(session.GetString("CompanyStatementId"));
            companyStatementModel.Remitent = Convert.ToInt16(session.GetString("RemitentId"));
            companyStatementModel.Destinatary = Convert.ToInt16(session.GetString("DestinataryId"));
            companyStatementModel.FilingNumber = session.GetString("FilingNumber");
            return companyStatementModel;

        }


    }
}
