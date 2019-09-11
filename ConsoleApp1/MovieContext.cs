using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace ConsoleApp1
{
    public class MovieContext : DbContext
    {
        public static readonly LoggerFactory FabricaLogger = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(FabricaLogger)
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=DBMovieCF;Trusted_Connection=True;");
        }
    }
}
