namespace DeafoultNamespace;

public class Product : IComparable<Product>
{

    public string Name { get; set; }
    public double MinimalTemperature { get; set; }

    public Product(string name, double minimalTemperature)
    {
        Name = name;
        MinimalTemperature = minimalTemperature;
    }

    public int CompareTo(Product? other)
    {
        return Name.CompareTo(other.Name);
        
    }

    public override string ToString()
    {
        return "Name - " + Name + "   Minimal temp. - " + MinimalTemperature;
    }

    public override bool Equals(object? obj)
    {
        return this.Name.Equals(((Product)obj).Name);
    }
}