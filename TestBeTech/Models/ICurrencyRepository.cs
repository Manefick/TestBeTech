﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public interface ICurrencyRepository
    {
        IQueryable<Currency> Currencies { get; }
        public void EditCurrency(Currency currency);
    }
}
