﻿using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
      
        public DbSet<Auth> usuarios { get; set; }

        


        
    }
}
