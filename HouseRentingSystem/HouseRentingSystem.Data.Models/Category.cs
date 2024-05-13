namespace HouseRentingSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Constants.EntityConstants.CategoryConstants;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<House> Houses { get; set; } = new HashSet<House>();
    }
}
