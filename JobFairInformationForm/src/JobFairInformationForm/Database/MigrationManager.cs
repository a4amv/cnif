using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobFairInformationForm.Database
{
    public class MigrationManager : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create(DbContextFactoryOptions options)
        {
            var connectionString = "Server=tcp:a4amv2.database.windows.net,1433;Initial Catalog=cnif;Persist Security Info=False;User ID=JUR;Password=SuperTajneHeslo1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
                

            var factory = new ApplicationDbContextFactory(connectionString);
            return factory.Create();
        }
    }
}