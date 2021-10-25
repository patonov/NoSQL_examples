using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoClient client = new MongoClient("mongodb://127.0.0.1:27017");
            var database = client.GetDatabase("SoftUni");
            var collection = database.GetCollection<BsonDocument>("Students");
            var studentDoc = new BsonDocument {
                { "Name", "Pesho" }
            };
            collection.InsertOne(studentDoc);

            var students = collection.Find<BsonDocument>(new BsonDocument()).ToList();
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
    }
}
