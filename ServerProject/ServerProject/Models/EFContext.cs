using ClientProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerProject.Models
{
    public class EFContext : DbContext
    {
        private const string connectionString = "User ID=sa;password=DockerSql2017!;Initial Catalog=PROJETOFINAL;Data Source=tcp:localhost,11433;";

        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseSqlServer(connectionString);

        public DbSet<Logs> Logs { get; set; }
    }
}
