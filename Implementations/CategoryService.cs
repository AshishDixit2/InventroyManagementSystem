using InventoryManagement.Exceptions;
using InventoryManagement.Interfaces;
using InventoryManagement.Domain;
using InventoryManagement.Models;


namespace InventoryManagement.Implementations
{
    public class CategoryService : IProductCategory
    {
        private readonly IRepository<ProductCategory> _repository;
        public CategoryService(IRepository<ProductCategory> repository)
        {
            _repository = repository;
        }

        public ICollection<ViewProductCategory> GetAllCategory()
        {
            ICollection<ViewProductCategory> categoryList = new List<ViewProductCategory>();
            foreach (var category in _repository.GetAll(null))
            {
                categoryList.Add(new ViewProductCategory(category));
            }
            return categoryList;
        }

        public Guid AddCategory(PostProductCategory category)
        {
            var categoryEntity = new ProductCategory()
            {
                Name = category.Name
            };
            _repository.Add(categoryEntity);
            return categoryEntity.Id;
        }

        public ViewProductCategory GetCategory(Guid id)
        {
            CheckEntityFoundError(id);
            return new ViewProductCategory(_repository.Get(id));
        }

        public void CheckEntityFoundError(Guid id)
        {
            var customer = _repository.Get(id);
            if (customer != null)
            {
                return;
            }
            else
            {
                throw new EntityNotFoundException("category not found");
            }
        }
    }
}