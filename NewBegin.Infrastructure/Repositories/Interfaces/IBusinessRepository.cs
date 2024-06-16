using NewBegin.Data.AuxiliaryModels;

namespace NewBegin.Infrastructure.Repositories.Interfaces
{
    public interface IBusinessRepository
    {
        public Task<int> AddNewBusiness(NewBusinessRegistrationModel business);
     //   public Task<int> UpdateBusinessInformation();
    }
}
