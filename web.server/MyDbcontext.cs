using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using web.server.Entity;

namespace web.server
{
    public class MyDbcontext : DbContext
    {
        public MyDbcontext()
        {
        }

        public MyDbcontext(DbContextOptions<MyDbcontext> options)
            : base(options)
        {
        }

        public DbSet<TBlog> Blogs { get; set; }

    }
}
