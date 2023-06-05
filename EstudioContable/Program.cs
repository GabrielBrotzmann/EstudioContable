using System;
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
                        "1: Ingresar Empleado \n " +
                        "2: Consultar Empleado \n " +
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
                            int id = opcion;
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

                            Console.WriteLine("Ingrese el cuil del nuevo empleado sin guiones:");
                            if (!long.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("El cuil debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (opcion < 0)
                            {
                                Console.WriteLine("Ha ocurrido un error, vuelva a intentarlo");
                                break;
                            }
                            long cuil = opcion;
                            opcion = -1;

                            Console.WriteLine("Ingrese la fecha de nacimiento del nuevo empleado en formato DD/MM/YYYY:");
                            string fnac = Console.ReadLine();
                            DateTime fNac = DateTime.Parse(fnac);

                            DateTime fAlta = DateTime.Today();


                            negocio.AltaEmpleado(id,idCategoria,idEmpresa,nombre,apellido,cuil,fNac, fAlta, true);

                            Console.WriteLine("El empleado ha sido agregado");
                            break;


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
                            int id = opcion;
                            opcion = -1;

                            Console.WriteLine("Ingrese la razon social del nuevo cliente:");
                            string razSoc = Console.ReadLine();

                            Console.WriteLine("Ingrese el cuil del nuevo cliente sin guiones:");
                            if (!long.TryParse(Console.ReadLine(), out opcion))
                            {
                                Console.WriteLine("El cuil del cliente debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            if (opcion < 0)
                            {
                                Console.WriteLine("El cuil del cliente debe ser numerico, vuelva a intentarlo");
                                break;
                            }
                            long cuil = opcion;
                            opcion = -1;

                            Console.WriteLine("Ingrese el domicilio del cliente");
                            string dom = Console.ReadLine();

                            DateTime fAlta = DateTime.Today();

                            int idEmpl;
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
                                idEmp = opcion;
                            }
                            else { Console.WriteLine("El id ingresado no corresponde a ningun empleado")}
                            opcion = -1;

                            negocio.AltaEmpresa(razSoc, cuil, dom, fAlta, idEmpl, id);
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
                            if (negocio.ValidarEmpresaExistente)
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
