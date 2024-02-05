namespace MyResumeProjectMongoDB.DAL.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string Databasename { get; set; }
        public string ProfileCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string ProjectDetailCollectionName { get; set; }
        public string SkillCollectionName { get; set; }
    }
}
