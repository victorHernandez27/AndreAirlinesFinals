namespace Aeronave.Util
{
    public interface IMongoSettings
    {
        string AeronaveCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
