using Microsoft.Extensions.Logging;
using NewBegin.Data.AuxiliaryModels;
using NewBegin.Data.Models;
using NewBegin.Infrastructure.Repositories.Interfaces;
using NewBegin.Services.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBegin.Services.Implementations
{
    public class BusinessService : IBusinessService
    {
        private readonly ILogger<BusinessService> logger;
        private readonly IBusinessRepository businessRepository;
        public BusinessService(
            ILogger<BusinessService> logger,
            IBusinessRepository businessRepository) 
        {
            this.logger = logger;
            this.businessRepository = businessRepository;
        }

        public Task<ServiceResponse> AddNewBusiness(NewBusinessRegistrationModel business)
        {
            if (business == null)
            {
                logger.LogWarning("Missing data from the object of registration of new business");
                return Task.FromResult(new ServiceResponse() { Message = "Missing object data", Success = false });
            }

            if (business.OpeningTime > business.ClosingTime)
            {
                logger.LogWarning("Data error: the value of the ‘Opening time’ field is greater than the value of the ‘Closing time’ field");
                return Task.FromResult(new ServiceResponse() { Message = "Data error: the value of the ‘Opening time’ field is greater than the value of the ‘Closing time’ field", Success = false });
            }


        }

        public Task<BusinessModel> DeleteBusiness(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BusinessModel> GetBusinessByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BusinessModel> UpdateBusiness(BusinessModel business)
        {
            throw new NotImplementedException();
        }
    }
}
