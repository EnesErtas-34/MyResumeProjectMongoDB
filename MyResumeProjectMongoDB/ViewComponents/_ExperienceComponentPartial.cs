using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.ViewComponents
{
    public class _ExperienceComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Experience> _experienceCollection;
        public _ExperienceComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _experienceCollection = database.GetCollection<Experience>(_databaseSettings.ExperienceCollectionName);
        }

        public IViewComponentResult Invoke()
        {
            var values = _experienceCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
