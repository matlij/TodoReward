namespace TodoReward.Core
{
    public class CustomMapperException<Torg, Tdest> : Exception
    {
        public CustomMapperException(object sourceValue)
            : base($"Failed to parse value {sourceValue} of type {typeof(Torg)} to type {typeof(Tdest)}")
        {
        }
    }
}
