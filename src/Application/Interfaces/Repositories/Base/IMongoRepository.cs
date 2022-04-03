using Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.Base
{
    public interface IMongoRepository<TDocument> where TDocument : Document 
    {
        Task<ICollection<TDocument>> GetAllAsync();
        Task<TDocument> FindByIdAsync(string id);
        Task InsertOneAsync(TDocument document);
        Task ReplaceOneAsync(TDocument document);
        Task DeleteByIdAsync(string id);
    }
}
