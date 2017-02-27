using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;



namespace DataAccess
{
    public class MongoAccess : IDataAccess
    {
        private IMongoDatabase _mongoDatabase;


        public MongoAccess(string connection, string dataBase)
        {
            //not depreciated pattern
            var settings = MongoClientSettings.FromUrl(new MongoUrl(connection));
            _mongoDatabase = new MongoClient(settings).GetDatabase(dataBase);
        }

        public void LogOrder(OrderDetail pOrderDetail)
        {
        }

        public List<OrderDetail> GetAllOrders()
        {
            var list = new List<OrderDetail>();
            return list;
        }

        public void ClearHistory()
        {
        }
    }
}