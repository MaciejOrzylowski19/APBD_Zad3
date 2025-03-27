namespace DeafoultNamespace;

public class Product
{

    public string Name { get; set; }
    public double MinimalTemperature { get; set; }

    public Product(string name, double minimalTemperature)
    {
        Name = name;
        MinimalTemperature = minimalTemperature;
    }
    
    
}