namespace TodoReward.Infrastructure.Models.ExternalModels
{
    public class ExternalProject
    {
        public int ChildOrder { get; set; }
        public bool Collapsed { get; set; }
        public string Color { get; set; }
        public string Id { get; set; }
        public bool IsArchived { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsFavorite { get; set; }
        public string Name { get; set; }
        public object ParentId { get; set; }
        public bool Shared { get; set; }
        public object SyncId { get; set; }
        public string ViewStyle { get; set; }
    }
}
