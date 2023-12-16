using TodoReward.Core.Models;

namespace TodoReward.Infrastructure.Models.ExternalModels
{
    public class DueDto
    {
        public string date { get; set; }
        public bool is_recurring { get; set; }
        public DateTime datetime { get; set; }
        public string @string { get; set; }
        public string timezone { get; set; }
    }

    public class CreateTaskDto
    {
        public string creator_id { get; set; }
        public DateTime created_at { get; set; }
        public object assignee_id { get; set; }
        public object assigner_id { get; set; }
        public int comment_count { get; set; }
        public bool is_completed { get; set; }
        public string content { get; set; }
        public string description { get; set; }
        public DueDto due { get; set; }
        public object duration { get; set; }
        public string id { get; set; }
        public List<object> labels { get; set; }
        public int order { get; set; }
        public int priority { get; set; }
        public string project_id { get; set; }
        public object section_id { get; set; }
        public object parent_id { get; set; }
        public string url { get; set; }
    }

    public class ExternalTodoItemList
    {
        public IEnumerable<ExternalTodoItem> Items { get; set; } = new List<ExternalTodoItem>();
        public Dictionary<string, ExternalProject> Projects { get; set; } = new Dictionary<string, ExternalProject>();
        public Dictionary<string, ExternalSectionDto> Sections { get; set; } = new Dictionary<string, ExternalSectionDto>();
    }

    public class TodoItemList : BaseEntity
    {
        public List<TodoItem> Items { get; set; } = new List<TodoItem>();
    }

    public class EventData
    {
        public string added_at { get; set; }
        public string added_by_uid { get; set; }
        public object assigned_by_uid { get; set; }
        public bool @checked { get; set; }
        public int child_order { get; set; }
        public bool collapsed { get; set; }
        public string completed_at { get; set; }
        public string content { get; set; }
        public string description { get; set; }
        public DueDto due { get; set; }
        public object duration { get; set; }
        public string id { get; set; }
        public bool is_deleted { get; set; }
        public List<object> labels { get; set; }
        public object parent_id { get; set; }
        public int priority { get; set; }
        public string project_id { get; set; }
        public object responsible_uid { get; set; }
        public object section_id { get; set; }
        public object sync_id { get; set; }
        public string updated_at { get; set; }
        public string url { get; set; }
        public string user_id { get; set; }
    }

    public class Initiator
    {
        public string email { get; set; }
        public string full_name { get; set; }
        public string id { get; set; }
        public string image_id { get; set; }
        public bool is_premium { get; set; }
    }

    public class TodoistPushNotification
    {
        public EventData event_data { get; set; }
        public string event_name { get; set; }
        public Initiator initiator { get; set; }
        public string user_id { get; set; }
        public string version { get; set; }
    }
}
