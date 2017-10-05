using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseConfig;
using DatabaseContext;
using DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PersonServices;

namespace DatabaseServices.Controllers
{
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        private readonly IRepository<PersonModel, string> _repository;
        private readonly IOptions<MongoConfig> _options;
        private IMongoContext _context;

        //public PersonController(IPersonService personService, IRepository<PersonModel, string> repository, IOptions<MongoConfig> options, IMongoContext context)
        public PersonController(IPersonService personService, IRepository<PersonModel, string> repository, IOptions<MongoConfig> mongoConfig, IMongoContext mongoContext)
        {
            _context = mongoContext;
            _repository = repository;
            _options = mongoConfig;
            var x = _options.Value.collection;
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
        public IActionResult Get(string id)
        {
            var listPersons = _personService.GetPerson(id);
            return Ok(listPersons);
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
