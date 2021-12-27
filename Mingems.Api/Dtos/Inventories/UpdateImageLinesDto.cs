﻿using Mingems.Shared.Core.Enums;

namespace Mingems.Api.Dtos.Inventories
{
    public class UpdateImageLinesDto
    {
        public string URL { get; set; }
        public string InventoryId { get; set; }
        public RecordState RecordState { get; set; }
    }
}