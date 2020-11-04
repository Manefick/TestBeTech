using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public interface IStoregeRepository
    {
        IQueryable<Storage> Storages { get; }
    }
}
