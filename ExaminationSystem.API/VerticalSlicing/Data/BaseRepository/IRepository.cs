using ExaminationSystem.API.VerticalSlicing.Data.Models;
using System.Linq.Expressions;

namespace ExaminationSystem.API.VerticalSlicing.Data.BaseRepository
{
    public interface IRepository<T> where T : BaseModel
    {
        
        Task<IQueryable<T>> GetAllAsync();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, string includeProperties = "");
        Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> filter = null);
        Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<bool> GetAnyAsync(Expression<Func<T, bool>> filter = null);
        void CreateAsync(T entity);
        void CreateListAsync(List<T> entityList);
        void Update(T entity);
        void UpdateList(List<T> entityList);
        void Delete(T entity);
        void DeleteList(List<T> entityList);
        Task SaveChangesAsync();
    }
}
