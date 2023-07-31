using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Persistanse.EF
{
    public class EFDataContext:DbContext
    {
        public EFDataContext(
       string connectionString)
       : this(
           new DbContextOptionsBuilder<EFDataContext>()
               .UseSqlServer(connectionString).Options)
        {
        }

        public EFDataContext(
            DbContextOptions<EFDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
        }
    }
}
