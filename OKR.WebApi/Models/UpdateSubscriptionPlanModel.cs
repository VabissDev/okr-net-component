using StorageCore.Domain.Entities;
using StorageCore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OKR.WebApi.Models
{
    public class UpdateSubscriptionPlanModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public PlanType Type { get; set; }
        [Required]
        public int SubscriptionId { get; set; }
        [Required]
        public Subscription Subscription { get; set; }
        [Required]
        public int UserCount { get; set; }
        [Required]
        public int WorkspaceCount { get; set; }
    }
}
