using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public class StorageRepository : IStoregeRepository
    {
        private ApplicationDbContext context;
        public StorageRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Storage> Storages => context.Storages.Include(x => x.ProductStorages).ThenInclude(x => x.Product);
        public Storage StorageWithProd(int id)
        {
            return context.Storages
                .Include(x => x.ProductStorages)
                .ThenInclude(x => x.Product)
                .Include(x => x.ProductStorages)
                .ThenInclude(x => x.Product)
                .ThenInclude(x=>x.Category)
                .Include(x => x.ProductStorages)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Currency)
                .FirstOrDefault(x => x.Id == id);
        }

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
