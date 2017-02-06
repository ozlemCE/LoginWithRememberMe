using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using LoginWithRememberMe.Models;

namespace LoginWithRememberMe.Data
{
    public class AccountContext: DbContext
    {
        public AccountContext() : base("accountDB"){}
        
          public DbSet<Account> Account { get; set;}
          protected override void OnModelCreating(DbModelBuilder modelBuilder)
          {
              // olusturulan modeller de 's takısı eklenmemesı ıcın gerekli
              modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
          }
    }
}