using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppBoutique1.Models;

namespace WebAppBoutique1.Models
{
    //ItemContext is our helper class that will inherit the methods from DbContext
    public class ItemContext : DbContext
    {
        //Must inherrit from IdentityDbContext, type? AppUsers, the model we created.
     
        //Constructor
        public ItemContext(DbContextOptions<ItemContext> options)
        : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        //public DbSet<CategoryViewModel> Category { get; set; }
    }
}
