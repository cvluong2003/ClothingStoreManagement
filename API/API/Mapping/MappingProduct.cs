﻿using API.Model;
using AutoMapper;
using DAL;
using DAL.DBContext;
using API.DataTranferObject;
namespace API.Mapping
{
    public class MappingProduct:Profile
    {
        public MappingProduct() {
            CreateMap<Product, ProductDTO>().ForMember(dest => dest.Status, opt => opt.MapFrom((src, dest) => src.SellStatus == true ? "Còn hàng" : "Hết hàng"));
            CreateMap<ProductDTO, Product>().ForMember(dest => dest.SellStatus, opt => opt.MapFrom((src, dest) => src.Status.CompareTo("Còn hàng")==0 ? true : false));
        }
    }
}
