using System.ComponentModel.DataAnnotations;

namespace NewBegin.Data.AuxiliaryModels
{
    public class NewBusinessRegistrationModel
    {
        [MaxLength(256)]
        public required string Name { get; set; }
        [MaxLength(2048)]
        public required string Description { get; set; }
        public required TimeOnly OpeningTime { get; set; }
        public required TimeOnly ClosingTime { get; set; }
        public required string Location { get; set; }
        public required string OwnerID { get; set; }
    }
}
