namespace CsvBenchmarks.Custom.Converters;

[AttributeUsage(AttributeTargets.Property)]
public class TypeConverterAttribute : Attribute
{
    public Type Type { get; }

    public TypeConverterAttribute(Type type)
    {
        Type = type;
    }
}