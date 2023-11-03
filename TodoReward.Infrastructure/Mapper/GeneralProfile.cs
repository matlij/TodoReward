using AutoMapper;
using TodoReward.Core.Models;
using TodoReward.Infrastructure.Models.ExternalModels;
using TodoReward.Infrastructure.Models.StorageTable;

namespace TodoReward.Infrastructure.Mapper
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<EventData, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Points, opt => opt.MapFrom(src => 1)) // TODO: Set points from todoist data
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.content))
                .ForMember(dest => dest.CompletedDate, opt => opt.MapFrom(src => src.completed_at));

            CreateMap<ExternalTodoItemList, TodoItemList>();
            CreateMap<ExternalTodoItemList, IEnumerable<TodoItem>>()
                .ConvertUsing((src, dest, context) =>
                {
                    var todoItems = context.Mapper.Map<IEnumerable<ExternalTodoItem>, IEnumerable<TodoItem>>(src.Items.ToList());
                    return todoItems;
                });

            CreateMap<ExternalTodoItem, TodoItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TaskId))
                .ForMember(dest => dest.Points, opt => opt.MapFrom(src => 1)) // TODO, set points after prio or something else
                .ForMember(dest => dest.IsCompleted, opt => opt.MapFrom(src => true))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Content));

            CreateMap<UserEntity, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RowKey));
            CreateMap<UserReward, UserRewardEntity>()
                .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.Id));

            CreateMap<User, UserEntity>()
                .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.Id));
            CreateMap<UserReward, UserRewardEntity>()
                .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.Id));
        }
    }
}
