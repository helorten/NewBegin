using NewBegin.Data.AuxiliaryModels;

namespace NewBegin.Services.Intefaces
{
    public interface IUserService
    {
        public Task<ServiceResponse> UserRegistration(UserRegistrationModel newUser);
    }
}
