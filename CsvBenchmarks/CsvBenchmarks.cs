using System.Globalization;
using BenchmarkDotNet.Attributes;
using CsvBenchmarks.Custom;
using CsvBenchmarks.Custom.Models;
using CsvHelper;
using FileHelpers;
using RegistryParser.Core.Types;

namespace CsvBenchmarks;

[MarkdownExporter]
[MemoryDiagnoser(false)]
public class CsvBenchmarks
{
    private string _content = null!;

    [Params(1, 100, 1000, 10_000, 50_000, 150_000, 500_000)]
    public int Rows { get; set; }
    
    private readonly FileHelperEngine<StockDataFileHelpers> _fileHelperEngine = new() { Options = { IgnoreFirstLines = 1 } };
    
    [GlobalSetup]
    public void Setup()
    {
        var allLines = File.ReadAllLines("all_stocks_5y.csv");
        if (allLines.Length < Rows + 1) // +1 for the header
            throw new InvalidOperationException($"The file does not have enough rows: {Rows + 1}");

        _content = string.Join(Environment.NewLine, allLines.Take(Rows + 1)); // +1 for the header
    }

    [Benchmark]
    public StockDataFileHelpers[] Filehelpers()
    {
        var engine = new FileHelperEngine<StockDataFileHelpers> { Options = { IgnoreFirstLines = 1 } };
        return engine.ReadString(_content);
    }

    [Benchmark]
    public StockDataFileHelpers[] FileHelpers_CacheEngine() => _fileHelperEngine.ReadString(_content);

    [Benchmark]
    public StockDataCsvHelper[] CsvHelper()
    {
        using var stringReader = new StringReader(_content);
        using var reader = new CsvReader(stringReader, CultureInfo.InvariantCulture);
        return reader.GetRecords<StockDataCsvHelper>().ToArray();
    }

    // private readonly CustomCsvParser<StockDataCustom> _customCsvParser = new(true);
    
    // [Benchmark]
    // public StockDataCustom[] Custom()
    // {
    //     var customCsvParser = new CustomCsvParser<StockDataCustom>(true);
    //     return customCsvParser.ReadString(_content).ToArray();
    // }
    //
    // [Benchmark]
    // public StockDataCustom[] Custom_CacheEngine()
    // {
    //     return _customCsvParser.ReadString(_content).ToArray();
    // }
}