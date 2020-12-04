using Microsoft.EntityFrameworkCore;

namespace transactioApp.Context
{    
    using Models.Dto;

    public class DatabaseContext : DbContext     
    {         
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)         
        {         
        }       

        public DbSet<TransactionDto> Transactions { get; set; }     
    } 
}