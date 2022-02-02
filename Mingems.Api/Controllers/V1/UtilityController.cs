using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mingems.Api.Dtos.Subscriptions;
using Mingems.Api.Middleware;
using Mingems.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Api.Controllers.V1
{
    [Route("api/v1/utility")]
    [ApiController]
    public class UtilityController : BaseApiController
    {
        private readonly ISubscriptionService subscriptionService;

        public UtilityController(ISubscriptionService subscriptionService, IMapper mapper) : base(mapper)
        {
            this.subscriptionService = subscriptionService;
        }

        [Authorize(Role = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubscriptionDto>>> GetSubscriptions()
        {
            var subscriptions = await subscriptionService.GetAllAsync();
            var response = mapper.Map<IEnumerable<SubscriptionDto>>(subscriptions);
            return Ok(response);
        }
    }
}
