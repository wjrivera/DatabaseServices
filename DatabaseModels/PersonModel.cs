using DatabaseContext;

namespace DatabaseModels
{
    public class PersonModel : IIdentifiable<string>
    {
        public string Id { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }
    }
}