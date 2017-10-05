using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DatabaseContext;
using DatabaseModels;

namespace PersonServices
{
    public class PersonService : IPersonService
    {
        private readonly IMongoRepository<PersonModel, string> _repository;
        //public PersonService(IMongoRepository<PersonModel, string> repository)
        public PersonService()
        {
            //_repository = repository;
            //_repository = new MongoRepository<PersonModel>(new MongoContext("mongorepo", "person"));
            _repository = new MongoRepository<PersonModel>();
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