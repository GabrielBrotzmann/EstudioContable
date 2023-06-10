﻿using System;
using EstudioContable.AccesoDatos;
using EstudioContable.Entidades;
using EstudioContable.Negocio;

namespace EstudioContable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var negocio = new EstudioNegocio(new EmpleadoDatos(), new EmpresaDatos(), new CategoriaDatos(), new LiquidacionDatos());
            
                bool menu = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine(Textos.Menu);
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
                            Console.WriteLine("Ingrese el id del nuevo empleado:");
                            if (!int.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("El id del empleado debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (opcion < 0)
                            {
                                Console.WriteLine("El id del empleado debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            int idEmpleado = opcion;
                            opcion = -1;

                            Console.WriteLine("Ingrese el id de la categoria del nuevo empleado:");
                            if (!int.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("El id debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (opcion < 0)
                            {
                                Console.WriteLine("El id debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (!negocio.ValidarCategoriaExistente(opcion))
                            {
                                Console.WriteLine("No se encontro la categoria, vuelva a intentarlo");
                                break;
                            }
                            int idCategoria = opcion;
                            opcion = -1;

                            Console.WriteLine("Ingrese el id de la empresa del nuevo empleado:");
                            if (!int.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("El id debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (opcion < 0)
                            {
                                Console.WriteLine("El id debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (!negocio.ValidarEmpresaExistente(opcion))
                            {
                                Console.WriteLine("No se encontro la categoria, vuelva a intentarlo");
                                break;
                            }
                            int idEmpresa = opcion;
                            opcion = -1;

                            Console.WriteLine("Ingrese el nombre del nuevo empleado:");
                            string nombre = Console.ReadLine();

                            Console.WriteLine("Ingrese el apellido del nuevo empleado:");
                            string apellido = Console.ReadLine();

                            Console.WriteLine("Ingrese el cuit del nuevo empleado sin guiones:");
                            long cuitIngresado = -1;
                            if (!long.TryParse(Console.ReadLine(), out cuitIngresado))
                            {
                                Console.WriteLine("El cuil debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (cuitIngresado < 0)
                            {
                                Console.WriteLine("Ha ocurrido un error, vuelva a intentarlo");
                                break;
                            }
                            long cuit = cuitIngresado;
                            opcion = -1;

                            Console.WriteLine("Ingrese la fecha de nacimiento del nuevo empleado en formato DD/MM/YYYY:");
                            string fnac = Console.ReadLine();
                            DateTime fNac = DateTime.Parse(fnac);

                            DateTime fAlta = DateTime.Today;
                            
                            negocio.AltaEmpleado(idEmpleado,idCategoria,idEmpresa,nombre,apellido,cuit,fNac, fAlta, true);

                            Console.WriteLine("El empleado ha sido agregado");
                            break;
                        case 2:
                            Console.WriteLine("Ingrese el id del empleado:");
                            if (!int.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("El id del empleado debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (opcion < 0)
                            {
                                Console.WriteLine("El id del empleado debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if(negocio.ValidarEmpleadoExistente(opcion))
                            {
                                Empleado emp = negocio.GetByIdEmpleado(opcion);
                                Console.WriteLine(emp.ToString());
                                break;
                            }

                            break;
                        case 3:
                            Console.WriteLine("Ingrese el id del nuevo cliente:");
                            if (!int.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("El id del cliente debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (opcion < 0)
                            {
                                Console.WriteLine("El id del cliente debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (negocio.ValidarEmpresaExistente(opcion))
                            {
                                Console.WriteLine("Ya existe un cliente con ese id, pruebe con otro");
                            }
                            int idCliente = opcion;
                            opcion = -1;

                            Console.WriteLine("Ingrese la razon social del nuevo cliente:");
                            string razSoc = Console.ReadLine();

                            long cuilIngresado = -1;
                            Console.WriteLine("Ingrese el cuil del nuevo cliente sin guiones:");
                            if (!long.TryParse(Console.ReadLine(), out cuilIngresado))
                            {
                                Console.WriteLine("El cuil del cliente debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (cuilIngresado < 0)
                            {
                                Console.WriteLine("El cuil del cliente debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            long cuil = cuilIngresado;
                            opcion = -1;

                            Console.WriteLine("Ingrese el domicilio del cliente");
                            string dom = Console.ReadLine();

                            DateTime fAlta2 = DateTime.Today;

                            int idEmpl = 0;
                            Console.WriteLine("Ingrese el id del empleado asignado al cliente:");
                            if (!int.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("El id del empleado debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (opcion < 0)
                            {
                                Console.WriteLine("El id del empleado debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (negocio.ValidarEmpleadoExistente(opcion))
                            {
                                idEmpl = opcion;
                            }
                            else
                            {
                                Console.WriteLine("El id ingresado no corresponde a ningun empleado");
                            }
                            opcion = -1;
                            negocio.AltaEmpresa(razSoc, cuil, dom, fAlta2, idEmpl, idCliente);
                            Console.WriteLine("El cliente fue ingresado con exito");
                            break;
                        case 4:
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
                            if (negocio.ValidarEmpresaExistente(opcion))
                            {
                                Empresa emp = negocio.GetByIdEmpresa(opcion);
                                Console.WriteLine(emp.ToString());
                                break;
                            }

                            break;
                        case 5:
                            Console.WriteLine("Ingrese el id del empleado:");
                            if (!int.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("El id debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (opcion < 0)
                            {
                                Console.WriteLine("El id debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            Console.WriteLine(negocio.GetLiquidacionByEmpleado(opcion));
                            break;
                        case 6:
                            Console.WriteLine("Ingrese el id del empleado:");
                            if (!int.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("El id debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (opcion < 0)
                            {
                                Console.WriteLine("El id debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            //TODO: Agregar validaciones
                            int idempleado = opcion;
                            Console.WriteLine("Ingrese el periodo de la liquidacion:");
                            int periodo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese el codigo de transferencia:");
                            string codtransferencia = Console.ReadLine();
                            Console.WriteLine("Ingrese el salario bruto:");
                            double bruto = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Ingrese el descuento:");
                            int descuento = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Ingrese la fecha de alta:");
                            DateTime fechaalta= Convert.ToDateTime(Console.ReadLine());
                            Console.WriteLine("Ingrese el id:");
                            int id = Convert.ToInt32(Console.ReadLine());

                            negocio.AltaLiquidacion(idempleado, periodo, codtransferencia, bruto, descuento, fechaalta, id);
                            Console.WriteLine("Liquidación ingresada");
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
        }
    }
}
