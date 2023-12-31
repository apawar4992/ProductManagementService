using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<SubCategory> subCategories { get; set; }
    }
}
