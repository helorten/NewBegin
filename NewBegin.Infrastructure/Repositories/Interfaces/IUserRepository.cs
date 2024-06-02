using NewBegin.Data.AuxiliaryModels;

namespace NewBegin.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<int> AddNewUser(UserRegistrationModel newUser);
        public Task<bool> CheckingUserAvailabilityByEmail(string email);
    }
}
