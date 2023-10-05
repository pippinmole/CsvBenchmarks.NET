using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace CsvBenchmarks.CsvHelper.Converters;

public class DateOnlyConverter : TypeConverter
{
    public override object? ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
    {
        if (string.IsNullOrWhiteSpace(text))
            return null;

        return DateOnly.FromDateTime(DateTime.Parse(text));
    }
}