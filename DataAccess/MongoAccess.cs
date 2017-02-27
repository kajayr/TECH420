using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace DataAccess
{
    public class MongoAccess
    {
        //readonly 
        private MongoDatabase _mongoDatabase;
        private MongoClient mongoClient;

        public MongoAccess(string connection)
        {
             mongoClient = new MongoClient(new MongoUrl(connection));
        }

        public void CreateContact(Contact newContact)
        {
            try
            {
                _mongoDatabase = RetreiveMongohqDb();

                var contactsList = _mongoDatabase.GetCollection("ContactList");
                WriteConcernResult result;
                var hasError = false;
                if (string.IsNullOrEmpty(newContact.Id))
                {
                    newContact.Id = ObjectId.GenerateNewId().ToString();
                    result = contactsList.Insert(newContact);
                    hasError = result.HasLastErrorMessage;
                }
                else
                {
                    var query = Query.EQ("_id", newContact.Id);
                    IMongoUpdate update = Update
                        .Set("Name", newContact.Name)
                        .Set("Address", newContact.Address)
                        .Set("Phone", newContact.Phone)
                        .Set("Email", newContact.Email);
                    result = contactsList.Update(query, update);
                    //hasError = result.HasLastErrorMessage;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Contact> GetAllContacts()
        {
            _mongoDatabase = RetreiveMongohqDb();
            var model = new List<Contact>();
            var contactsList = _mongoDatabase.GetCollection("ContactList").FindAll().AsEnumerable();
            model = (from contact in contactsList
                select new Contact
                {
                    Id = contact["_id"].AsString,
                    Name = contact["Name"].AsString,
                    Address = contact["Address"].AsString,
                    Phone = contact["Phone"].AsString,
                    Email = contact["Email"].AsString
                }).ToList();
            return model;
        }


        private MongoDatabase RetreiveMongohqDb()
        {
            var mongoClient = new MongoClient(
                new MongoUrl(@"mongodb://kajayr:kaj8@ds053658.mlab.com:53658/420kurt"));
            var server = mongoClient.GetServer();
            return mongoClient.GetServer().GetDatabase("420kurt");
        }
    }
}