using AssignmentMVC.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AssignmentMVC.Repositories
{
    public abstract class Repository<TEntity> where TEntity : class
    {
        private readonly IdentityContext _context;

        protected Repository(IdentityContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);

            if (entity != null)
                return entity;
            return null!;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
           return  await _context.Set<TEntity>().Where(expression).ToListAsync();

          
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();  
            return entity;
        }

        public async Task<bool>DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
