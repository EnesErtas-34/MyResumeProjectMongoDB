using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;
using System.Security.Cryptography.Pkcs;

namespace MyResumeProjectMongoDB.Controllers
{
	public class ContactController : Controller
	{
		private readonly IMongoCollection<Contact> _contactCollection;
        public ContactController(IDatabaseSettings _databaseSettings)
        {
			var client = new MongoClient(_databaseSettings.ConnectionString);
			var database = client.GetDatabase(_databaseSettings.Databasename);
			_contactCollection = database.GetCollection<Contact>(_databaseSettings.ContactCollectionName);
		}
		public async Task<IActionResult> Index()
		{
			var values = await _contactCollection.Find(x => true).ToListAsync();
			return View(values);
		}

		[HttpGet]
		public IActionResult CreateContact()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateContact(Contact contact)
		{
			await _contactCollection.InsertOneAsync(contact);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> DeleteContact(string id)
		{
			await _contactCollection.DeleteOneAsync(x => x.ContactID == id);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public async Task<IActionResult> UpdateContact(string id)
		{
			var values = await _contactCollection.Find(x => x.ContactID == id).FirstOrDefaultAsync();
			return View(values);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateContact(Contact contact)
		{
			await _contactCollection.FindOneAndReplaceAsync(x => x.ContactID == contact.ContactID, contact);
			return RedirectToAction("Index");
		}
	}
}
