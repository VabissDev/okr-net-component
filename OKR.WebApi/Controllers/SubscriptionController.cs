using Microsoft.AspNetCore.Mvc;
using OKR.WebApi.Models;
using OKR.WebApi.Services.Abstraction;
using StorageCore.Domain.Abstraction;
using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _service;

        public SubscriptionController(ISubscriptionService service)
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
        public async Task<IActionResult> GetSubscription(int id)
        {
            var result = await _service.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscription([FromBody] SubscriptionModel model)
        {

            var result = await _service.Add(model);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateSubscriptionModel model)
        {
            var result = await _service.Update(id,model);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _service.Delete(id);

            return Ok(result);
        }
    }
}
