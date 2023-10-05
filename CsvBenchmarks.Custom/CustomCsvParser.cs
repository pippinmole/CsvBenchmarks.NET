using System.Reflection;

namespace CsvBenchmarks.Custom;

public class CustomCsvParser<T> where T : class, new()
{
    private readonly bool _hasHeader;

    internal record PropertyConverter(PropertyInfo Property, Type? Converter);

    private readonly PropertyConverter[] _properties = GetConverters();

    public CustomCsvParser(bool hasHeader)
    {
        _hasHeader = hasHeader;
    }
    
    private static PropertyConverter[] GetConverters()
    {
        var type = typeof(T);
        var properties = type.GetProperties();
        var converters = new List<PropertyConverter>();
        
        foreach (var property in properties)
        {
            var converter = property.GetCustomAttribute<Converters.TypeConverterAttribute>();
            if (converter is not null)
            {
                converters.Add(new PropertyConverter(property, converter.Type));
            }
        }

        return converters.ToArray();
    }

    public IEnumerable<T> ReadString(string content)
    {
        using var stringReader = new StringReader(content);
        
        if (_hasHeader)
        {
            stringReader.ReadLine();
        }
        
        while (stringReader.ReadLine() is { } line)
        {
            var result = new T();
            var values = line.Split(',');
            for (var i = 0; i < _properties.Length; i++)
            {
                var (propertyInfo, converter) = _properties[i];
                var value = values[i];

                if(converter is null)
                {
                    propertyInfo.SetValue(result, value);
                }
                else
                {
                    var converterInstance = Activator.CreateInstance(converter)!;
                    var converted = converterInstance.GetType().GetMethod("ConvertFromString")!.Invoke(converterInstance, new object[] {value});
                    propertyInfo.SetValue(result, converted);
                }
            }
            
            yield return result;
        }
    }
}