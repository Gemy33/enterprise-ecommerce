using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace enterpriseecommerce.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery
{
        public int ProductId { get; set; }
        public string ProductName { get; set; } = "";
        public string ProductDescription { get; set; } = "";
        public decimal ProductPrice { get; set; }
        public decimal ProductQuantity { get; set; }


    }
}
