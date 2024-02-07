using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.ViewComponents
{
    public class _MyProjectComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<MyProject> _myProjectCollection;
        public _MyProjectComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _myProjectCollection = database.GetCollection<MyProject>(_databaseSettings.MyProjectCollectionName);
        }
        public IViewComponentResult Invoke()
        {
            var values = _myProjectCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
