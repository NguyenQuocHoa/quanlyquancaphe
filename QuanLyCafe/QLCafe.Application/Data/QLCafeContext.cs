using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLCafe.Application.Data
{
    public class QLCafeContext : DbContext
    {
        public QLCafeContext(DbContextOptions<QLCafeContext> options)
            : base(options)
        {
        }

        //public DbSet<Name_Model> Name_Model { get; set; }
    }
}
