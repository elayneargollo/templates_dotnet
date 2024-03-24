using Microsoft.EntityFrameworkCore;

namespace arquivoApi.Models
{
    public class MySqlContext: DbContext
    {
        public DbSet<FileDetails> File { get; set; }

        public MySqlContext() {}
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) {}
    }
}