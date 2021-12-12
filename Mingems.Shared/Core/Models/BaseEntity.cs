using System.ComponentModel.DataAnnotations;

namespace Mingems.Shared.Core.Models
{
    public class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
