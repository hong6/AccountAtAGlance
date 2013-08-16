using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using AccountAtAGlance.Model;

namespace AccountAtAGlance.Repository
{
    public class AccountAtAGlance: DbContext
    {
        public DbSet<BrokerageAccount> BrokerageAccounts { get; set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Security> Securities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Position> Positions { get; set; }

        public DbSet<WatchList> WatchLists { get; set; }

        //EntityFramework 4.3 version code, current is 5.0
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //map to table, and you can also change name of the table of DB
            modelBuilder.Entity<Security>().ToTable("Security");
            
            //many to many, join table
            modelBuilder.Entity<WatchList>()
                .HasMany(w => w.Securities).WithMany()
                .Map(map => map.ToTable("WatchListSecurity")
                    .MapRightKey("SecurityId")
                    .MapLeftKey("WatchListId"));
            
            base.OnModelCreating(modelBuilder);
        }

        public int DeleteAccounts()
        {
            //stored procedure - DeleteAccounts
            //return base.Database.ExecuteSqlCommand("DeleteAccounts");
            return Database.ExecuteSqlCommand("DeleteAccounts");
        }

    }    
}
