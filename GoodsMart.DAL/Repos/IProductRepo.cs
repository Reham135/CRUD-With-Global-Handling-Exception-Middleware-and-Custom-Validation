using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsMart.DAL;

public interface IProductRepo
{
    void Add(Product product);
    IEnumerable<Product> GetAll();
    Product? GetById(int id);
    void update(Product product);
    void DeleteProduct(Product product);
    int SaveChanges();


    IEnumerable<Product> GetAllWithPAgination(int page, int countPerPage);
    int GetCount();
}
