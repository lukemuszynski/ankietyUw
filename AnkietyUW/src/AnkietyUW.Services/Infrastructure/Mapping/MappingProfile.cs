﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnkietyUW.Contracts.Przyklad.DataTransferObjects;
using AnkietyUW.Contracts.Przyklad.ViewModels;
using AnkietyUW.Contracts.TestDto.DataTransferObjects;
using AnkietyUW.Contracts.TestDto.ViewModels;
using AnkietyUW.Contracts.UserDto;
using AnkietyUW.DataLayer.Entities;
using AutoMapper;

namespace AnkietyUW.Services.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            Func<List<int>, List<int?>> func = ( x =>
            {
                var l = new List<int?>();
                x.ForEach(e =>
                {      
                    if (e < 0)
                    {
                        l.Add(null);
                    }
                    else
                    {
                        l.Add(e);
                    }
                });
                return l;

            });

            CreateMap<Przyklad, PrzykladViewModel>().ReverseMap();

            CreateMap<AnswerDto, Answer>().ForMember(dst => dst.Answers, opt => opt.MapFrom(src =>  func(src.Answers) ));
            
            CreateMap<Przyklad, CreatePrzykladDto>().ReverseMap();
            CreateMap<Test, CreateTestDto>().ReverseMap();
            CreateMap<Test, AllTestsViewModel>().ReverseMap();
        }
     

    }
}
