using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestBeTech.Models
{
    public class ViewCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ViewChoiceCategory
    {
        public IEnumerable<ViewCategory> categories { get; set; }
        public string NewName { get; set; }
        public int SelectedCategory { get; set; }
    }
    public class ViewStorage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
    public class ViewChoiceStorage
    {
        public IEnumerable<ViewStorage> storages { get; set; }
        public int SelectedStorage { get; set; }
        public string NewName { get; set; }
        public string NewAdress { get; set; }
    }
}
