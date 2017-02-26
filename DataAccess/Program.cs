//using System;

//namespace DataAccess
//{
//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            // this article helped
//            // http://www.dotnetcurry.com/aspnet/897/mongodb-aspnet-webapi-connection

//            var myMongoAccess = new MongoAccess();

//            var testContact = new Contact();
//            testContact.Name = "kurt3";
//            testContact.Address = "someplace3";
//            testContact.Phone = "12345673";
//            testContact.Email = "kurt3@there.com";

//            //myMongoAccess.CreateContact(testContact);

//            var myList = myMongoAccess.GetAllContacts();

//            foreach (var item in myList)
//                Console.WriteLine(item.Name + " " + item.Address);

//            Console.WriteLine("back to Main");
//            Console.ReadLine();
//        }
//    }
//}