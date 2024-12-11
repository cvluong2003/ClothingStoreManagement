using API.DataTranferObject;

namespace API.Model
{
    public interface IProductModel
    {
        public Task<List<ProductDTO>> getAllProduct();
        Task<bool> postProduct(ProductDTO proDTO);
        Task<string> getLastID();
    }
}
