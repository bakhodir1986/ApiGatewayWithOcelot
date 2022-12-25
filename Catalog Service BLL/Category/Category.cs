namespace Catalog_Service_BLL
{
    public class Category
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public Category()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            //Links = new List<LinkDto>();
        }
        public Guid Id { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("value");
                if (value.Length > 50) throw new ArgumentOutOfRangeException("value");
                _name = value;
            }
        }
        public string Image { get; set; }

        public virtual Category? Parent { get; set; }

        //[NotMapped]
        //public List<LinkDto> Links { get; set; }
    }
}
