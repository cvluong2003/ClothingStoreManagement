using API.DataTranferObject;
namespace API.Service
{
    public interface IProductService
    {
        Task<List<ProductDTO>> getAllProduct();
        Task<bool> postProduct(ProductDTO proDTO);
    }
}
