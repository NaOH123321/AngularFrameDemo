using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SampleAngular.Core.Entities;
using SampleAngular.Infrastructure.Database;
using SampleAngular.Infrastructure.Resources.Stocks;

namespace SampleAngular.App.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //_myContext = myContext;
            //CreateMap<Sample, SampleResource>()
            //    .ForMember(dest => dest.UpdateTime, opt => opt.MapFrom(src => src.LastModified));
            //CreateMap<SampleResource, Sample>();
            //CreateMap<SampleAddResource, Sample>();
            //CreateMap<SampleUpdateResource, Sample>();
            CreateMap<Stock, StockResource>()
                .ForMember(dest => dest.Categories,
                    opt => opt.ResolveUsing(src =>
                        {
                            var list = new List<string>();
                            foreach (var stockCategory in src.StockCategories)
                            {
                                list.Add(stockCategory.Category.Name);
                            }

                            return list.ToArray();
                        }
                    )
                );
            CreateMap<StockResource, Stock>();
        }
    }
}