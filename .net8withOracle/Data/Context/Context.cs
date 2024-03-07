using System.Reflection;
using lvife.Data.Interceptor;
using Microsoft.EntityFrameworkCore;

namespace vlife.Data
{
    public class Context : ContextoSistema
    {
        private readonly IHttpContextAccessor _accessor;


        public Context(DbContextOptions<Context> options, IConfiguration configuration, IHttpContextAccessor accessor) : base(options, configuration)
        {
            _accessor = accessor;
        }

        public Context() : base()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string schema = "DBASCHEMA";
            modelBuilder.HasDefaultSchema(schema);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.AddInterceptors(new OpenConnectionIntercept(this, _accessor));
        }
    }
}