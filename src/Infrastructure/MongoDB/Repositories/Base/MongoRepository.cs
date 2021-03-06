using Application.Interfaces.Repositories.Base;
using Domain.Attributes;
using Domain.Common;
using Domain.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.MongoDB.Repositories.Base
{
    public class MongoRepository<TDocument> : IMongoRepository<TDocument> 
        where TDocument : Document
    {
        protected readonly IMongoCollection<TDocument> _collection;

        public MongoRepository(IMongoClient client, MongoDBSettings settings)
        {
            var database = client.GetDatabase(settings.DatabaseName);
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public async Task<ICollection<TDocument>> GetAllAsync()
        {
            return await _collection
                .Find(x => true)
                .ToListAsync();
        }

        public async Task<TDocument> FindByIdAsync(string id)
        {
            return await _collection
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task InsertOneAsync(TDocument document)
        {
            await _collection.InsertOneAsync(document);
        }

        public async Task ReplaceOneAsync(TDocument document)
        {
            var filter = Builders<TDocument>.Filter.Where(x => x.Id == document.Id);
            await _collection.ReplaceOneAsync(filter, document);
        }

        public async Task DeleteByIdAsync(string id)
        {
            var filter = Builders<TDocument>.Filter.Where(x => x.Id == id);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
