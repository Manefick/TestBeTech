using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace TestBeTech.Models
{
    public static class SeedData
    {

        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            //context.Database.Migrate();
            if (!context.Currencies.Any())
            {
                context.Currencies.AddRange(
                new Currency
                {
                    Name = "Гривня", ShortName = "UAH", ExchangeRate = 0.035, UpdateDate = DateTime.Today
                },
                new Currency
                {
                    Name = "Долар", ShortName= "USD", ExchangeRate = 1
                }, 
                new Currency
                {
                    Name = "Євро", ShortName = "EUR", ExchangeRate = 1.17, UpdateDate = DateTime.Today
                }
                );
                context.SaveChanges();
            }
        }
    }
}
