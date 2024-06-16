using NewBegin.Data.AuxiliaryModels;
using NewBegin.Data.Models;
using NewBegin.Infrastructure.Repositories.Interfaces;

namespace NewBegin.Infrastructure.Repositories.Implementations
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly ApplicationDbContext context;

        public BusinessRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<int> AddNewBusiness(NewBusinessRegistrationModel businessRegistrationModel)
        {
            var newBusiness = new BusinessModel()
            {
                Id = BusinessIDGenerator.GenerateID(businessRegistrationModel.Location),
                Name = businessRegistrationModel.Name,
                Description = businessRegistrationModel.Description,
                OwnerID = businessRegistrationModel.OwnerID,
                ClosingTime = businessRegistrationModel.ClosingTime,
                OpeningTime = businessRegistrationModel.OpeningTime,
                Location = businessRegistrationModel.Location,
            };
            await context.Businesses.AddAsync(newBusiness);
            return await context.SaveChangesAsync();
        }
    }
}
