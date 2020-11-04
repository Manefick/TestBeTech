using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public double ExchangeRate { get; set; }
        public DateTime UpdateDate { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
