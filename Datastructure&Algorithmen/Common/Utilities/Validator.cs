namespace Common.Utilities
{
    public class Validator
    {
        public static void ValidateString(string value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be null or empty.", paramName);
            }
        }
        public static void ValidateEnumValue<T>(T value, string paramName) where T : Enum
        {
            if (!Enum.IsDefined(typeof(T), value))
                throw new ArgumentOutOfRangeException(paramName, $"{value} is not a valid value for {typeof(T).Name}.");
        }
        public static ArgumentException? ValidateEnumValueReturnException<T>(T? value, string paramName) where T : struct, Enum
        {
            if (!value.HasValue)
                return new ArgumentNullException(paramName, $"{paramName} is required.");
            if (!Enum.IsDefined(typeof(T), value.Value))
                return new ArgumentOutOfRangeException(paramName, $"{value.Value} is not a valid value for {typeof(T).Name}.");
            return null;
        }
    }
}
