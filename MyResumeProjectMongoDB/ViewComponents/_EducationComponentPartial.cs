using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.ViewComponents
{
    public class _EducationComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Education> _educationCollection;
        public _EducationComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _educationCollection = database.GetCollection<Education>(_databaseSettings.EducationCollectionName);
        }
        public IViewComponentResult Invoke()
        {
            var values = _educationCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
