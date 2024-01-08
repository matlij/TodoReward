using AutoMapper;
using TodoReward.Core.Extensions;
using TodoReward.Core.Models;
using TodoReward.Infrastructure.Models.ExternalModels;
using TodoReward.Infrastructure.Models.StorageTable;

namespace TodoReward.Infrastructure.Mapper;

public class GeneralProfile : Profile
{
    public GeneralProfile()
    {
        // Todoist to Core
        CreateMap<TodoistEventData, TodoItem>()
            //.ForMember(dest => dest.Points, opt => opt.MapFrom(src => 1)) // TODO: Set points from todoist data
            .ForMember(dest => dest.CompletedDate, opt => opt.MapFrom(src =>  src.CompletedAt.ToDateTime()));

        CreateMap<TodoistTodoItemList, TodoItemList>();
        CreateMap<TodoistTodoItemList, IEnumerable<Core.Models.TodoItem>>()
            .ConvertUsing((src, dest, context) =>
            {
                var todoItems = context.Mapper.Map<IEnumerable<TodoistCreateTask>, IEnumerable<Core.Models.TodoItem>>(src.Items.ToList());
                return todoItems;
            });

        CreateMap<TodoistTask, TodoItem>();
        //.ForMember(dest => dest.Points, opt => opt.MapFrom(src => 1)); // TODO, set points after prio or something else

        // Core to Todoist
        CreateMap<TodoItem, TodoistCreateTask>();

        // Core to Storage table entity
        CreateMap<TodoItem, TodoItemEntity>()
            .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.Id));
        CreateMap<UserReward, UserRewardEntity>()
            .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.Id));

        CreateMap<User, UserEntity>()
            .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.Id));
        CreateMap<UserReward, UserRewardEntity>()
            .ForMember(dest => dest.RowKey, opt => opt.MapFrom(src => src.Id));

        // Storage table entity to Core
        CreateMap<UserEntity, User>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RowKey));
    }
}
