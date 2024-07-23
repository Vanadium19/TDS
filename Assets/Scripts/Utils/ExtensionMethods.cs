namespace Utils
{
    public static class ExtensionMethods
    {
        public static bool IsBetween(this float value, float minValue, float maxValue)
        {
            return value > minValue && value < maxValue;
        }
    }
}