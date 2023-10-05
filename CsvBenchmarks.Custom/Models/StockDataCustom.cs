using System.ComponentModel;
using CsvBenchmarks.Custom.Attributes;
using DateOnlyConverter = CsvBenchmarks.Custom.Converters.DateOnlyConverter;

namespace CsvBenchmarks.Custom.Models;

public class StockDataCustom
{
    [CustomOrder(0)]
    [Converters.TypeConverter(typeof(DateOnlyConverter))]
    public DateOnly? Date { get; set; }

    [CustomOrder(1)]
    public string? Open { get; set; }

    [CustomOrder(2)]
    public string? High { get; set; }

    [CustomOrder(3)]
    public string? Low { get; set; }

    [CustomOrder(4)]
    public string? Close { get; set; }

    [CustomOrder(5)]
    public string? Volume { get; set; }

    [CustomOrder(6)]
    public string? Name { get; set; }
}