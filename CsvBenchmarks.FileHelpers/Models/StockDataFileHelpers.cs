using CsvBenchmarks.FileHelpers.Converters;
using FileHelpers;

namespace RegistryParser.Core.Types;

[DelimitedRecord(",")]
public class StockDataFileHelpers
{
    [FieldOrder(0)]
    [FieldConverter(typeof(DateOnlyConverter))]
    public DateOnly? Date { get; set; }
    
    [FieldOrder(1)]
    public decimal? Open { get; set; }
    
    [FieldOrder(2)]
    public decimal? High { get; set; }
    
    [FieldOrder(3)]
    public decimal? Low { get; set; }
    
    [FieldOrder(4)]
    public decimal? Close { get; set; }
    
    [FieldOrder(5)]
    public int? Volume { get; set; }
    
    [FieldOrder(6)]
    public string? Name { get; set; }
}