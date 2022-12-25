namespace Catalog_Service_BLL
{
    public class Item
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Item()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            //Links = new List<LinkDto>();
        }
        public Guid Id { get; set; }
        public string Name
        {
            get { return Name; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("value");
                if (value.Length > 50) throw new ArgumentOutOfRangeException("value");
                Name = value;
            }
        }
        public string Description { get; set; }
        public string Image { get; set; }

        public Guid CategoryId { get; set; }
        public virtual Category Category
        {
            get { return Category; }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                Category = value;
            }
        }

        public decimal Price
        {
            get { return Price; }
            set
            {
                if (Price <= 0) throw new ArgumentOutOfRangeException("price");

                Price = value;
            }
        }

        public uint Amount { get; set; }

        //[NotMapped]
        // public List<LinkDto> Links { get; set; }
    }
}
