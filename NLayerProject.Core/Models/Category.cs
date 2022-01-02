using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Models
{
    public class Category : BaseClass
    {
        public Category() => Products = new Collection<Product>();

        public string Name { get; set; }

        #region [ Product ]

        public ICollection<Product> Products { get; set; }

        #endregion
    }
}
