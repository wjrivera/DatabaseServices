using System.Collections.Generic;
using DatabaseModels;

namespace PersonServices
{
    public interface IPersonService
    {
        IEnumerable<PersonModel> FindPersonByName(string name);
        List<PersonModel> GetAll();
        PersonModel GetPerson(string id);
        void UpsertPerson(PersonModel person);
        void DeletePerson(string id);
    }
}