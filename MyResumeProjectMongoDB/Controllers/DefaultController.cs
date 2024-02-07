using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IMongoCollection<Message> _messageCollection;
        public DefaultController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _messageCollection = database.GetCollection<Message>(_databaseSettings.MessageCollectionName);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            await _messageCollection.InsertOneAsync(message);
            return RedirectToAction("Index");
        }
    }
}
