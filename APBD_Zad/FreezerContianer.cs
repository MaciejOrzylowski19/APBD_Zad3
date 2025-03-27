namespace DeafoultNamespace;

public class FreezerContainer : Container
{

    private static int _seriaNumber = 0;
    
    public Dictionary<Product, int> Products { get; set; }
    public SortedSet<Product> PossibleProducts { get; set;}

    public double Temperature
    {
        get
        {
            return Temperature;
        }
        set
        {
            double minimalTemp = 10000;
            foreach (Product product in Products.Keys)
            {
                if (product.MinimalTemperature < minimalTemp)
                {
                    minimalTemp = product.MinimalTemperature;
                }   
            }

            if (Temperature > minimalTemp)
            {
                throw new TooHighTemperatureException();
            }
            ;
        }
    }

    public override int NextSerialNumber()
    {
        return ++_seriaNumber;
    }

    public override ContainerId CreateContainerID()
    {
        return new ContainerId(NextSerialNumber(), "F");
    }


    public FreezerContainer(int emptyMass, int height, int depth, SortedSet<Product> possibleProducts, double temperature)
        : base(emptyMass, height, depth)
    {
        this.PossibleProducts = possibleProducts;
    }
    
    public void LoadProduct(string productName, int mass)
    {
        if (mass + this.ProductMass > this.Temperature)
        {
            throw new OverfillException();
        }
        Product? product = findProduct(productName);
        if (product == null)
        {
            double productTemperature = 0;
            foreach (Product p in PossibleProducts)
            {
                if (p.Name == productName)
                {
                    productTemperature = p.MinimalTemperature;
                    if (productTemperature < Temperature)
                    {
                        throw new TooHighTemperatureException();
                    }
                    Products.Add(new Product(productName, productTemperature), mass);
                }
            }
        }
        this.Products[product] += mass;
    }

    private Product? findProduct(string productName)
    {
        foreach (Product product in Products.Keys)
        {
            if (product.Name == productName)
            {
                return product;
            }    
        }
        return null;
    }

    public override int EmptyLoad()
    {
        int mass = this.ProductMass;
        Products.Clear();
        this.ProductMass = 0;
        return mass;
    }

    public override void AddMass(int mass)
    {
        if (mass * Products.Count + this.ProductMass > this.MaxLoad )
        {
            throw new OverfillException();
        }
        else
        {
            foreach (Product product in Products.Keys)
            {
                Products[product] += mass;                
            }
        }
    }

    public void AddMass(int mass, string productName)
    {
        if (mass + this.ProductMass > this.MaxLoad)
        {
            throw new OverfillException();
        }

        Product? product = findProduct(productName);
        
        if (product == null)
        {
            throw new NullReferenceException("such product doesn't exist");
        }
        Products[product] += mass;
    }

    public void EmptyLoad(int mass, string productName)
    {
        Product? product = findProduct(productName);
        
        if (product == null)
        {
            throw new NullReferenceException("such product doesn't exist");
        }
        Products.Remove(product);
        this.ProductMass -= mass;
    }
}