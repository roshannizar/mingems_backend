using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mingems.Api.Dtos.Investments;
using Mingems.Api.Middleware;
using Mingems.Core.Models;
using Mingems.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mingems.Api.Controllers.V1
{
    [Route("api/v1/investments")]
    [ApiController]
    public class InvestmentController : BaseApiController
    {
        private readonly IInvestmentService investmentService;

        public InvestmentController(IInvestmentService investmentService, IMapper mapper) : base(mapper)
        {
            this.investmentService = investmentService;
        }

        [Authorize(Role = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateInvestment(CreateInvestmentDto investmentDto)
        {
            var investment = mapper.Map<Investment>(investmentDto);
            await investmentService.CreateAsync(investment);
            return new JsonResult(new { message = "Investor created successfully!" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize(Role = "Admin")]
        [HttpPut]
        public async Task<ActionResult> UpdateInvestment(UpdateInvestmentDto investmentDto)
        {
            var investment = mapper.Map<Investment>(investmentDto);
            await investmentService.UpdateAsync(investment);
            return new JsonResult(new { message = "Investor updated successfully!" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize(Role = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> DeleteInvestment(string Id)
        {
            await investmentService.DeleteAsync(Id);
            return new JsonResult(new { message = "Investor deleted successfully!" }) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<InvestmentDto>> GetInvestment(string Id)
        {
            var investment = await investmentService.GetAsync(Id);
            var mappedInvestment = mapper.Map<InvestmentDto>(investment);
            return Ok(mappedInvestment);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvestmentDto>>> GetInvestments()
        {
            var investment = await investmentService.GetAllAsync();
            var mappedInvestment = mapper.Map<IEnumerable<InvestmentDto>>(investment);
            return Ok(mappedInvestment);
        }
    }
}
