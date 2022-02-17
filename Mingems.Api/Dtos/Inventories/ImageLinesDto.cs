using Mingems.Shared.Core.Enums;

namespace Mingems.Api.Dtos.Inventories
{
    public class ImageLinesDto
    {
        public string Id { get; set; }
        public string URL { get; set; }
        public string PurchaseId { get; set; }
        public RecordState RecordState { get; set; }
    }
}
