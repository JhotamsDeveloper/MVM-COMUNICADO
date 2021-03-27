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
        public static void SetUserSystemResponse(ISession session, UserSystemModel userSystemModel)
        {
            session.SetString("id", userSystemModel.Id.ToString());
            session.SetString("NameUser", userSystemModel.NameUser.ToString());
            session.SetString("TypeDocument", userSystemModel.TypeDocument.ToString());
            session.SetString("Document", userSystemModel.Document.ToString());
            session.SetString("Phone", userSystemModel.Phone.ToString());
            session.SetString("Email", userSystemModel.Email.ToString());
            session.SetString("AddressUser", userSystemModel.AddressUser.ToString());

        }

        public static UserSystemModel GetUserSystemResponse(ISession session)
        {
            UserSystemModel _userSystemModel = new UserSystemModel();

            _userSystemModel.Id = Convert.ToInt16(session.GetString("id"));
            _userSystemModel.AddressUser = session.GetString("NameUser");
            _userSystemModel.TypeDocument = Convert.ToInt16(session.GetString("TypeDocument"));
            _userSystemModel.Document = session.GetString("Document");
            _userSystemModel.Phone = session.GetString("Phone");
            _userSystemModel.Email = session.GetString("Email");
            _userSystemModel.AddressUser = session.GetString("AddressUser");

            return _userSystemModel;

        }

    }
}
