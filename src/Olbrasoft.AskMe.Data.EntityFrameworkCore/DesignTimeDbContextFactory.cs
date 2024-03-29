﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Olbrasoft.AskMe.Data.EntityFrameworkCore {
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AskDbContext> {
        public AskDbContext CreateDbContext(string[] args) {
            var builder = new DbContextOptionsBuilder<AskDbContext>();
            builder.UseSqlServer("Server=localhost; Database=AskMe; Trusted_Connection=True; MultipleActiveResultSets=true");
           // builder.UseSqlite(@"Data Source=.\bin\Debug\ask.design.db");
            return new AskDbContext(builder.Options);
        }
    }
}
