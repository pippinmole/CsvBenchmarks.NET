namespace CsvBenchmarks.Custom.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class CustomOrderAttribute : Attribute
{
    public int Order { get; }

    public CustomOrderAttribute(int order)
    {
        Order = order;
    }
}