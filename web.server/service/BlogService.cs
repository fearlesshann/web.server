using Microsoft.EntityFrameworkCore;
using web.server.Entity;

namespace web.server.service
{
    public class BlogService : IBlogService
    {
        private readonly MyDbcontext _dbcontext;

        public BlogService( MyDbcontext myDbcontext)
        {
            _dbcontext = myDbcontext;
        }

        public async Task AddAsync(TBlog blog)
        {
            if(blog.Title == "" || blog.Content == "") return;
            blog.CreationTime = DateTime.Now;
            await _dbcontext.Blogs.AddAsync(blog);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<TBlog>> GetAllAsync()
        {
            return await _dbcontext.Blogs.ToListAsync();
        }

        public async Task<TBlog?> GetAsync(int id)
        {
            return await _dbcontext.Blogs.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<string> DeleteAsync(int id, string password)
        {
            if (password == "840387")
            {
                var blog = await _dbcontext.Blogs.FirstOrDefaultAsync(b => b.Id == id);
                if (blog == null) return "Blog不存在！";
                _dbcontext.Blogs.Remove(blog);
                await _dbcontext.SaveChangesAsync();
                return "删除成功！";
            }
            return "密码错误！";
        }

        public async Task<string> UpdateAsync(TBlog blog, string password)
        {
            if(password == "840387")
            {
                var blogInDb = await _dbcontext.Blogs.FirstOrDefaultAsync(b => b.Id == blog.Id);
                if (blogInDb == null) return "Blog不存在！";
                blogInDb.Title = blog.Title;
                blogInDb.Content = blog.Content;
                _dbcontext.Update<TBlog>(blogInDb);
                await _dbcontext.SaveChangesAsync();
                return "修改成功！";
            }
            return "密码错误！";
        }
    }
}
