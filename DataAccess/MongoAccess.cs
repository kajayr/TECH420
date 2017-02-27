using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;



namespace DataAccess
{
    public class MongoAccess : IDataAccess
    {
        private MongoDatabase _mongoDatabase;
        private const string Collection = "CdSales";

        public MongoAccess(string connection, string dataBase)
        {


            MongoClient mongoClient = new MongoClient(
       new MongoUrl(connection));

            MongoServer server = mongoClient.GetServer();
            _mongoDatabase =  mongoClient.GetServer().GetDatabase(dataBase);

        }

        public void LogOrder(OrderDetail order)
        {
            try
            {


                var contactsList = _mongoDatabase.GetCollection(Collection);
                WriteConcernResult result;
                bool hasError = false;
                if (string.IsNullOrEmpty(order.Id))
                {
                    order.Id = ObjectId.GenerateNewId().ToString();
                    result = contactsList.Insert<OrderDetail>(order);
                    hasError = result.HasLastErrorMessage;
                }
                else
                {
                    IMongoQuery query = Query.EQ("_id", order.Id);
                    IMongoUpdate update = Update
                        .Set("Name", order.Name)
                        .Set("CreditCard", order.CreditCard)
                        .Set("PhoneNumber", order.PhoneNumber);
                    result = contactsList.Update(query, update);
                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        public   List<OrderDetail> GetAllOrders()
        {
           var  model = new List<OrderDetail>();
            var contactsList = _mongoDatabase.GetCollection(Collection).FindAll().AsEnumerable();

            model = (from order in contactsList
                     select new OrderDetail
                     {
                         Id = order["_id"].AsString,
                         Name = (string)order["Name"],
                         CreditCard = order["CreditCard"].ToInt64(),
                         PhoneNumber = order["PhoneNumber"].ToInt64(),
                        Price = Decimal.Parse(order["Price"].ToString())
                     }).ToList();
            return model;



        }


        public void ClearHistory()
        {
            _mongoDatabase.Drop();
        }


        private MongoDatabase RetreiveMongohqDb()
        {
            MongoClient mongoClient = new MongoClient(
                new MongoUrl(@"mongodb://kurtfriedrichuser:!qwerty8@ds053658.mlab.com:53658/kurtmd"));
            MongoServer server = mongoClient.GetServer();
            return mongoClient.GetServer().GetDatabase("kurtmd");
        }
    }
}