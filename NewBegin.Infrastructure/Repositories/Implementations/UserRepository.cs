using Microsoft.EntityFrameworkCore;
using NewBegin.Data.AuxiliaryModels;
using NewBegin.Infrastructure.Repositories.Interfaces;

namespace NewBegin.Infrastructure.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        public UserRepository(ApplicationDbContext DbContext) 
        {
            this.dbContext = DbContext;
        }
        public async Task<int> AddNewUser(UserRegistrationModel newUserData)
        {
            var newUser = new Data.Models.UserModel()
            {
                Id = UserIDGenerator.GenerateID(),
                Email = newUserData.Email,
                Name = newUserData.Name
            };
            await dbContext.Users.AddAsync(newUser);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckingUserAvailabilityByEmail(string email)
        {
            return !await dbContext.Users.AnyAsync(e => e.Email == email);
        }
    }
}
