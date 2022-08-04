using BlazorCRUD.Server.Models;
using BlazorCRUD.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Services{
public class ProductServices
{
    #region Private members
    private ApplicationDBContext dbContext;
    #endregion

    #region Constructor
    public ProductServices(ApplicationDBContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Public methods
    /// <summary>
    /// This method returns the list of product
    /// </summary>
    /// <returns></returns>
    public async Task<List<Product>> GetProductAsync()
    {
        return await dbContext.Products.ToListAsync();
    }

    /// <summary>
    /// This method add a new product to the DbContext and saves it
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public async Task<Product> AddProductAsync(Product product)
    {
        try
        {
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        return product;
    }

    /// <summary>
    /// This method update and existing product and saves the changes
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public async Task<Product> UpdateProductAsync(Product product)
    {
        try
        {
            var productExist = dbContext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (productExist != null)
            {
                dbContext.Update(product);
                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception)
        {
            throw;
        }
        return product;
    }

    /// <summary>
    /// This method removes and existing product from the DbContext and saves it
    /// </summary>
    /// <param name="product"></param>
    /// <returns></returns>
    public async Task DeleteProductAsync(Product product)
    {
        try
        {
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
}
}