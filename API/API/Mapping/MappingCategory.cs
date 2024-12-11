using API.Model;
using AutoMapper;
using DAL;
using DAL.DBContext;
using API.DataTranferObject;
namespace API.Mapping
{
    public class MappingCategory:Profile
    {
        public MappingCategory() {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
