using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OKR.WebApi.Models
{
    public class UpdateSubscriptionModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
