using Microsoft.EntityFrameworkCore;

namespace TestTask.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options)
            : base(options)
        {
        }

        public DbSet<TestTask.Models.Contact> Contact { get; set; } = default!;
    }
}
