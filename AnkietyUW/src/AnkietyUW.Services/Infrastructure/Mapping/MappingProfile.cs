using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnkietyUW.Contracts.AnswerDto.DataTransferObjects;
using AnkietyUW.Contracts.TestDto.DataTransferObjects;
using AnkietyUW.Contracts.TestDto.ViewModels;
using AnkietyUW.Contracts.UsersDto;
using AnkietyUW.DataLayer.Entities;
using AutoMapper;

namespace AnkietyUW.Services.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {

            Func<List<int?>, List<int?>> func = ( x =>
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
            
            //CreateMap<AnswerDto, Answer>().ReverseMap();
            CreateMap<AnswerDto, Answer>().ForMember(dst => dst.Answers, opt => opt.MapFrom(src => func(src.Answers) )).ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Test, CreateTestDto>().ReverseMap();
            CreateMap<Test, TestViewModel>().ReverseMap();

            CreateMap<TestTime, TestTimeDto>().ReverseMap();

            CreateMap<User, AddSingleUserDto>().ReverseMap();
            
            CreateMap<Test, UpdateTestDto>().ReverseMap();

            CreateMap<Test, TestWithTestTimesViewModel>().ReverseMap();

        }
    }
}
