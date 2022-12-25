using Catalog_Service_BLL;
using Microsoft.AspNetCore.Mvc;

namespace Catalog_Service_Rest_Api.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IUrlHelper _urlHelper;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public CategoryController(ICategoryService categoryService) //, IUrlHelper injectedUrlHelper
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            this._categoryService = categoryService;
            //this.urlHelper = injectedUrlHelper;
        }

        [HttpGet(Name = nameof(Get))]
        public IEnumerable<Category> Get()
        {
            return _categoryService.GetCategories();//.Select(x => CreateLinksForCategory(x));
        }

        [HttpGet("{categoryid}/items/{page}", Name = nameof(GetItems))]
        public IEnumerable<Item> GetItems([FromRoute] string categoryid, [FromRoute] int page)
        {
            return _categoryService.GetItems(new Guid(categoryid), page);//.Select(x => CreateLinksForItem(x));
        }

        [HttpGet("{categoryid}/items", Name = nameof(GetItemsProperty))]
        public Dictionary<string, string> GetItemsProperty([FromRoute] string categoryid)
        {
            return new Dictionary<string, string>() { { "Samsung", "S300" } };
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Post([FromBody] Category category)
        {
            if (category == null) return BadRequest();
            _categoryService.AddCategory(category);
            return Ok();
        }

        [HttpPost("{categoryid}/items")]
        [Consumes("application/json")]
        public IActionResult PostItem([FromRoute] string categoryid, [FromBody] Item item)
        {
            if (string.IsNullOrEmpty(categoryid) || item == null) return BadRequest();
            _categoryService.AddItem(new Guid(categoryid), item);

            return Ok();
        }

        [HttpPut]
        [Consumes("application/json")]
        public IActionResult Put([FromBody] Category category)
        {
            if (category == null) return BadRequest();

            _categoryService.UpdateCategory(category);
            return Ok();
        }

        [HttpPut("{categoryid}/items")]
        [Consumes("application/json")]
        public IActionResult PutItem([FromBody] Item item)
        {
            if (item == null) return BadRequest();
            _categoryService.UpdateItem(item);

            return Ok();
        }

        [HttpDelete("{categoryid}")]
        public IActionResult Delete([FromRoute] string categoryid)
        {
            if (string.IsNullOrEmpty(categoryid)) return BadRequest();

            _categoryService.DeleteCategory(new Guid(categoryid));

            return Ok();
        }

        [HttpDelete("{categoryid}/items/{itemId}")]
        public IActionResult DeleteItem([FromRoute] string categoryid, [FromRoute] string itemId)
        {
            if (string.IsNullOrEmpty(categoryid) || string.IsNullOrEmpty(itemId)) return BadRequest();

            _categoryService.DeleteItem(new Guid(itemId));

            return Ok();
        }

        //private Category CreateLinksForCategory(Category category)
        //{
        //    var idObj = new { id = category.Id };
        //    category.Links.Add(
        //        new LinkDto(this.urlHelper.Link(nameof(this.Get), idObj),
        //        "self",
        //        "GET"));

        //    category.Links.Add(
        //        new LinkDto(this.urlHelper.Link(nameof(this.Post), idObj),
        //        "post_category",
        //        "POST"));

        //    category.Links.Add(
        //        new LinkDto(this.urlHelper.Link(nameof(this.Put), idObj),
        //        "put_category",
        //        "PUT"));

        //    category.Links.Add(
        //        new LinkDto(this.urlHelper.Link(nameof(this.Delete), idObj),
        //        "delete_category",
        //        "DELETE"));

        //    return category;
        //}

        //private Item CreateLinksForItem(Item category)
        //{
        //    var idObj = new { id = category.Id };
        //    category.Links.Add(
        //        new LinkDto(this.urlHelper.Link(nameof(this.GetItems), idObj),
        //        "self",
        //        "GET"));

        //    category.Links.Add(
        //        new LinkDto(this.urlHelper.Link(nameof(this.PostItem), idObj),
        //        "post_item",
        //        "POST"));

        //    category.Links.Add(
        //        new LinkDto(this.urlHelper.Link(nameof(this.PutItem), idObj),
        //        "put_item",
        //        "PUT"));

        //    category.Links.Add(
        //        new LinkDto(this.urlHelper.Link(nameof(this.DeleteItem), idObj),
        //        "delete_item",
        //        "DELETE"));

        //    return category;
        //}

    }
}
