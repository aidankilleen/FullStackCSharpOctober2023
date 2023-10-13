using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInvestigation
{
    public class MemberDbContext : DbContext
    {


        private string connectionString;

        public MemberDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Member> Members { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
