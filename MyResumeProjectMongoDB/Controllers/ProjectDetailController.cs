using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.Controllers
{
    public class ProjectDetailController : Controller
    {
        private readonly IMongoCollection<ProjectDetail> _projectDetailCollection;
        public ProjectDetailController(IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _projectDetailCollection = database.GetCollection<ProjectDetail>(_databaseSettings.ProjectDetailCollectionName);
         
        }
        public async Task<IActionResult> Index()
        {
            var values = await _projectDetailCollection.Find(x => true).ToListAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateProjectDetail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectDetail(ProjectDetail projectDetail)
        {
            await _projectDetailCollection.InsertOneAsync(projectDetail);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProjectDetail(string id)
        {
            await _projectDetailCollection.DeleteOneAsync(x => x.ProjectDetailID == id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProjectDetail(string id)
        {
            var values = await _projectDetailCollection.Find(x => x.ProjectDetailID == id).FirstOrDefaultAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProjectDetail(ProjectDetail projectDetail)
        {
            await _projectDetailCollection.FindOneAndReplaceAsync(x => x.ProjectDetailID == projectDetail.ProjectDetailID, projectDetail);
            return RedirectToAction("Index");
        }
    }
}
