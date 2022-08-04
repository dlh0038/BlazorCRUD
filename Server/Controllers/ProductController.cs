using BlazorCRUD.Server.Models;
using BlazorCRUD.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ApplicationDBContext _userContext;
        public ProductController(ApplicationDBContext userContext)
        {
            _userContext =userContext;
        }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _userContext.Products.ToListAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Product product)
    {
        _userContext.Add(product);
        await _userContext.SaveChangesAsync();
        return Ok(product.Name); 
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = new Product { Id = id };
        _userContext.Remove(product);
        await _userContext.SaveChangesAsync();
        return NoContent();
    }

/* old probably incorrect controllers
        // GET api/user
        [HttpGet("")]
        public ActionResult<List<Product>> Getstrings()
        {
            return _userContext.Product.ToList();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<Product> GetstringById(int id)
        {
            return _userContext.Product.FirstOrDefault(product => product.Id == id);
        }

        // POST api/user
        [HttpPost("")]
        public ActionResult<User> Poststring(Product product)
        {
            _userContext.Product.Add(product);
            _userContext.SaveChanges();
            return product;
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public ActionResult<User> Putstring(int id, Product product)
        {
            Product newProduct = _userContext.Products.FirstOrDefault(product => product.Id ==id);
            newProduct.Name = product.Name;
            newProduct.Price = product.Price;
            newProduct.Description = product.Description;
            newProduct.Quantity = product.Quantity;
            _userContext.SaveChanges();
            return newProduct;

        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id)
        {
            Product oldProduct = _userContext.Products.FirstOrDefault(product => product.Id == id);
            _userContext.Products.Remove(oldProduct);
            _userContext.SaveChanges();
        } */
    }
}
