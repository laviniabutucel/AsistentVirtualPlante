using System;

namespace AsistentVirtualPlante
{
    class Program
    {
        static void Main()
        {
            var plantaDefault = new Planta();
            Console.WriteLine(plantaDefault.Info());

            Planta planta1 = new Planta("Cactus", 7, 5, 4);
            Planta planta2 = new Planta("Orhidee", 3, 3, 4);

            Console.WriteLine(planta1.Info());
            Console.WriteLine(planta2.Info());

            // Crearea obiectului asistentului virtual și verificarea plantelor
            AsistentVirtual asistent = new AsistentVirtual();
            Console.WriteLine(asistent.VerificaPlanta(planta1));
            Console.WriteLine(asistent.VerificaPlanta(planta2));

            Console.ReadKey();
        }
    }
}
