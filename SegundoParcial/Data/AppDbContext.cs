using Microsoft.EntityFrameworkCore;
using SegundoParcial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundoParcial.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Suerte> Lucky { get; set; }
        public object Suerte { get; internal set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
