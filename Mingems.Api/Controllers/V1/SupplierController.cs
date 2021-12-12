﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mingems.Api.Dtos.Suppliers;
using Mingems.Core.Models;
using Mingems.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<ActionResult> Create(CreateSupplierDto supplierDto)
        {
            var user = mapper.Map<Supplier>(supplierDto);
            await supplierService.CreateAsync(user);
            return new JsonResult(new { message = "Supplier created successfully !." }) { StatusCode = StatusCodes.Status201Created };
        }


    }
}