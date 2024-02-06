using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;
using Newtonsoft.Json;

namespace MyResumeProjectMongoDB.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IMongoCollection<Service> _servicesCollection;
        public ServiceController(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _servicesCollection = database.GetCollection<Service>(_databaseSettings.ServiceCollectionName);
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> ServiceList()
        {
            var values = await _servicesCollection.Find(x => true).ToListAsync();
            var jsonService = JsonConvert.SerializeObject(values);
            return Json(jsonService);
        }


        [HttpPost]
        public async Task<IActionResult> CreateService(Service service)
        {
            await _servicesCollection.InsertOneAsync(service);
            var values = JsonConvert.SerializeObject(service);
            return Json(values);
        }

        public async Task<IActionResult> GetService(string ServiceId)
        {
            var values = await _servicesCollection.Find(x => x.ServiceID == ServiceId).FirstOrDefaultAsync();
            var jsonvalues = JsonConvert.SerializeObject(values);
            return Json(jsonvalues);
        }

        public async Task<IActionResult> DeleteService(string id)
        {
            await _servicesCollection.DeleteOneAsync(x => x.ServiceID == id);
            return NoContent();
        }

        public async Task<IActionResult> UpdateService(Service service)
        {
            var values = await _servicesCollection.FindOneAndReplaceAsync(x => x.ServiceID == service.ServiceID, service);
            return NoContent();

        }
    }
}
