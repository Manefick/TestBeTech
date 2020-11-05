using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public class CurrencyRepository: ICurrencyRepository
    {
        private ApplicationDbContext context;
        public CurrencyRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Currency> Currencies => context.Currencies;
        public void EditCurrency(Currency currency)
        {
            if (currency != null)
            {
                context.Entry(currency).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
