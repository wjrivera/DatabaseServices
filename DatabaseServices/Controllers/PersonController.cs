using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseContext;
using DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using PersonServices;

namespace DatabaseServices.Controllers
{
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        //private readonly IMongoRepository<PersonModel, string> _repository;
        //private readonly IMongoContext _context;


        public PersonController(IPersonService personService, IMongoRepository<PersonModel, string> repository)
        //public PersonController(IPersonService personService)
        {
            //_repository = repository;
            //_context = new MongoContext("mongorepo", "person");
            //_repository = new MongoRepository<PersonModel>();

            //_personService = new PersonService(new MongoRepository<PersonModel>(new MongoContext("mongorepo", "person")));
            
            //_personService = new PersonService(repository);

            _personService = personService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("get/{id}")]
        public bool Get(int id)
        {
            var listPersons = _personService.GetAll();
            return true;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
