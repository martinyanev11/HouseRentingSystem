namespace HouseRentingSystem.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    using System.ComponentModel.DataAnnotations;

    using static Constants.EntityConstants.AgentConstants;

    public class Agent
    {
        public Agent()
        {
            ManagedHouses = new HashSet<House>();
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Phone]
        [MaxLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;

        public ICollection<House> ManagedHouses { get; set; }
    }
}
