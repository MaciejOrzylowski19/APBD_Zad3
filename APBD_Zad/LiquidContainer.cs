namespace DeafoultNamespace;

public class LiquidContainer : Container, IHazard
{
    
    
    private static int _containerNumber = 0;
    
    public bool IsHazard { get; set; }
    public override int NextSerialNumber()
    {
        _containerNumber++;
        return _containerNumber;
    }

    public override ContainerId CreateContainerID()
    {
        return new ContainerId(this.ContainerIdNum, this.ContainerCategory);
    }

    public LiquidContainer(int emptyMass, int height, int depth, bool hazard) : base(emptyMass, height, depth)
    {
        this.IsHazard = hazard;
        this.ContainerIdNum = NextSerialNumber();
        this.ContainerCategory = "C";
        CreateContainerID();

    }

    public void Danger()
    {
        
        Console.WriteLine("Danger in LiquidContainer number: " + this.ContainerId.GetContainerId());
    }
    
    
}