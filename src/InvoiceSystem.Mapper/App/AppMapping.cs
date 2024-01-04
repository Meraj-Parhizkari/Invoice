using AutoMapper;
//using InvoiceSystem.Entities.Cars;
using InvoiceSystem.Entities.App;
using InvoiceSystem.Entities.Identity;
using InvoiceSystem.ViewModels.Car;
using InvoiceSystem.ViewModels.App;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceSystem.Mapper
{
    public class AppMapping : Profile
    {
        public AppMapping()
        {


            //#region CarF
            //CreateMap<BaseCar, BaseCarViewModel>()
            //    .ForMember(dest => dest.HasChildren, o => o.MapFrom(src => src.Children != null ? src.Children.Count > 0 : false))
            //    .ReverseMap();
            //#endregion

            #region Post
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.PostGroupsIds, o => o.MapFrom(src => src.PostPostGroups != null ? src.PostPostGroups.Select(x => x.PostGroupId).ToList() : new List<int>()))
                .ReverseMap();
            #endregion

            #region PostGroup
            CreateMap<PostGroup, PostGroupViewModel>()
                .ReverseMap();
            #endregion


        }
    }
}
