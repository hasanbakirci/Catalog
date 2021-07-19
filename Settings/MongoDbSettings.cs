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


// docker network create net5tutorial
// docker network ls
// docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=mongopass --network=net5tutorial mongo
// docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:Password=mongopass --network=net5tutorial catalog:v1
// artık http://localhost:8080/items ile giris yapılabilir. !! HTTP  s yok