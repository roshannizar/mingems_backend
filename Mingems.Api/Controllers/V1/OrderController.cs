using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mingems.Api.Dtos.Orders;
using Mingems.Api.Middleware;
using Mingems.Core.Models;
using Mingems.Core.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Api.Controllers.V1
{
    [Route("api/v1/orders")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService, IMapper mapper) : base(mapper)
        {
            this.orderService = orderService;
        }

        [Authorize(Role = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderDto orderDto)
        {
            var order = mapper.Map<Order>(orderDto);
            await orderService.CreateAsync(order);
            return new JsonResult(new { message = "Order has been placed!" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize(Role = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            var order = await orderService.GetAllAsync();
            var response = mapper.Map<IEnumerable<OrderDto>>(order);
            return Ok(response);
        }
    }
}
