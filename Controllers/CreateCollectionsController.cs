using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace createCollections.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CreateCollectionsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CreateCollectionsController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        [HttpGet]
        public void CreateCol([FromQuery] Dictionary<string, string> ColInfo) {
            
// ------------ arquivo config ---------------
            Config config = new Config() {
                Url = _configuration.GetValue<string>("Settings:ConnectionStringMDB"),
                Database = _configuration.GetValue<string>("Settings:Database"),
                Collection = _configuration.GetValue<string>("Settings:Collection")
            };


// ------------ receber dicionario de parametros ------------
            dynamic MyDynamic = new System.Dynamic.ExpandoObject();

            MyDynamic = ColInfo;

// ------------------ conexão mongo ----------------
            string connectionString = config.Url;
            MongoClient cliente = new MongoClient(connectionString);

            string databaseName = config.Database;
            string collectionName = config.Collection;

            var db = cliente.GetDatabase(databaseName);

// ------------ criar collection ------------
            var col = db.GetCollection<Dictionary<string, string>>(collectionName);

            col.InsertOne(MyDynamic);
        }
    }
}
