﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Service_BLL
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Image { get; set; }

        public decimal Price { get; set; }

        public int Quontity { get; set; }
    }
}
