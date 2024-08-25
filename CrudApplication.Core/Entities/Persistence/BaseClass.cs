using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Core.Entities.Persistence
{
    public abstract class BaseClass
    {
        [Key]
        public int Id { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
