using AutoMapper;
using DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using API.DataTranferObject;
namespace API.Model
{
    public class ProductModel:IProductModel
    {
        
        StoreContext _context;
        IMapper _map;
        public ProductModel( StoreContext context, IMapper map)
        {
           
            _context = context;
            _map = map;
        }
        public async Task<List<ProductDTO>> getAllProduct()
        {
            var products = _context.Products.ToListAsync();
            var productsDTO = _map.Map<List<ProductDTO>>(await products);
            return  productsDTO;
        }
        public async Task<bool> postProduct(ProductDTO proDTO)
        {
            var isValidDTO = _context.Products.Where(n => n.ProductId == proDTO.ProductId).FirstOrDefault();
            if(isValidDTO!=null)
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
        public async Task<string> getLastID()
        {
            var lastID = _context.Products.OrderByDescending(n => n.ProductId).Select(m=>m.ProductId).FirstOrDefaultAsync();
            
            return await lastID;
        }
    }
}
