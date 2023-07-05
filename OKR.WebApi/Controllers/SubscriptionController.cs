using Microsoft.AspNetCore.Mvc;
using StorageCore.Domain.Abstraction;
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
        private readonly IUnitOfWork _db;
        public SubscriptionController(IUnitOfWork db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var subscriptions = _db.SubscriptionRepository.Get();

                return Ok(subscriptions);
            }
            catch
            {
                return BadRequest("Unknown error occured");
            }
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var subscription = _db.SubscriptionRepository.FindById(id);

                if (subscription == null)
                    return BadRequest("No subscripton found with given id");

                return Ok(subscription);
            }
            catch
            {
                return BadRequest("Unknown error occured");
            }
        }

        [HttpPost]
        public IActionResult Post(BankModel bankModel)
        {
            try
            {
                bankService.Save(bankModel);

                return Ok("Success!");
            }
            catch
            {
                return BadRequest("Failed to add");
            }
        }
    }
}
