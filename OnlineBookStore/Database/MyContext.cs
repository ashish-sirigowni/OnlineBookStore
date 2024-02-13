using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Entity;

namespace OnlineBookStore.Database
{
    public class MyContext:DbContext
    {
        //define entity set
        private readonly IConfiguration configuration;

        public MyContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public DbSet<Book>? Books { get; set; }
        public DbSet<User>? Users { get; set; }
        


 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyConnection"));
        }
       

   


    }
}
