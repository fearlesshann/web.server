using web.server.Entity;

namespace web.server.service
{
    public interface IBlogService
    {
        Task AddAsync(TBlog blog);
        Task<List<TBlog>> GetAllAsync();
        Task<TBlog?> GetAsync(int id);
        Task<string> DeleteAsync(int id, string password);
        Task<string> UpdateAsync(TBlog blog, string password);
    }
}
