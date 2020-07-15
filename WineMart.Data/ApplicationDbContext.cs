using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WineMart.Data.Models;

namespace WineMart.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(){}
        public ApplicationDbContext(DbContextOptions options) : base(options){}
        public DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAddress> Addresses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Inventory> ProductInventories { get; set; }
        public virtual DbSet<InventoryTracking> InventoryTrackings { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

    }
}
