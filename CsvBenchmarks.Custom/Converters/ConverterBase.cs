namespace CsvBenchmarks.Custom.Converters;

public abstract class ConverterBase<T> where T : new()
{
    public abstract T? ConvertFromString(string? text);
}