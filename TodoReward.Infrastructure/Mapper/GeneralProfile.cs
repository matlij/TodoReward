using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoReward.Core.Models;
using TodoReward.Infrastructure.Repositories;

namespace TodoReward.Infrastructure.Mapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<ExternalTodoItem, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TaskId))
                .ForMember(dest => dest.Points, opt => opt.MapFrom(src => 1)) // TODO, set points after prio or something else
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Content));
        }
    }
}
