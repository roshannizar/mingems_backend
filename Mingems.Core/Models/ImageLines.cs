using Mingems.Shared.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mingems.Core.Models
{
    public class ImageLines : AuditableEntity
    {
        public string URL { get; set; }
        public string InventoryId { get; set; }
        [ForeignKey("InventoryId")]
        public virtual Inventory Inventory { get; set; }
    }
}
