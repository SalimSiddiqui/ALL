using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel;
namespace BusinessServices
{
    public interface IProductServices
    {
        ProductEntity GetProductById(int productId);
        //IEnumerable<ProductEntity> GetAllProducts();
        IEnumerable<ProductEntity> GetAllProducts();
        int CreateProduct(ProductEntity productEntity);
        bool UpdateProduct(int productId, ProductEntity productEntity);
        bool DeleteProduct(int productId);
    }
}
