using MvcMovie.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MvcMovie.Infrastructure
{
    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Binder> Binders { get; set; }
    }
}
