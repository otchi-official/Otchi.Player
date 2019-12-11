namespace Otchi.Ebml.Types
{
    public struct ReadOperation<T>
    {
        public long Position { get; }
        public T Value { get; }

        public ReadOperation(long position, T value)
        {
            Position = position;
            Value = value;
        }
    }
}