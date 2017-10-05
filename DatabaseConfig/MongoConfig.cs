using System;

namespace DatabaseConfig
{
    public class MongoConfig
    {
        public string database { get; set; }
        public string collection { get; set; }

        public MongoConfig()
        {
            database = "mongorepo";
            collection = "person";

        }
    }
}
