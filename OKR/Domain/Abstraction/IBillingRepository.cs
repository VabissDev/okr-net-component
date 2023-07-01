﻿using StorageCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageCore.Domain.Abstraction
{
    public interface IBillingRepository : IRepository<Billing>
    {
        void Update(Billing billing);
        IList<Billing> Get();
        void Delete(int id);
    }
}
