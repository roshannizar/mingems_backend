using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mingems.Api.Dtos.PrivateCodes;
using Mingems.Api.Middleware;
using Mingems.Core.Models;
using Mingems.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mingems.Api.Controllers.V1
{
    [Route("api/v1/privatecodes")]
    [ApiController]
    public class PrivateCodeController : BaseApiController
    {
        private readonly IPrivateCodeService privateCodeService;

        public PrivateCodeController(IPrivateCodeService privateCodeService, IMapper mapper) : base(mapper)
        {
            this.privateCodeService = privateCodeService;
        }

        [Authorize(Role = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrivateCodeDto>>> GetPrivateCodes()
        {
            var privateCode = await privateCodeService.GetAllAsync();
            var response = mapper.Map<IEnumerable<PrivateCodeDto>>(privateCode);
            return Ok(response);
        }

        [Authorize(Role = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<PrivateCodeDto>> GetPrivateCode(string id)
        {
            var privateCode = await privateCodeService.GetAsync(id);
            var response = mapper.Map<PrivateCodeDto>(privateCode);
            return Ok(response);
        }

        [Authorize(Role = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreatePrivateCode(CreatePrivateCodeDto privateCodeDto)
        {
            var response = mapper.Map<PrivateCode>(privateCodeDto);
            await privateCodeService.CreateAsync(response);
            return new JsonResult(new { message = "Private Code Created Successfully!" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize(Role = "Admin")]
        [HttpPut]
        public async Task<ActionResult> UpdatePrivateCode(CreatePrivateCodeDto privateCodeDto)
        {
            var response = mapper.Map<PrivateCode>(privateCodeDto);
            await privateCodeService.UpdateAsync(response);
            return new JsonResult(new { message = "Private Code Updated Successfully!" }) { StatusCode = StatusCodes.Status201Created };
        }

        [Authorize(Role = "Admin")]
        [HttpDelete]
        public async Task<ActionResult> DeletePrivateCode(string Id)
        {
            await privateCodeService.DeleteAsync(Id);
            return new JsonResult(new { message = "Private Code Deleted Successfully!" }) { StatusCode = StatusCodes.Status201Created };
        }
    }
}
