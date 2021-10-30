using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThingsToDoApi.Entities;

namespace ThingsToDoApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppDataTable> Details{get;set;}

        public DbSet<User> UserDetails{get;set;}
    }
}