using NewBegin.Data.AuxiliaryModels;
using NewBegin.Infrastructure.Repositories.Interfaces;
using NewBegin.Services.Intefaces;
using Microsoft.Extensions.Logging;

namespace NewBegin.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ILogger<UserService> logger;

        public UserService(
            IUserRepository userRepository,
            ILogger<UserService> logger)
        {
            this.userRepository = userRepository;
            this.logger = logger;
        }


        public async Task<UserRegistrationResponse> UserRegistration(UserRegistrationModel newUser)
        {
            if (newUser == null)
            {
                logger.LogError("An empty {user} object came in for registration", newUser);
                return new UserRegistrationResponse()
                {
                    Message = "Internal server Error",
                    Success = false,
                };
            }

            if (!await EmailValidator.IsValidEmailAsync(newUser.Email))
            {
                logger.LogWarning("Incorrect email adress : {email}", newUser.Email);
                return new UserRegistrationResponse()
                {
                    Message = "Incorrect email address entered",
                    Success = false,
                };
            }
            if (!await userRepository.CheckingUserAvailabilityByEmail(newUser.Email))
            {
                return new UserRegistrationResponse()
                {
                    Message = "A user with this email address has already been registered",
                    Success = false,
                };
            }
            if (await userRepository.AddNewUser(newUser) == 0)
            {
                logger.LogError("Failed to save a new user to the database");
                return new UserRegistrationResponse()
                {
                    Message = "Internal server Error",
                    Success = false,
                };
            }
            logger.LogInformation("Added new user: {email}", newUser.Email);
            return new UserRegistrationResponse()
            {
                Message = "Registration successfully",
                Success = true,
            };
        }
    }
}
