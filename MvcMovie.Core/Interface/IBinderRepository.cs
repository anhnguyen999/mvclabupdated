using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.Core.Interface
{
    public interface IBinderRepository
    {

        IQueryable<Binder> GetAll();
        Binder FindById(int? Id);
        void Add(Binder binder);
        void Delete(Binder binder);
        void Edit(Binder binder);

    }
}
