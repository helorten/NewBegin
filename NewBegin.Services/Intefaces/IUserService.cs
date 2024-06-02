using NewBegin.Data.AuxiliaryModels;

namespace NewBegin.Services.Intefaces
{
    public interface IUserService
    {
        public Task<UserRegistrationResponse> UserRegistration(UserRegistrationModel newUser);
    }
}
