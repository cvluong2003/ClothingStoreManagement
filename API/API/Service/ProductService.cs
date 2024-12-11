using API.DataTranferObject;
using API.Model;

namespace API.Service
{
    public class ProductService:IProductService
    {
        IProductModel _productModel;

        public ProductService(IProductModel productModel) { 
            _productModel = productModel;
        }
        public async Task<List<ProductDTO>> getAllProduct()
        {
            return await _productModel.getAllProduct();
        }
         public async Task<bool> postProduct(ProductDTO proDTO)
        {
            proDTO.ProductId = await createNewID();
            return await _productModel.postProduct(proDTO);
        }
        public async Task<string> createNewID()
        {
            var lastID =await _productModel.getLastID();
            string preFix = lastID.Substring(0, 1);
            string lastFix = lastID.Substring(1);
            int lastFixNumber = int.Parse(lastFix)+1;
            string newLastFix = lastFixNumber.ToString().PadLeft(3, '0');
            string newID = string.Concat(preFix, newLastFix);
            return newID;
        }
    }
}
