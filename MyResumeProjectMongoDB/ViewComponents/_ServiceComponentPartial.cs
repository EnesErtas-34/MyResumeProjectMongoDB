using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.ViewComponents
{
    public class _ServiceComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Service> _servicesCollection;
        public _ServiceComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _servicesCollection = database.GetCollection<Service>(_databaseSettings.ServiceCollectionName);
        }

        public IViewComponentResult Invoke()
        {
            var values = _servicesCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
