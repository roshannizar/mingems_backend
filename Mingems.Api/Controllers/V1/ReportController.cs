using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Mingems.Api.Middleware;
using Mingems.Core.SPModels;
using Mingems.Report.Interfaces;
using System.Threading.Tasks;

namespace Mingems.Api.Controllers.V1
{
    [Route("api/v1/reports")]
    [ApiController]
    public class ReportController : BaseApiController
    {
        private readonly IDashboardService dashboardService;

        public ReportController(IDashboardService dashboardService, IMapper mapper) : base(mapper)
        {
            this.dashboardService = dashboardService;
        }

        [Authorize]
        [HttpGet("meta")] 
        public async Task<ActionResult<DashboardModel>> GetMetaAsync()
        {
            var model = await dashboardService.GetDashboardAsync();
            return Ok(model);
        }
    }
}
