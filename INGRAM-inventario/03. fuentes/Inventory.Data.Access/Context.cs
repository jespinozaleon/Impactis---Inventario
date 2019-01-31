using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Data.Access
{
    public class Context : DbContext
    {
        public Context()
           : base(Utilities.Parameter.GetValue("DataBase"))
        {

        }
        
        public DbSet<Domain.APPLE_SP_ARTICULOS> APPLE_SP_ARTICULOS { get; set; }

        public DbSet<Domain.TBL_USER> TBL_USER { get; set; }

        public DbSet<Domain.TBL_DATA_ARTICLES> TBL_DATA_ARTICLES { get; set; }

        public DbSet<Domain.TBL_LOG> TBL_LOG { get; set; }

        public DbSet<Domain.TBL_ERROR> TBL_ERROR { get; set; }
    }
}
