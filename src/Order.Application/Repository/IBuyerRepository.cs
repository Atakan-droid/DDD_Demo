﻿using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Application.Repository
{
    public interface IBuyerRepository : IRepository
    {
        object GetById(int buyerId);
    }
}
