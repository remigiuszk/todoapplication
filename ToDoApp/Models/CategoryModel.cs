using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class CategoryModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Hashtag { get; set; }
        public DateTime CategoryDate { get; set; }
    }
}
