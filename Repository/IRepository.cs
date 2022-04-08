using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentServiceGQL.Repository
{
    public interface IRepository<T>
    {
        public  Task<IQueryable<T>> GetEntitiesAsync();
        public Task<T> GetEntityAsync(int id);
        public Task<T> CreateEntityAsync(T entity);
        public Task UpdateEntityAsync(T entity);
        public Task DeleteEntityAsync(int id);

    }
}