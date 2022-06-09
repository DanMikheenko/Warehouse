﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.UI
{
    internal class ApplicationContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
        //public ApplicationContext()
        //{
        //    Database.EnsureCreated();
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=usersdb2;Username=postgres;Password=password");
        }
    }
}
