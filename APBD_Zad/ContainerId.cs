namespace DeafoultNamespace;

public class ContainerId
{
    private string ContainerHead { get;}
    private int ContainerNumber { get;}
    private string ContainerTail { get;}


    public ContainerId(int containerNumber, string containerTail)
    {
        ContainerHead = "KON";
        containerNumber = containerNumber;
        containerTail = containerTail;

    }

    public string GetContainerId()
    {
        return ContainerHead + "-" + ContainerNumber.ToString() + "-" + ContainerTail;
    }

}