using Data.Entity;
using Repository;

namespace Service
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepo;

        public PersonService(IRepository<Person> personRepo)
        {
            _personRepo = personRepo;
        }

        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await _personRepo.GetAllAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            return await _personRepo.GetByIdAsync(id);
        }

        public async Task<int> AddPersonAsync(Person person)
        {
            return await _personRepo.AddAsync(person);
        }

        public async Task<int> UpdatePersonAsync(Person person)
        {
            return await _personRepo.UpdateAsync(person);
        }

        public async Task<int> RemovePersonAsync(Person person)
        {
            return await _personRepo.RemoveAsync(person);
        }
    }
}
