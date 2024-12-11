using API.Model;
using AutoMapper;
using DAL;
using DAL.DBContext;
using API.DataTranferObject;
namespace API.Mapping
{
    public class MappingProduct:Profile
    {
        public MappingProduct() {
            CreateMap<Product, ProductsDTOPost>();//.ForMember(dest => dest.Status, opt => opt.MapFrom((src, dest) => src.SellStatus == true ? "Còn hàng" : "Hết hàng"));
            CreateMap<ProductsDTOPost, Product>();//.ForMember(dest => dest.SellStatus, opt => opt.MapFrom((src, dest) => src.Status.CompareTo("Còn hàng")==0 ? true : false));
            CreateMap<Product,ProductDTOGet>().ForMember(dest => dest.Status,opt=>opt.MapFrom((src, dest)=>  src.SellStatus == true ? "Còn hàng" : "Hết hàng"));
        }
    }
}
