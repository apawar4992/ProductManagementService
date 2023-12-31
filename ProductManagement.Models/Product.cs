using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class Product
    {
        public string ProductCode { get; set; }

        public string Name { get; set; }

        public int? Quantity { get; set; }

        public int? Price { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
