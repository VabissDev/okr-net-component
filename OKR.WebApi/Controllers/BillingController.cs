﻿using Microsoft.AspNetCore.Mvc;
using OKR.WebApi.Models;
using OKR.WebApi.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        private readonly IBillingService _service;

        public BillingController(IBillingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.Get();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBilling(int id)
        {
            var result = await _service.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBilling([FromBody] BillingModel model)
        {

            var result = await _service.Add(model);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBilling(int id, [FromBody] UpdateBillingModel model)
        {
            var result = await _service.Update(id, model);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBilling(int id)
        {
            var result = await _service.Delete(id);

            return Ok(result);
        }
    }
}
