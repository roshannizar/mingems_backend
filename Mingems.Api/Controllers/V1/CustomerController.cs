using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mingems.Api.Dtos.Customer;
using Mingems.Api.Middleware;
using Mingems.Core.Models;
using Mingems.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Api.Controllers.V1
{
    [Route("api/v1/customers")]
    [ApiController]
    public class CustomerController : BaseApiController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService, IMapper mapper) : base(mapper)
        {
            this.customerService = customerService;
        }

        [Authorize(Role = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CreateCustomerDto customerDto)
        {
            var customer = mapper.Map<Customer>(customerDto);
            await customerService.CreateAsync(customer);
            return new JsonResult(new { message = "Created customer successfully!" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize(Role = "Admin")]
        [HttpPut]
        public async Task<ActionResult> UpdateCustomer(UpdateCustomerDto customerDto)
        {
            var customer = mapper.Map<Customer>(customerDto);
            await customerService.UpdateAsync(customer);
            return new JsonResult(new { message = "Updated customer successfully!" }) { StatusCode = StatusCodes.Status200OK };
        }

        [Authorize(Role = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> DeleteCustomer(string Id)
        {
            await customerService.DeleteAsync(Id);
            return new JsonResult(new { message = "Deleted customer successfully!" }) { StatusCode = StatusCodes.Status200OK };
        }

        [Authorize(Role = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customer = await customerService.GetAllAsync();
            var mappedCustomer = mapper.Map<IEnumerable<CustomerDto>>(customer);
            return Ok(mappedCustomer);
        }

        [Authorize(Role = "Admin")]
        [HttpGet("{Id}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(string Id)
        {
            var customer = await customerService.GetAsync(Id);
            var mappedCustomer = mapper.Map<CustomerDto>(customer);
            return Ok(mappedCustomer);
        }
    }
}
