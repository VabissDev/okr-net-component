﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OKR.WebApi.Models
{
    public class BillingModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime BillingDate { get; set; }
        [Required]
        public string PaymentsInfo { get; set; }
    }
}
