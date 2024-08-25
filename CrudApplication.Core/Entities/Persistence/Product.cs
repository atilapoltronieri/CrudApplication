using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudApplication.Core.Entities.Persistence
{
    [Table("Product")]
    public class Product : BaseClass
    {
        [Required, StringLength(maximumLength: 8, MinimumLength = 2)]
        public string? Code { get; set; }
        [Required, StringLength(maximumLength: 100, MinimumLength = 2)]
        public string? Name { get; set; }
        [Required, StringLength(maximumLength: 350)]
        public string? Description { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
