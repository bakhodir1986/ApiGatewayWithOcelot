using Catalog_Service_Rest_Api.HATEOAS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog_Service_BLL
{
    public class Category
    {
        public Category()
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
