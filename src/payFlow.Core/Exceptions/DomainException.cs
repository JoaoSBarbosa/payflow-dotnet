namespace payFlow.Core.Exceptions
{
    public class DomainException: Exception
    {
        public DomainException(string mensage): base(mensage)
        {
        }
    }
}
