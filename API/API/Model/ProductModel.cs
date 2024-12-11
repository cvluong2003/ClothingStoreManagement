using AutoMapper;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using API.DataTranferObject;
using Microsoft.AspNetCore.JsonPatch;
namespace API.Model
{
    public class ProductModel : IProductModel
    {

        StoreContext _context;
        IMapper _map;
        public ProductModel(StoreContext context, IMapper map)
        {

            _context = context;
            _map = map;
        }
        public async Task<List<ProductDTOGet>> getAllProduct()
        {
            var products = _context.Products.ToListAsync();
            var productsDTO = _map.Map<List<ProductDTOGet>>(await products);
            return productsDTO;
        }
        public async Task<bool> postProduct(ProductsDTOPost proDTO)
        {
            var isValidDTO = _context.Products.Where(n => n.ProductId == proDTO.ProductId).FirstOrDefault();
            if (isValidDTO != null)
            {
                return false;
            }
            else
            {
                try
                {
                    var productEntity = _map.Map<Product>(proDTO);
                    await _context.Products.AddAsync(productEntity);
                    _context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }
        public async Task<bool> updateQuantityProduct(string ProductId, int docQuantity)
        {
            
            var isValid = _context.Products.Where(n => n.ProductId == ProductId).FirstOrDefaultAsync();

            if (isValid == null)
            { 
                return false;
            }
            else
            {
                try
                {
                    var product = await isValid;
                    // var productDTOMapped = _map.Map<ProductsDTOPost>(product);
                    
                    
                    product.Quantity+=docQuantity;
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }

            }
        }
        public async Task<string> getLastID()
        {
            var lastID = _context.Products.OrderByDescending(n => n.ProductId).Select(m => m.ProductId).FirstOrDefaultAsync();

            return await lastID;
        }
    }
}
