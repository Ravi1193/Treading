using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Treading.ViewModel;

namespace Treading.Models
{
    public class AuthenticateRepository
    {
        public static bool Authenticate(AuthenticationViewModel model)
        {
            var validate = CommanRepository.singleReturn<AuthenticationViewModel>("sp_AuthenticateUser", new
            {
                model.Username,
                model.Password
            });
            if (validate != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int SaveUser(AuthenticationViewModel model)
        {
           var save =CommanRepository.WithoutReturn("sp_SaveUsers", new
            {
                model.Id,
                model.Name,
                model.Email,
                model.Mobile,
                model.Username,
                model.Password,
                model.Status
            });
            return save;
        }

        public bool EmailExit(string Email)
        {
            var CheckEMailExit = CommanRepository.singleReturn<bool>("sp_CheckExitEmail", new
            {
                Email
            });
            if(CheckEMailExit)
            {
                return false;
            }
            return true;
        }
    }
}