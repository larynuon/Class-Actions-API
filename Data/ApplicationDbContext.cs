using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Class_Actions_API.Models;

namespace Class_Actions_API.Data

{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Claim> Claims { get; set; }
    }
}
