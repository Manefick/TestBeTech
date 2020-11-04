using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public class StorageRepository:IStoregeRepository
    {
        private ApplicationDbContext context;
        public StorageRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Storage> Storages => context.Storages;
    }
}
