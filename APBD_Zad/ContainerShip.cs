﻿namespace DeafoultNamespace;

public class ContainerShip
{

    private static int shipId = 0;
    public int MaxLoad { get;  }
    public double MaxSpeed { get; }
    public int MaxCapacity { get; }
    
    public int ShipId { get; }
    public int Mass { get; private set; }

    public HashSet<Container> Containers { get; } = new HashSet<Container>();

    public ContainerShip(int maxLoad, double maxSpeed, int maxCapacity)
    {
        MaxLoad = maxLoad;
        MaxSpeed = maxSpeed;
        MaxCapacity = maxCapacity;
        Mass = 0;
        ShipId = ++shipId;
    }

    public Container? GetContainerById(string id)
    {
        foreach (Container container in Containers)
        {
            if (container.ContainerId.GetContainerId() == id)
            {
                return container;
            }
        }
        return null;
    }

    public void RemoveContainer(string containerId)
    {
        Container? container = GetContainerById(containerId);
        if (container == null)
        {
            throw new IndexOutOfRangeException("No such container");
        }

        Mass -= container.ProductMass - container.EmptyMass;
        Containers.Remove(container);
    }
    
    public void AddContainer(Container container)
    {
        if (container.ProductMass + Mass + container.EmptyMass > MaxLoad || Containers.Count == MaxCapacity)
        {
            throw new OverfillException();
        }

        Containers.Add(container);
    }
    public void AddContainer(List<Container> containers)
    {
        int conMass = 0;
        foreach (Container container in containers)
        {
            conMass += (container.ProductMass + container.EmptyMass);
        }
        
        if (conMass + Mass > MaxLoad || containers.Count + Containers.Count > MaxCapacity)
        {
            throw new OverfillException();
        }

        foreach (Container con in containers)
        {
            Containers.Add(con);
        }
    }

    public void EmptyContainers()
    {
        Containers.Clear();
        Mass = 0;
    }

    public void ChangeContainer(Container container, string toChange)
    {
        Container? toChangeContainer = GetContainerById(toChange);
        if (toChangeContainer == null)
        {
            throw new IndexOutOfRangeException("No such container found");
        }
        if (container.ProductMass + Mass  + container.EmptyMass - toChangeContainer.ProductMass - toChangeContainer.EmptyMass> MaxLoad)
        {
            Containers.Remove(toChangeContainer);
            Containers.Add(container);
        }
    }

    public void MoveContainer(string container, ContainerShip ship)
    {
        Container? toChangeContainer = GetContainerById(container);
        if (toChangeContainer == null)
        {
            throw new IndexOutOfRangeException("No such container found");
        }

        if (ship.Containers.Count == ship.MaxCapacity || ship.Mass + toChangeContainer.ProductMass + toChangeContainer.EmptyMass > ship.MaxLoad)
        {
            throw new OverfillException();
        }
        
        this.RemoveContainer(container);
        ship.AddContainer(toChangeContainer);
    }

    public void ChangeContainerTo(ContainerShip ship, string containerFrom, string containerTo)
    {

        Container cFrom;
        Container cTo;
        
        try
        {
            cFrom = this.GetContainerById(containerFrom); 
             cTo = ship.GetContainerById(containerTo);
            
        }
        catch (Exception e)
        {
            throw new Exception($"Unable to change container to {containerFrom} - {containerTo}", e);   
        }

        try
        {
            this.RemoveContainer(containerFrom);
            this.AddContainer(cTo);
        }
        catch (Exception e)
        {
            this.RemoveContainer(containerTo);
            this.AddContainer(cFrom); 
            
            throw new Exception($"Unable to change container to {containerFrom} - {containerTo}", e);   
        }

        try
        {
            ship.RemoveContainer(containerTo);
            ship.AddContainer(cFrom);
        }
        catch (Exception e)
        {
            this.RemoveContainer(containerTo);
            this.AddContainer(cFrom); 
            
            ship.RemoveContainer(containerFrom);
            ship.AddContainer(cTo);
            
            throw new Exception($"Unable to change container to {containerFrom} - {containerTo}", e);   
        }
        
    }

    public override string ToString()
    {
        return "ID: " + ShipId + "  Mass: " + Mass + "  Capacity: " + MaxCapacity + "  Max speed: " + MaxSpeed;
    }

    public void CargoInfo()
    {

        foreach (Container container in Containers)
        {
            Console.WriteLine(container);
            Console.WriteLine("\n");
        }
        
    }
}