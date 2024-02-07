using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.ViewComponents
{
    public class _ProfileComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Profile> _profileCollection;
        public _ProfileComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _profileCollection = database.GetCollection<Profile>(_databaseSettings.ProfileCollectionName);

        }
        public IViewComponentResult Invoke()
        {
            var values = _profileCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
