using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_Commerce.Persistence
{
    public class E_CommerceDbContextFactory : IDesignTimeDbContextFactory<E_CommerceDbContext>
    {
        public E_CommerceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<E_CommerceDbContext>();

            // Use a connection string from your configuration for migrations
            optionsBuilder.UseSqlServer("Data Source =.;Initial Catalog=E-Commerce_db;Integrated Security =True;TrustServerCertificate=True;");

            return new E_CommerceDbContext(optionsBuilder.Options);
        }
    }
}
