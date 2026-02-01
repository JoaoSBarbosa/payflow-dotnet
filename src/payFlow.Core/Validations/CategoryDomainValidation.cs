using payFlow.Core.Commons.ExceptionsMessage;
using payFlow.Core.Exceptions;

namespace payFlow.Core.Validations
{
    public class CategoryDomainValidation
    {
        public static void NotNullOrEmpty(string? target, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(target)) throw new DomainException(CategoryExceptionMessage.FieldNullExceptionMessage(fieldName));
            
        }

        public static void MaxLength(string target, int maxLength, string fieldName)
        {
            if (target.Length > maxLength) throw new DomainException(CategoryExceptionMessage.FieldMaxLengthException(fieldName, maxLength));
        }

        public static void MinLength(string target, int minLength, string fieldName)
        {
            if (target.Length < minLength) throw new DomainException(CategoryExceptionMessage.FieldMinLengthException(fieldName, minLength));
        }
    }
}
