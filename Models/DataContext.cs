﻿using Microsoft.EntityFrameworkCore;
using Models.Producto;

namespace Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Productos> Tbl_Productos { get; set; }
    }
}
