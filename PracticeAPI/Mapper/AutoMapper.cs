using AutoMapper;
using PracticeAPI.Entity;
using PracticeAPI.Model;

namespace PracticeAPI.Mapper
{
    public class AutoMapper: Profile
    {
        public AutoMapper()
        {
            CreateMap<UserEntity, UserLogin>().ReverseMap();
            CreateMap<TypeEntity, TypeModel>().ReverseMap();
            CreateMap<ProductEntity,ProductModel>().ReverseMap();
            CreateMap<UserEntity,UserLogin>().ReverseMap();
            CreateMap<UserEntity,SignUp>().ReverseMap();
        }
    }
}
