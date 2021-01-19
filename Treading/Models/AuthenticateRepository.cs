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

            return true;
        }
    }
}