namespace DeafoultNamespace;

public abstract class Container
{
    
    public int ProductMass { get; set; }
    public int Height { get; set; }
    public int EmptyMass { get; set; }
    public int Depth { get; set; }
    public ContainerId ContainerId { get; }
    public string ContainerCategory { get; protected set; }
    public int ContainerIdNum { get; protected set; }

    public int MaxLoad { get; set; }

    public abstract int NextSerialNumber();
    
    public abstract ContainerId CreateContainerID();
    
    public int EmptyLoad()
    {
        this.ProductMass = 0;
        return this.EmptyMass;
    }

    public void AddMass(int mass)
    {
        if (this.ProductMass + mass > this.MaxLoad)
        {
            throw new OverfillException();
        }
        
        this.ProductMass += mass;
    }

    public Container(int emptyMass, int height, int depth)
    {
        this.ProductMass = 0;
        this.EmptyMass = emptyMass;
        this.Height = height;
        this.Depth = depth;
    }
    
    
}