using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsMart.Bl;

public interface IProductManager
{
    IEnumerable<ProductReadDto>? GetAllProducts();
    ProductPaginationDto GetAllWithPAgination(int page, int countPerPage);  //with pagination 
    ProductDetailsDto? GetByID(int id);
    void AddProduct(ProductAddDto product);
    void updateProduct(ProductEditDto product);
    void DeleteProduct(int id);
}
