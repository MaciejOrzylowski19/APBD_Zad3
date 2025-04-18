﻿namespace DeafoultNamespace;

public class FreezerContainer : Container
{

    private static int _seriaNumber = 0;
    
    public Dictionary<Product, int> Products { get; set; } = new Dictionary<Product, int>();
    public SortedSet<Product> PossibleProducts { get; set;}

    private double Temp { get; set; }
    public double Temperature
    {
        get
        {
            return Temp;
        }
        
        set
        {
            if (Products.Count == 0)
            {   
                Temp = value;
                return;
            }

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
            Temp = value;
            return;
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


    public FreezerContainer(int emptyMass, int maxLoad,int height, int depth, SortedSet<Product> possibleProducts, double temperature)
        : base(emptyMass, maxLoad,height, depth)
    {
        this.PossibleProducts = possibleProducts;
        Temperature = temperature;
        this.ContainerCategory = "F";
        ContainerId = CreateContainerID();
    }

    public FreezerContainer(int emptyMass, int maxLoad,  int height, int depth, double temperature) : base(emptyMass, maxLoad,height, depth)
    {
        this.PossibleProducts = new SortedSet<Product>();
        Temperature = temperature;
        this.ContainerCategory = "F";
        ContainerId = CreateContainerID();
    }
    
    
    public void LoadProduct(string productName, int mass)
    {
        if (mass + this.ProductMass > this.MaxLoad)
        {
            throw new OverfillException();
        }
        Product? product = findProduct(productName);
        
        if (product != null)
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
    }

    private Product? findProduct(string productName)
    {
        
        foreach (Product product in PossibleProducts)
        {
            if (product.Name.Equals(productName))
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
        
        //Console.WriteLine(Products.Count);        
        
        foreach (Product p in Products.Keys)
        {
            if (p.Equals(product))
            {
                Products[p] += mass;
                return;
            }
        }
        
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
    public override string ToString()
    {
        String target = base.ToString();
        target += "Products: \n";
        foreach (Product product in Products.Keys)
        {
            target += product.ToString() + ":  mass - " + Products[product].ToString() + "  temp -  " + product.MinimalTemperature;
        }
        return target;
    }
    
}