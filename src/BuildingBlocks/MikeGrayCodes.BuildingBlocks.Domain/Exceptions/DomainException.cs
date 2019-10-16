namespace MikeGrayCodes.BuildingBlocks.Domain.Exceptions
{
    public class DomainException : BaseException
    {
        public DomainException()
        { }

        public DomainException(string message)
            : base(message)
        { }
    }
}
