using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostgreSqlExample.Data
{
    public class PostgresqlExampleDbContext:DbContext
    {
        public PostgresqlExampleDbContext(DbContextOptions<PostgresqlExampleDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresqlExampleDbContext).Assembly);
        }
    }
}
