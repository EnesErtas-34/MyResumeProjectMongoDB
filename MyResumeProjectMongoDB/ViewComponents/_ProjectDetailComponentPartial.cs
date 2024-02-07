using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.ViewComponents
{
    public class _ProjectDetailComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<ProjectDetail> _projectDetailCollection;
        public _ProjectDetailComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _projectDetailCollection = database.GetCollection<ProjectDetail>(_databaseSettings.ProjectDetailCollectionName);

        }
        public IViewComponentResult Invoke()
        {
            var values = _projectDetailCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
