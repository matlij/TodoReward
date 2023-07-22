namespace TodoReward.Core.Models
{
    public class Reward : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        private int _propability;
        public int Propability
        {
            get { return _propability; }
            set 
            {
                if (value <= 0 || value > 1000)
                    throw new ArgumentException($"Value of {nameof(Propability)} must be between 1 and 1000");

                _propability = value; 
            }
        }
    }
}
