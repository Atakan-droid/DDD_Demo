﻿using Order.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Repository
{
    public interface IBuyerRepository : IRepository
    {
        object GetById();
    }
}
