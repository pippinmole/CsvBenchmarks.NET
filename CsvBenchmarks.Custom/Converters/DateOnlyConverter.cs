namespace CsvBenchmarks.Custom.Converters;

public class DateOnlyConverter : ConverterBase<DateOnly>
{
    public override DateOnly ConvertFromString(string? text)
    {
        return string.IsNullOrWhiteSpace(text) ? default : DateOnly.FromDateTime(DateTime.Parse(text));
    }
}