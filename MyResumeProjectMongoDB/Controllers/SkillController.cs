using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;
using Newtonsoft.Json;

namespace MyResumeProjectMongoDB.Controllers
{
    public class SkillController : Controller
    {
        private readonly IMongoCollection<Skill> _skillCollection;
        public SkillController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _skillCollection = database.GetCollection<Skill>(_databaseSettings.SkillCollectionName);
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SkillList()
        {
            var values = await _skillCollection.Find(x => true).ToListAsync();
            var jsonSkill = JsonConvert.SerializeObject(values);
            return Json(jsonSkill);
        }


        [HttpPost]
        public async Task<IActionResult> CreateSkill(Skill skill)
        {
            await _skillCollection.InsertOneAsync(skill);
            var values = JsonConvert.SerializeObject(skill);
            return Json(values);
        }

        public async Task<IActionResult> GetSkill(string SkillId)
        {
            var values = await _skillCollection.Find(x => x.SkillID == SkillId).FirstOrDefaultAsync();
            var jsonvalues = JsonConvert.SerializeObject(values);
            return Json(jsonvalues);
        }

        public async Task<IActionResult> DeleteSkill(string id)
        {
            await _skillCollection.DeleteOneAsync(x => x.SkillID == id);
            return NoContent();
        }

        public async Task<IActionResult> UpdateSkill(Skill skill)
        {
            var values = await _skillCollection.FindOneAndReplaceAsync(x => x.SkillID == skill.SkillID, skill);
            return NoContent();

        }
    }
}

