namespace payFlow.Application.Exceptions
{
    public class ValidationException : ApplicationExceptionBase
    {
      public ValidationException(string message):base(message, 400)
      {
        }
    }
}
