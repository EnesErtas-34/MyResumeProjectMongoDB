using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.Controllers
{
    public class MyProjectController : Controller
    {
        private readonly IMongoCollection<MyProject> _myProjectCollection;
        public MyProjectController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _myProjectCollection = database.GetCollection<MyProject>(_databaseSettings.MyProjectCollectionName);

        }
        public async Task<IActionResult> Index()
        {
            var values = await _myProjectCollection.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateMyProject()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMyProject(MyProject myProject)
        {
            await _myProjectCollection.InsertOneAsync(myProject);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteMyProject(string id)
        {
            await _myProjectCollection.DeleteOneAsync(x => x.MyProjectID == id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateMyProject(string id)
        {
            var values = await _myProjectCollection.Find(x => x.MyProjectID == id).FirstOrDefaultAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMyProject(MyProject myProject)
        {
            await _myProjectCollection.FindOneAndReplaceAsync(x => x.MyProjectID == myProject.MyProjectID, myProject);
            return RedirectToAction("Index");
        }
    }
}
