using CsvBenchmarks.CsvHelper.Converters;
using CsvHelper.Configuration.Attributes;

namespace RegistryParser.Core.Types;

public class StockDataCsvHelper
{
    [Index(0)]
    [TypeConverter(typeof(DateOnlyConverter))]
    public DateOnly? Date { get; set; }
    
    [Index(1)]
    public decimal? Open { get; set; }
    
    [Index(2)]
    public decimal? High { get; set; }
    
    [Index(3)]
    public decimal? Low { get; set; }
    
    [Index(4)]
    public decimal? Close { get; set; }
    
    [Index(5)]
    public int? Volume { get; set; }
    
    [Index(6)]
    public string? Name { get; set; }
}
