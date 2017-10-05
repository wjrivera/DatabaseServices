using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DatabaseConfig;
using DatabaseContext;
using DatabaseModels;
using Microsoft.Extensions.Options;

namespace PersonServices
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<PersonModel, string> _repository;
        private readonly IOptions<MongoConfig> _mongoConfig;
        private readonly IMongoContext _mongoContext;

        public PersonService(IRepository<PersonModel, string> repository, IOptions<MongoConfig> mongoConfig, IMongoContext mongoContext)
        //public PersonService()
        {
            _mongoContext = mongoContext;
            _mongoConfig = mongoConfig;
            _repository = repository;
            //_repository = new MongoRepository<PersonModel>(new MongoContext("mongorepo", "person"));
            //_repository = new MongoRepository<PersonModel>();

        }

        public IEnumerable<PersonModel> FindPersonByName(string name)
        {
            return _repository.Find(x => x.Name == name);
        }

        public List<PersonModel> GetAll()
        {
            return _repository.Query().ToList();
        }

        public PersonModel GetPerson(string id)
        {
            return _repository.Get(id);
        }

        public void UpsertPerson(PersonModel person)
        {
            _repository.Upsert(person);
        }

        public void DeletePerson(string id)
        {
            _repository.Delete(id);
        }
    }
}