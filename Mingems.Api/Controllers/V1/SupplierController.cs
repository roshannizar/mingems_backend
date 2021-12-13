using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mingems.Api.Dtos.Suppliers;
using Mingems.Core.Models;
using Mingems.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Api.Controllers.V1
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : BaseApiController
    {
        private readonly ISupplierService supplierService;

        public SupplierController(ISupplierService supplierService, IMapper mapper) : base(mapper)
        {
            this.supplierService = supplierService;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateSupplier(CreateSupplierDto supplierDto)
        {
            var supplier = mapper.Map<Supplier>(supplierDto);
            await supplierService.CreateAsync(supplier);
            return new JsonResult(new { message = "Supplier created successfully !." }) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSupplier(SupplierDto supplierDto)
        {
            var updatedsupplier = mapper.Map<Supplier>(supplierDto);
            await supplierService.UpdateAsync(updatedsupplier);
            return new JsonResult(new { message = "Supplier updated successfully" }) { StatusCode = StatusCodes.Status200OK };
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetSuppliers() {
            var suppliers = await supplierService.GetAllAsync();
            var mappedSuppliers = mapper.Map<IEnumerable<SupplierDto>>(suppliers);
            return Ok(mappedSuppliers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDto>> GetSupplier(string id) {
            var supplier = await supplierService.GetAsync(id);
            var mappedSupplier = mapper.Map<SupplierDto>(supplier);
            return Ok(mappedSupplier);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteSupplier() {
            return Ok();
        }
    }
}
