using System;

namespace EstudioContable.Utilidades
{
    public class Consola
    {
        public static int ReadIntFromConsole()
        {
            if (int.TryParse(Console.ReadLine(), out int value) && value > 0)
            {
                return value;
            }
            Console.WriteLine("El valor ingresado debe ser numerico mayor que cero, vuelva a intentarlo");
            return -1;
        }
        
        public static long ReadLongFromConsole()
        {
            if (long.TryParse(Console.ReadLine(), out long value) || value < 0)
            {
                return value;
            }
            Console.WriteLine("El valor ingresado debe ser numerico mayor que cero, vuelva a intentarlo");
            return -1;
        }
    }
}