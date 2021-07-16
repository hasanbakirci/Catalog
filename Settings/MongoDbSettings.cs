namespace catalog.Settings
{
    public class MongoDbSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString { get{return $"mongodb://{User}:{Password}@{Host}:{Port}";} }
    }
}

// Mongodb şifreli ise appsetting e username yazılır
// dotnet user-secrets init
// dotnet user-secrets set MongoDbSettings:Password mongopass
//