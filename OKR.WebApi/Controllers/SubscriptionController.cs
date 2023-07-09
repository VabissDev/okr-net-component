using Microsoft.AspNetCore.Mvc;
using OKR.WebApi.Models;
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
        private readonly ISubscriptionRepository _db;

        public SubscriptionController(ISubscriptionRepository db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _db.GetAll();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSubscription(int id)
        {
            var result = await _db.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubscription([FromBody] Subscription subscription)
        {
            var result = await _db.Create(subscription);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Subscription subscription)
        {
            var result = await _db.Update(subscription);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await _db.Delete(id);

            return Ok(result);
        }
    }
}
