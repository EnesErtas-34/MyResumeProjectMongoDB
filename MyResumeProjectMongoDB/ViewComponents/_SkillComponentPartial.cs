using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.ViewComponents
{
    public class _SkillComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Skill> _skillCollection;
        public _SkillComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _skillCollection = database.GetCollection<Skill>(_databaseSettings.SkillCollectionName);

        }
        public IViewComponentResult Invoke()
        {
            var values = _skillCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
