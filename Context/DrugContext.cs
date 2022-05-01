using DrugWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DrugWebApp.Context
{
    public class DrugContext
        :DbContext
    {
        public DrugContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Drug> Drugs { get; set; }
    }
}
