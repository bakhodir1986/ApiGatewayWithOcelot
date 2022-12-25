namespace Catalog_Service_BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IItemRepository _itemRepository;

        public CategoryService(ICategoryRepository categoryRepository,
            IItemRepository itemRepository)
        {
            this._categoryRepository = categoryRepository;
            this._itemRepository = itemRepository;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }

        public IEnumerable<Item> GetItems(Guid categoryId, int page)
        {
            if (categoryId == Guid.Empty) throw new ArgumentNullException("categoryId");
            return _itemRepository.GetItemsByCategory(categoryId, page);
        }

        public void AddCategory(Category _category)
        {
            if (_category == null) throw new ArgumentNullException("_category");

            Category category = new()
            {
                Id = Guid.NewGuid(),
                Name = _category.Name,
                Image = _category.Image,
                Parent = _categoryRepository.Get(_category.Parent == null ? Guid.NewGuid()
                : _category.Parent.Id)
            };

            _categoryRepository.Add(category);
        }

        public void AddItem(Guid categotyId, Item item)
        {
            item.Id = Guid.NewGuid();
            item.Category = _categoryRepository.Get(categotyId);

            _itemRepository.Add(item);
        }

        public void UpdateCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException("category");
            var selectedCategory = _categoryRepository.Get(category.Id);
            selectedCategory.Name = category.Name;
            selectedCategory.Parent = category.Parent;

            _categoryRepository.Update(selectedCategory);
        }

        public void UpdateItem(Item item)
        {
            var selectedItem = _itemRepository.GetById(item.Id);
            if (selectedItem == null) return;

            selectedItem.Name = item.Name;
            selectedItem.Image = item.Image;
            selectedItem.Price = item.Price;
            selectedItem.Description = item.Description;
            selectedItem.Amount = item.Amount;

            _itemRepository.Update(selectedItem);
        }

        public void DeleteItem(Guid itemId)
        {
            if (itemId == Guid.Empty) return;

            var selectedItem = _itemRepository.GetById(itemId);

            _itemRepository.Delete(selectedItem);
        }

        public void DeleteCategory(Guid categoryId)
        {
            if (categoryId == Guid.Empty) return;

            var selectedCategory = _categoryRepository.Get(categoryId);

            var selectedItems = _itemRepository.GetAllItemsByCategory(categoryId);

            foreach (var item in selectedItems)
            {
                _itemRepository.Delete(item);
            }

            _categoryRepository.Delete(selectedCategory);
        }
    }
}
