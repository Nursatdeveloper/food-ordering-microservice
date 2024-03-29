﻿using MongoDB.Driver;
using System.Linq.Expressions;

namespace Image.Grpc.Service.Repository
{
    public class MongoRepository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T> dbCollection;
        private readonly FilterDefinitionBuilder<T> filterBuilder = Builders<T>.Filter;

        public MongoRepository(IMongoDatabase database, string collectionName)
        {
            dbCollection = database.GetCollection<T>(collectionName);
        }
        public async Task<T> CreateAsync(T entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await dbCollection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> condition)
        {
            return await dbCollection.Find(condition).FirstOrDefaultAsync();
        }
    }
}
