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
        public async Task<IActionResult> AddSubscription([FromBody] SubscriptionModel model)
        {
            var subscription = new Subscription
            {
                Id = model.Id,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                Active = model.Active
            };
            var result = await _db.Create(subscription);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateSubscriptionModel model)
        {
            var subscriptionModel = await _db.GetById(id);
            if (subscriptionModel != null)
            {
                subscriptionModel.StartTime = model.StartTime;
                subscriptionModel.EndTime = model.EndTime;
                subscriptionModel.Active = model.Active;
            }
            var result = await _db.Update(subscriptionModel);          

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
