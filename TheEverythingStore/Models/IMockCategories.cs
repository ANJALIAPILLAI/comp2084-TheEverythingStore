using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheEverythingStore.Models
{
    public interface IMockCategories
    {
        IQueryable<Category> Categories { get; }
        Category Save(Category category);
        void Delete(Category category);
        void Dispose();
    }
}
