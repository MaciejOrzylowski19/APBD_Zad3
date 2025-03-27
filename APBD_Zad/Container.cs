namespace DeafoultNamespace;

public abstract class Container
{
    
    public virtual int ProductMass { get; set; }
    public int Height { get; set; }
    public int EmptyMass { get; set; }
    public int Depth { get; set; }
    public ContainerId ContainerId { get; protected set; }
    public string ContainerCategory { get; protected set; }
    public int ContainerIdNum { get; protected set; }

    public int MaxLoad { get; set; }

    public abstract int NextSerialNumber();
    
    public abstract ContainerId CreateContainerID();
    
    public virtual int EmptyLoad()
    {
        this.ProductMass = 0;
        return ProductMass;
    }

    public virtual void AddMass(int mass)
    {
        if (this.ProductMass + mass > this.MaxLoad)
        {
            throw new OverfillException();
        }
        
        this.ProductMass += mass;
    }

    public Container(int emptyMass, int maxLoad, int height, int depth)
    {
        this.ProductMass = 0;
        this.EmptyMass = emptyMass;
        this.Height = height;
        this.Depth = depth;
        this.MaxLoad = maxLoad;
    }

    public override string ToString()
    {
        String target = "Container id: " + ContainerId + '\n' +
                        "self mass: " + EmptyMass + '\n' +
                        "mass: " + ProductMass + "\n" +
                        "max load: " + MaxLoad + "\n" +
                        "depth: " + Depth + "\n" +
                        "height: " + Height + "\n";
        return target;
    }
    
}