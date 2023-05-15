using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web.server.Entity
{
    public class TBlog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationTime { get; set; }
        public string Content { get; set; }
    }
}
