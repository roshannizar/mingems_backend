using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mingems.Api.Dtos.Purchases;
using Mingems.Api.Middleware;
using Mingems.Core.Models;
using Mingems.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Api.Controllers.V1
{
    [Route("api/v1/purchases")]
    [ApiController]
    public class PurchaseController : BaseApiController
    {
        private readonly IPurchaseService purchaseService;

        public PurchaseController(IPurchaseService purchaseService, IMapper mapper) : base(mapper)
        {
            this.purchaseService = purchaseService;
        }

        [Authorize(Role = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreatePurchase(CreatePurchaseDto purchaseDto)
        {
            var purchase = mapper.Map<Purchase>(purchaseDto);
            await purchaseService.CreateAsync(purchase);
            return new JsonResult(new { message = "Purchase created successfully" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize(Role = "Admin")]
        [HttpPut]
        public async Task<ActionResult> UpdatePurchase(UpdatePurchaseDto purchaseDto)
        {
            var purchase = mapper.Map<Purchase>(purchaseDto);
            await purchaseService.UpdateAsync(purchase);
            return new JsonResult(new { message = "Purchase updated successfully" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize(Role = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> DeletePurchase(string Id)
        {
            await purchaseService.DeleteAsync(Id);
            return new JsonResult(new { message = "Purchase deleted successfully" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize(Role = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PurchaseDto>>> GetPurchases()
        {
            var purchase = await purchaseService.GetAllAsync();
            var response = mapper.Map<IEnumerable<PurchaseDto>>(purchase);
            return Ok(response);
        }

        [Authorize(Role = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<PurchaseDto>> GetPurchase(string Id)
        {
            var purchase = await purchaseService.GetAsync(Id);
            var response = mapper.Map<PurchaseDto>(purchase);
            return Ok(response);
        }
    }
}
