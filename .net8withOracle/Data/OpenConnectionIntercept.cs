using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using vlife.Data;

namespace lvife.Data.Interceptor
{
    public class OpenConnectionIntercept : DbConnectionInterceptor
    {
        private readonly Context _context;
        private readonly IHttpContextAccessor _accessor;

        public OpenConnectionIntercept(Context context,
                                       IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }

        public override void ConnectionOpened(DbConnection connection, ConnectionEndEventData eventData)
        {
            base.ConnectionOpened(connection, eventData);
        }
    }
}
