using API.DataTranferObject;
using Microsoft.AspNetCore.JsonPatch;


namespace API.Service
{
    public interface IProductService
    {
        Task<List<ProductDTOGet>> getAllProduct();
        Task<bool> postProduct(ProductsDTOPost proDTO);
         Task<bool> updateQuantityProduct(string ProductId,int quantity);
    }
    
}
