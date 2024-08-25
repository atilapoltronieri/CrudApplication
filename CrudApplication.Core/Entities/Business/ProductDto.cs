using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Core.Entities.Business
{
    public class ProductDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Product Code is Required"), StringLength(maximumLength: 8, MinimumLength = 2, ErrorMessage = "Code length between 2 and 8")]
        public string Code { get; set; } = string.Empty;
        [Required(ErrorMessage = "Product Name is Required"), StringLength(maximumLength: 100, MinimumLength = 2, ErrorMessage = "Name length between 2 and 100")]
        public string Name { get; set; } = string.Empty;
        [StringLength(maximumLength: 350, ErrorMessage = "Description length max of 100")]
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}
