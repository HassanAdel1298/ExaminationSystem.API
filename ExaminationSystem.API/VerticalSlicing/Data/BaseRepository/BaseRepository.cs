using Microsoft.EntityFrameworkCore;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using System.Linq.Expressions;

namespace ExaminationSystem.API.VerticalSlicing.Data.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        public Context _context { get; }

        internal BaseRepository(Context context)
        {
            _context = context;
        }

        
        #region GetAll
        public async Task<IQueryable<T>> GetAllAsync()
        {
            return _context.Set<T>();
        }
        #endregion

        #region First Or Default
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.FirstOrDefaultAsync();
        }
        #endregion

        #region Get Where
        public async Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            return query;
        }

        public async Task<IQueryable<T>> GetWhereAsync(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query;
        }
       
        #endregion

        #region Get Any
        public async Task<bool> GetAnyAsync(Expression<Func<T, bool>> filter = null)
        {
            return await _context.Set<T>().AnyAsync(filter);
        }
        #endregion

        #region Create 
        public void CreateAsync(T entity)
        {
            _context.Set<T>().AddAsync(entity);
        }
        public void CreateListAsync(List<T> entityList)
        {
            _context.Set<T>().AddRangeAsync(entityList);
        }
        #endregion
        #region Update
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
        public void UpdateList(List<T> entityList)
        {
            _context.Set<T>().UpdateRange(entityList);
        }
        #endregion

        #region Delete
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void DeleteList(List<T> entityList)
        {
            _context.Set<T>().RemoveRange(entityList);
        }
        
        #endregion

        public async Task SaveChangesAsync()
        {
            try
            {
               await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               await Task.FromResult(ex);
            }
        }
    }
}
