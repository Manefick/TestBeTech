using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public interface IStoregeRepository
    {
        IQueryable<Storage> Storages { get; }
        public void AddStorage(Storage storage) { }
        public void EditStorage(Storage storage) { }
        public void DeleteStorage(Storage storage) { }
        public Storage StorageWithProd(int id);
    }
}
