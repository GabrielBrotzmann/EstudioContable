﻿using System;
using EstudioContable.AccesoDatos;
using EstudioContable.Negocio;

namespace EstudioContable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var negocio = new EstudioNegocio(new EmpleadoDatos(), new EmpresaDatos(), new CategoriaDatos(), new LiquidacionDatos());

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
                        "2: Ingresar Clientes \n " +
                        "3: Consultar empresa por empleado \n " +
                        "4: Ingresar empresa por empleado \n " +
                        "5: Consultar liquidaciones por empleado \n " +
                        "6: Ingresar liquidaciones por empleado \n " +
                        "7: Consultar categorias por empleado \n " +
                        "8: Ingresar categorias por empleado \n " +
                        "9: Reporte de empleados por empresa \n " +
                        "10: Reporte de las liquidaciones por categoria \n " +
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
                        case 9:
                            Console.WriteLine("Ingrese el id de la empresa:");
                            if (!int.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("El id de la empresa debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (opcion < 0)
                            {
                                Console.WriteLine("El id de la empresa debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            Console.WriteLine(negocio.ReporteGetByIdEmpresa(opcion));
                            break;
                        case 10:
                            Console.WriteLine("Ingrese el id de la categoria:");
                            if (!int.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("El id de la empresa debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (opcion < 0)
                            {
                                Console.WriteLine("El id de la empresa debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            Console.WriteLine(negocio.ReporteGetByIdCategoria(opcion));
                            break;
                        case 0:
                            return;
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
