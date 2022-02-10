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
        private readonly IPurchaseService purchaseService;

        public InventoryController(IPurchaseService purchaseService, IMapper mapper): base(mapper)
        {
            this.purchaseService = purchaseService;
        }

        [Authorize(Role = "Admin")]
        [HttpPut]
        public async Task<ActionResult> UpdateInventory(UpdateInventoryDto inventoryDto)
        {
            var inventory = mapper.Map<Purchase>(inventoryDto);
            await purchaseService.UpdateAsync(inventory);
            return new JsonResult(new { message = "Inventory updated successfully" }) { StatusCode = StatusCodes.Status200OK };
        }

        [Authorize(Role = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> DeleteInventory(string Id)
        {
            await purchaseService.DeleteAsync(Id);
            return new JsonResult(new { message = "Inventory deleted successfully" }) { StatusCode = StatusCodes.Status200OK };
        }

        [Authorize(Role = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventoryDto>>> GetInventories()
        {
            var inventory = await purchaseService.GetAllAsync();
            var response = mapper.Map<IEnumerable<InventoryDto>>(inventory);
            return Ok(response);
        }

        [Authorize(Role = "Admin")]
        [HttpPost("search")]
        public async Task<ActionResult<IEnumerable<InventoryDto>>> GEtSearchInventory(SearchFilterModel searchFilterModel)
        {
            var inventory = await purchaseService.SearchInventory(searchFilterModel);
            var response = mapper.Map<IEnumerable<InventoryDto>>(inventory);
            return Ok(response);
        }

        [Authorize(Role = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<InventoryDto>> GetInventory(string Id)
        {
            var inventory = await purchaseService.GetAsync(Id);
            var response = mapper.Map<InventoryDto>(inventory);
            return Ok(response);
        }
    }
}
