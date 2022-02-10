using Mingems.Shared.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mingems.Core.Models
{
    public class ImageLines : AuditableEntity
    {
        public string URL { get; set; }
        public string PurchaseId { get; set; }
        [ForeignKey("PurchaseId")]
        public virtual Purchase Purchase { get; set; }
    }
}
