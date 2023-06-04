using System;

namespace EstudioContable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menu
            bool programa = true;

            do {
                bool menu = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine(
                        "Menu principal: \n " +
                        "1: Consultar Clientes \n " +
                        "2: Comenzar selección por Roberto \n " +
                        "3: Mostrar en pantalla cuantas personas fueron entrevistadas \n " +
                        "4: Mostrar en pantalla cuantas personas fueron seleccionados positivamente \n " +
                        "5: Mostrar en pantalla el promedio de sueldos de las personas seleccionadas \n " +
                        "0: Salir");

                    int opcion = -1;

                    do
                    {
                        if (!int.TryParse(Console.ReadLine(), out opcion))
                        {
                            opcion = -1;
                        }
                        if (opcion < 0)
                        {
                            Console.WriteLine("El valor ingresado no es válido, intente nuevamente ingresando una de las opciones");
                        }
                    } while (opcion < 0);

                    switch (opcion)
                    {
                        case 1:
                            
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 0:
                            menu = false;
                            programa = false;
                            break;
                        default:
                            Console.WriteLine("Opcion invalida, intente nuevamente");
                            Console.WriteLine("Presione enter para continuar");
                            Console.ReadKey();
                            break;
                    }
                } while (menu);
                Console.ReadKey();
            } while (programa);

        }
    }
}
