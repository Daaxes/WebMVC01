using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMVC01.Models;

namespace WebMVC01.Data
{
    public class WebMVC01Context : DbContext
    {
        public WebMVC01Context (DbContextOptions<WebMVC01Context> options)
            : base(options)
        {
        }

        public DbSet<WebMVC01.Models.Car> Car { get; set; } = default!;
        public DbSet<Customer> Customers { get; set; }
    }
}
