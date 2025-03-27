// See https://aka.ms/new-console-template for more information

namespace DeafoultNamespace
{


    public class MainClass
    {

        public static void Main(string[] args)
        {
            LiquidContainer lCon = new LiquidContainer(30, 60,3, 1, true);
            
            lCon.AddMass(20);
            System.Console.WriteLine(lCon);
            LiquidContainer lCon2 = new LiquidContainer(30, 60,3, 1, true);
            
            System.Console.WriteLine(lCon2);
            
            List<Container> containers = new List<Container>();
            containers.Add(new FreezerContainer(10, 200, 10, 5, -10));
            containers.Add(new FreezerContainer(10, 200, 10, 5, 10));
            containers.Add(new FreezerContainer(10, 200, 10, 5, 20));
            containers.Add(new GassContainer(4, 10, 4, 2, false));
            containers.Add(new GassContainer(4, 30, 4, 2, true));

            ContainerShip ship1 = new ContainerShip(5500, 10, 20);
            ContainerShip ship2 = new ContainerShip(63300, 10, 6);

            foreach (Container container in containers)
            {
                Console.WriteLine(container);
            }
            Console.WriteLine(ship1);
            Console.WriteLine(ship2);
            Console.WriteLine("\n");
            ship1.AddContainer(lCon);
            ship2.AddContainer(containers);
            
            ship1.CargoInfo();
            ship2.CargoInfo();
            
            
        }
        
    }
}