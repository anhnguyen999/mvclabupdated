using MvcMovie.Core;
using MvcMovie.Core.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcMovie.Infrastructure
{
   public class BinderRepository : IBinderRepository
    {
       private MovieDBContext context = new MovieDBContext();
        public IQueryable<Binder> GetAllBinders()
        {
            var result = from r in context.Binders select r;
            return result;

        }



        public Binder FindBinderById(int? Id)
        {
            var binder = (from m in context.Binders
                         where m.BinderNumber == Id
                         select m).FirstOrDefault();
            return binder;
            
        }


        public void  AddBinder(Binder binder)
        {

            context.Binders.Add(binder);
            context.SaveChanges();
               
        }


        public void DeleteBinder(Binder binder)
        {
            context.Binders.Remove(binder);
            context.SaveChanges();
        }

        public void EditBinder(Binder binder)
        {
           
                context.Entry(binder).State = EntityState.Modified;
                context.SaveChanges();
              
        }
    }
}
