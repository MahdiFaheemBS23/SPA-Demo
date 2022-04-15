using Data.Entity;

namespace Service
{
    public interface IPersonService
    {
        Task<List<Person>> GetAllPersonsAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task<int> AddPersonAsync(Person entity);
        Task<int> UpdatePersonAsync(Person entity);
        Task<int> RemovePersonAsync(Person entity);
    }
}