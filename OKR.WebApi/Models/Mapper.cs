using OKR.Common.Mappers;
using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OKR.WebApi.Models
{
    public class Mapper : BaseMapper<Subscription, SubscriptionModel>
    {
        public override Subscription Map(SubscriptionModel model)
        {
            return new Subscription()
            {
                Id = model.Id,
                StartTime = model.StartTime,
                EndTime=model.EndTime,
                Active=model.Active
            };
        }

        public override SubscriptionModel Map(Subscription entity)
        {
            return new SubscriptionModel()
            {
                Id = entity.Id,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                Active = entity.Active
            };
        }
    }
}
