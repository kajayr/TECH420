    using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace Models
{
    public class OrderDetail
    {
        public OrderDetail()
        {
            Date = DateTime.Now;
        }

        [BsonId]
        public string Id { get; set; }
        public long CreditCard { get;  set; }
        public long PhoneNumber { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        [BsonElement("Date")]
        // ReSharper disable once MemberCanBePrivate.Global
        public DateTime Date { get; set; }

    }
}
