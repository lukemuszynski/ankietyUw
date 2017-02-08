using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnkietyUW.Contracts.Przyklad.DataTransferObjects;
using AnkietyUW.Contracts.Przyklad.ViewModels;
using AnkietyUW.Contracts.TestDto.DataTransferObjects;
using AnkietyUW.Contracts.TestDto.ViewModels;
using AnkietyUW.DataLayer.Entities;
using AutoMapper;

namespace AnkietyUW.Services.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Przyklad, PrzykladViewModel>().ReverseMap();
            CreateMap<Przyklad, CreatePrzykladDto>().ReverseMap();
            CreateMap<Test, CreateTestDto>().ReverseMap();
            // CreateMap<CreateTestDto,Test>().ForMember(dst => dst.Id, opt=>opt.MapFrom(src => src.ThirdQuestionAddSeconds + 1000));
            CreateMap<Test, AllTestsViewModel>().ReverseMap();
        }
     

    }
}
