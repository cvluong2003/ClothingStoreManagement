using API.DataTranferObject;
using Microsoft.AspNetCore.JsonPatch;
namespace API.Model
{
    public interface IProductModel
    {
        public Task<List<ProductDTOGet>> getAllProduct();

        Task<string> getLastID();
        Task<bool> postProduct(ProductsDTOPost proDTO);
        Task<bool> updateQuantityProduct(string ProductId, int quantity);
    }
}
