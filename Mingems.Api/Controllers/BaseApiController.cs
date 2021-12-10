using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Mingems.Api.Controllers
{
    public class BaseApiController : ControllerBase
    {
        public readonly IMapper mapper;

        public BaseApiController(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
