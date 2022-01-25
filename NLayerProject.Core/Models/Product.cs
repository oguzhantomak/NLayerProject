using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Models
{
    public class Product : BaseClass
    {
        public string Name { get; set; }

        public int Stock { get; set; }

        public decimal Price { get; set; }

        public string? Barcode { get; set; }

        #region [ Category ]

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } 

        #endregion
    }
}
