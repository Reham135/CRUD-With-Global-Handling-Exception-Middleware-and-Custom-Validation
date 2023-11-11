using GoodsMart.Bl;
using GoodsMart.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodsMart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }



        #region Get all Products
        [HttpGet]
        public ActionResult<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            IEnumerable<ProductReadDto>? Products = _productManager.GetAllProducts();
            return Ok(Products);
        }

        #endregion

        #region Get all Products In Pagination
        [HttpGet]
        [Route("{page}/{countPerPage}")]
        public ActionResult<ProductPaginationDto> GetAllWithPAgination(int page, int countPerPage)
        {
            ProductPaginationDto Products = _productManager.GetAllWithPAgination(page, countPerPage);
            return Ok(Products);
        }

        #endregion

        #region Get By ID
        [HttpGet]
        [Route("{id}")]
        public ActionResult<ProductDetailsDto> GetProductByID(int id)
        {
            ProductDetailsDto? product = _productManager.GetByID(id);
            return Ok(product);
        }
        #endregion

        #region Add Product
        [HttpPost]
        public ActionResult AddProduct(ProductAddDto product)
        {
            _productManager.AddProduct(product);
            var response = new { message = "Product has been Added Successfully" };
            return Ok(response);
        }
        #endregion

        #region edit Product
        [HttpPut]
        public ActionResult UpdateProduct(ProductEditDto product)
        {
            _productManager.updateProduct(product);
            var response = new { message = "Product has been updated Successfully" }; 
            return Ok(response);
        }
        #endregion

        #region Delete Product
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteProduct(int id )
        { 
          _productManager.DeleteProduct(id);
            var response = new { message = "Product has been Deleted Successfully" };
            return Ok(response);
        }
        #endregion
    }
}
