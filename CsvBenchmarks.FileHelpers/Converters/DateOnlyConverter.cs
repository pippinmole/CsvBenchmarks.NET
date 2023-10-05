using FileHelpers;

namespace CsvBenchmarks.FileHelpers.Converters;

public class DateOnlyConverter : ConverterBase
{
    public override object StringToField(string from)
    {
        if (string.IsNullOrWhiteSpace(from))
            return null;

        return DateOnly.FromDateTime(DateTime.Parse(from));
    }
}