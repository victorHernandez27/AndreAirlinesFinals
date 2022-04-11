namespace Aeronave.Util
{
    public class MongoSettings : IMongoSettings
    {
        public string AeronaveCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
