namespace payFlow.Core.Commons.ExceptionsMessage
{
    public static class CategoryExceptionMessage
    {

        public static readonly Func<string, string> FieldNullExceptionMessage = (string fildName) => $"{fildName} não deve ser vazio ou nulo";
        public static readonly Func<string, int, string> FieldMaxLengthException = (string fildName, int maxLength) => $"{fildName} não deve ter mais que {maxLength} caracteres";
        public static readonly Func<string, int, string> FieldMinLengthException = (string fildName, int minLength) => $"{fildName} deve ter um tamanho minínimo de {minLength} caracteres";


    }
}
