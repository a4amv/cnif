﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobFairInformationForm.Database
{
    public class ApplicationDbContextFactory
    {
        private readonly string _connectionString;

        public ApplicationDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ApplicationDbContext Create()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
