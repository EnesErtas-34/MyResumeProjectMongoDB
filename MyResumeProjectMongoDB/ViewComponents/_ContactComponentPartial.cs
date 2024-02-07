using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;
using System.Security.Cryptography.Pkcs;

namespace MyResumeProjectMongoDB.ViewComponents
{
    public class _ContactComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Contact> _contactCollection;
        public _ContactComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);

        }
        public IViewComponentResult Invoke()
        {
            var values = _contactCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
