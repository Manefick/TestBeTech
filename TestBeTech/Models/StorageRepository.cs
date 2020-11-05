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
        public void AddStorage(Storage storage)
        {
            if (storage != null)
            {
                context.Storages.Add(storage);
            }
            context.SaveChanges();
        }
        public void EditStorage(Storage storage)
        {
            if (storage != null)
            {
                context.Entry(storage).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteStorage(Storage storage)
        {
            if (storage != null)
            {
                context.Remove(storage);
                context.SaveChanges();
            }
        }
    }
}
