using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.ViewComponents
{
    public class _AboutComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<About> _aboutCollection;
        public _AboutComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _aboutCollection = database.GetCollection<About>(_databaseSettings.AboutCollectionName);

        }
        public IViewComponentResult Invoke()
        {
            var values = _aboutCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
