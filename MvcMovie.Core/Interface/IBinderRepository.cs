using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.Core.Interface
{
   public interface IBinderRepository
    {

       IQueryable<Binder> GetAllBinders();
       Binder FindBinderById(int? Id);

       void  AddBinder(Binder binder);
       void DeleteBinder(Binder binder);
       void EditBinder(Binder binder);

    }
}
