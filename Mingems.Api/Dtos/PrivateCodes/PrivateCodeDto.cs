using System;

namespace Mingems.Api.Dtos.PrivateCodes
{
    public class PrivateCodeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PriceCode { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
