using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Treading.ViewModel;
namespace Treading.Models
{
    public class Patient
    {
        public List<PatientViewModel> GetPatient(int id)
        {
          List<PatientViewModel> pat = CommanRepository.listReturn<PatientViewModel>("sp_GetPatientById", new {
              id
          }).ToList();
            return pat;  
        }
    }
}