using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.Controllers
{

    public class ExperienceController : Controller
    {
        private readonly IMongoCollection<Experience> _experienceCollection;
        public ExperienceController(IDatabaseSettings _databaseSettings)
        {
            var client= new MongoClient(_databaseSettings.ConnectionString);
            var database=client.GetDatabase(_databaseSettings.Databasename);
            _experienceCollection = database.GetCollection<Experience>(_databaseSettings.ExperienceCollectionName);
        }
        public async Task<IActionResult> Index()
        {
            var values = await _experienceCollection.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateExperience(Experience experience)
        {
            await _experienceCollection.InsertOneAsync(experience);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteExperience(string id)
        {
            await _experienceCollection.DeleteOneAsync(x => x.ExperienceID == id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateExperience(string id)
        {
            var values = await _experienceCollection.Find(x => x.ExperienceID == id).FirstOrDefaultAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateExperience(Experience experience)
        {
            await _experienceCollection.FindOneAndReplaceAsync(x => x.ExperienceID == experience.ExperienceID, experience);
            return RedirectToAction("Index");
        }
    }
}
