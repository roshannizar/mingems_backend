using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mingems.Api.Dtos.Inventories;
using Mingems.Api.Middleware;
using Mingems.Core.Models;
using Mingems.Core.Services;
using Mingems.Shared.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Api.Controllers.V1
{
    [Route("api/v1/inventories")]
    [ApiController]
    public class InventoryController : BaseApiController
    {
        private readonly IInventoryService inventoryService;

        public InventoryController(IInventoryService inventoryService, IMapper mapper): base(mapper)
        {
            this.inventoryService = inventoryService;
        }

        [Authorize(Role = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateInventory(CreateInventoryDto inventoryDto)
        {
            var inventory = mapper.Map<Inventory>(inventoryDto);
            await inventoryService.CreateAsync(inventory);
            return new JsonResult(new { message = "Inventory created successfully" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize(Role = "Admin")]
        [HttpPut]
        public async Task<ActionResult> UpdateInventory(UpdateInventoryDto inventoryDto)
        {
            var inventory = mapper.Map<Inventory>(inventoryDto);
            await inventoryService.UpdateAsync(inventory);
            return new JsonResult(new { message = "Inventory updated successfully" }) { StatusCode = StatusCodes.Status200OK };
        }

        [Authorize(Role = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> DeleteInventory(string Id)
        {
            await inventoryService.DeleteAsync(Id);
            return new JsonResult(new { message = "Inventory deleted successfully" }) { StatusCode = StatusCodes.Status200OK };
        }

        [Authorize(Role = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDto>>> GetInventories()
        {
            var inventory = await inventoryService.GetAllAsync();
            var response = mapper.Map<IEnumerable<InventoryDto>>(inventory);
            return Ok(response);
        }

        [Authorize(Role = "Admin")]
        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<InventoryDto>>> GEtSearchInventory(SearchFilterModel searchFilterModel)
        {
            var inventory = await inventoryService.SearchInventory(searchFilterModel);
            var response = mapper.Map<IEnumerable<InventoryDto>>(inventory);
            return Ok(response);
        }

        [Authorize(Role = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryDto>> GetInventory(string Id)
        {
            var inventory = await inventoryService.GetAsync(Id);
            var response = mapper.Map<InventoryDto>(inventory);
            return Ok(response);
        }

        [Authorize(Role = "Admin")]
        [HttpGet("{id}/purchase")]
        public async Task<ActionResult<InventoryPurchaseDto>> GetInventoryByPurchase(string id)
        {
            var inventory = await inventoryService.GetInventoryByPurchaseId(id);
            var response = mapper.Map<InventoryPurchaseDto>(inventory);
            return Ok(response);
        }
    }
}
