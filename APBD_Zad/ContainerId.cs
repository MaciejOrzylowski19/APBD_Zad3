namespace DeafoultNamespace;

public class ContainerId
{
    private string ContainerHead { get;}
    private int ContainerNumber { get;}
    private string ContainerTail { get;}


    public ContainerId(int containerNumber, string containerTail)
    {
        ContainerHead = "KON";
        ContainerNumber = containerNumber;
        ContainerTail = containerTail;

    }

    public string GetContainerId()
    {
        return ContainerHead + "-" + ContainerNumber.ToString() + "-" + ContainerTail;
    }

    public override string ToString()
    {
        return GetContainerId();
    }

}