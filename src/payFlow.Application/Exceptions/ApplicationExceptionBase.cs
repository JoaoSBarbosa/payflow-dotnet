namespace payFlow.Application.Exceptions
{
    public class ApplicationExceptionBase: Exception
    {
        public int Code { get; set; }

        protected ApplicationExceptionBase(string message, int code) : base(message)
        {
            Code = code;
        }

    }
}
