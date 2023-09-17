﻿using TodoReward.Core.Models;

namespace TodoReward.Core.Interfaces
{
    public interface IRewardService
    {
        Task<TodoItemCompleteResult?> GetRewardAsync(TodoItem item);
    }
}
