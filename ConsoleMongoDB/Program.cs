using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace ConsoleMongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoCRUD db = new MongoCRUD("AddressBook");                                    
            db.InsertRecord("Users", new NameModel { FirstName = "TT", LastName = "AA" });

            Console.WriteLine("done");
        }

    }

    public class NameModel
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class MongoCRUD
    {
        IMongoDatabase db;

        public MongoCRUD(string database)
        {
            var client = new MongoClient();
            db = client.GetDatabase(database);          //connect which database exist ? create database
        }

       public void InsertRecord<T>(string table , T record)
        {
            var collection = db.GetCollection<T>(table);    //select which table exist ? create table
            collection.InsertOne(record);                   //insert record into table
        }
    }
}
