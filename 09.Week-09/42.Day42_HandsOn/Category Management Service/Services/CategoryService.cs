using Category_Management_Service.Models;
using Category_Management_Service.Repositories;

namespace Category_Management_Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Category>> GetAll() => await _repo.GetAll();

        public async Task<Category> GetById(int id) => await _repo.GetById(id);

        public async Task Add(Category category) => await _repo.Add(category);

        public async Task Update(Category category) => await _repo.Update(category);

        public async Task Delete(int id) => await _repo.Delete(id);
    
}
}
