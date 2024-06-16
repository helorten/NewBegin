using NewBegin.Data.AuxiliaryModels;
using NewBegin.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBegin.Services.Intefaces
{
    public interface IBusinessService
    {
        public Task<BusinessModel> GetBusinessByIdAsync(string id);
        public Task<ServiceResponse> AddNewBusiness(NewBusinessRegistrationModel business);
        public Task<BusinessModel> UpdateBusiness(BusinessModel business);
        public Task<BusinessModel> DeleteBusiness(string id);

    }
}
