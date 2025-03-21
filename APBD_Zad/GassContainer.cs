namespace DeafoultNamespace;

public class GassContainer : Container, IHazard
{
    
    private static int _gassCounter = 0;

    public override int NextSerialNumber()
    {
        _gassCounter++;
        return _gassCounter;
    }

    public override ContainerId CreateContainerID()
    {
        return new ContainerId(this.)
    }

    public GassContainer(int emptyMass, int height, int depth, bool hazard) : base(emptyMass, height, depth)
    {
        
        
        
    }
    
}