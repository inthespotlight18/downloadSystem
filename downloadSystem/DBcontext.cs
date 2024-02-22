using downloadSystem.Models;
using downloadSystem.DataHandler;
using Microsoft.EntityFrameworkCore;

namespace downloadSystem
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> MyDbSet { get; set; } //for Model class
        public DbSet<Meeting> MeetingSet { get; set; } //for Meeting class
        public DbSet<Recording> RecordingSet { get; set; } //for Recording class

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use the In-Memory database
            optionsBuilder.UseInMemoryDatabase("InMemoryDatabase");

            /*
            //Configure your SQL Server connection here
            optionsBuilder.UseSqlServer("your_connection_string");
            */

        }
    }
}
