using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MyResumeProjectMongoDB.DAL.Entities;
using MyResumeProjectMongoDB.DAL.Settings;

namespace MyResumeProjectMongoDB.ViewComponents
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        public _TestimonialComponentPartial(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.Databasename);
            _testimonialCollection = database.GetCollection<Testimonial>(_databaseSettings.TestimonialCollectionName);
        }
        public IViewComponentResult Invoke()
        {
            var values = _testimonialCollection.Find(x => true).ToList();
            return View(values);
        }
    }
}
