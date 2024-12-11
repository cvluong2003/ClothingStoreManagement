using API.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.DataTranferObject;
using Microsoft.AspNetCore.JsonPatch;
using Azure;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            var listProduct = await _productService.getAllProduct();
            return Ok( listProduct);
        }
        [HttpPost]
        public async Task<ActionResult> PostProduct([FromBody] ProductsDTOPost proDTO)
        {
            bool result=await _productService.postProduct(proDTO);
            if (result)
            {
                return Ok( proDTO );
            }
            else
            {
                return BadRequest("Input is invalid");
            }
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> PatchQiantityProduct(int id,[FromBody] int quantity)
        {
            
           bool rs=await _productService.updateQuantityProduct(id.ToString(),quantity);
           if (rs)
           {
                return NoContent();
           }
           else{
                if(!ModelState.IsValid)
                {
                    return BadRequest("Model is invalid");

                }
                return NotFound();
           }
        }
    }
}
