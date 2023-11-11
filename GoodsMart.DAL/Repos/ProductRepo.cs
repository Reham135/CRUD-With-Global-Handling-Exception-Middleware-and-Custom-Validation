using GoodsMart.DAL.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsMart.DAL;

public class ProductRepo : IProductRepo
{
    private readonly GoodsMartContext _context;

    public ProductRepo(GoodsMartContext context)
    {
        _context = context;
    }
    public IEnumerable<Product> GetAll()
    {
        return _context.Products.AsNoTracking();
    }


    public IEnumerable<Product> GetAllWithPAgination(int page, int countPerPage)
    {
        return _context.Products.AsNoTracking()
            .Skip((page - 1) * countPerPage)
            .Take(countPerPage); ;
    }
    public int GetCount()
    {
        return _context.Products.Count();
    }

    public Product? GetById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
    }

    public void update(Product product)
    {
       //_context.Products.Update(product);
    }

    public void DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}
