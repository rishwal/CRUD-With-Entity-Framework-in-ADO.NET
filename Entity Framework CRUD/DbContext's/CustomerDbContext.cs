using Entity_Framework_CRUD.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_CRUD
{
    public class CustomerDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public CustomerDbContext(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:CustomerDbContext"]);
            }
        }

        public DbSet<CustomerDTO> Customers { get; set; }

    }
}
