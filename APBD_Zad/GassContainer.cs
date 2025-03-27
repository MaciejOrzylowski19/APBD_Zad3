namespace DeafoultNamespace;

public class GassContainer : Container, IHazard
{
    
    private static int _gassCounter = 0;
    
    public bool ISHazard { get;} 

    public override int NextSerialNumber()
    {
        _gassCounter++;
        return _gassCounter;
    }

    public override ContainerId CreateContainerID()
    {
        return new ContainerId(this.NextSerialNumber(), "G");
    }

    public void Danger()
    {
        Console.WriteLine("Danger in GasContainer " + ContainerId.GetContainerId());
    }

    public override int EmptyLoad()
    {
        ProductMass = ProductMass * 5 / 100;
        return ProductMass;
    }

    public GassContainer(int emptyMass, int height, int depth, bool hazard) : base(emptyMass, height, depth)
    {
        ISHazard = hazard;
    }
    
    
}