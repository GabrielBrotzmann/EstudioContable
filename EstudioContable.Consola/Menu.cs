using System;
using System.Collections.Generic;
using System.Text;
using EstudioContable.Entidades;
using EstudioContable.Negocio;
using EstudioContable.Utilidades;

namespace EstudioContable
{
    public class Menu
    {
        private readonly EmpleadoNegocio _empleadoNegocio;
        private readonly EmpresaNegocio _empresaNegocio;
        private readonly LiquidacionNegocio _liquidacionNegocio;
        private readonly CategoriaNegocio _categoriaNegocio;

        public Menu(EmpleadoNegocio empleadoNegocio, EmpresaNegocio empresaNegocio, LiquidacionNegocio liquidacionNegocio, CategoriaNegocio categoriaNegocio)
        {
            _empleadoNegocio = empleadoNegocio;
            _empresaNegocio = empresaNegocio;
            _liquidacionNegocio = liquidacionNegocio;
            _categoriaNegocio = categoriaNegocio;
        }

        public void IngresarEmpleado()
        {
            Console.WriteLine("Ingrese el id del nuevo empleado:");
            int idEmpleado = Consola.ReadIntFromConsole();
            if (idEmpleado == -1) return;

            Console.WriteLine("Ingrese el id de la categoria del nuevo empleado:");
            int idCategoria = Consola.ReadIntFromConsole();
            if (idCategoria == -1) return;
            if (!_categoriaNegocio.ValidarCategoriaExistente(idCategoria))
            {
                Console.WriteLine("No se encontro la categoria, vuelva a intentarlo");
                return;
            }

            Console.WriteLine("Ingrese el id de la empresa del nuevo empleado:");
            int idEmpresa = Consola.ReadIntFromConsole();
            if (idEmpresa == -1) return;
            if (!_empresaNegocio.ValidarEmpresaExistente(idEmpresa))
            {
                Console.WriteLine("No se encontro la categoria, vuelva a intentarlo");
                return;
            }

            Console.WriteLine("Ingrese el nombre del nuevo empleado:");
            string nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido del nuevo empleado:");
            string apellido = Console.ReadLine();

            Console.WriteLine("Ingrese el cuit del nuevo empleado sin guiones:");
            long cuitIngresado = Consola.ReadLongFromConsole();
            if (cuitIngresado == -1) return;

            Console.WriteLine("Ingrese la fecha de nacimiento del nuevo empleado en formato DD/MM/YYYY:");
            string fnac = Console.ReadLine();
            DateTime fNac = DateTime.Parse(fnac);


            _empleadoNegocio.AltaEmpleado(idEmpleado, idCategoria, idEmpresa, nombre, apellido, cuitIngresado, fNac,
                DateTime.Today, true);

            Console.WriteLine("El empleado ha sido agregado");
        }

        public void ConsultarEmpleado()
        {
            Console.WriteLine("Ingrese el id del empleado:");
            int idEmpleado = Consola.ReadIntFromConsole();
            if (idEmpleado == -1) return;
            if (!_empleadoNegocio.ValidarEmpleadoExistente(idEmpleado))
            {
                return;
            }

            Empleado emp = _empleadoNegocio.GetByIdEmpleado(idEmpleado);
            Console.WriteLine(emp.ToString());
        }

        public void ConsultarEmpresaPorEmpleado()
        {
            Console.WriteLine("Ingrese el id del nuevo cliente:");
            int idCliente = Consola.ReadIntFromConsole();
            if (idCliente == -1) return;
            if (_empresaNegocio.ValidarEmpresaExistente(idCliente))
            {
                Console.WriteLine("Ya existe un cliente con ese id, pruebe con otro");
            }

            Console.WriteLine("Ingrese la razon social del nuevo cliente:");
            string razSoc = Console.ReadLine();

            Console.WriteLine("Ingrese el cuil del nuevo cliente sin guiones:");
            long cuil = Consola.ReadLongFromConsole();

            if (cuil == -1) return;
            Console.WriteLine("Ingrese el domicilio del cliente");
            string dom = Console.ReadLine();

            int idEmpl = 0;
            Console.WriteLine("Ingrese el id del empleado asignado al cliente:");
            int idEmpleado = Consola.ReadIntFromConsole();
            if (idEmpleado == -1) return;
            if (!_empleadoNegocio.ValidarEmpleadoExistente(idEmpleado))
            {
                Console.WriteLine("El id ingresado no corresponde a ningun empleado");
                return;
            }

            _empresaNegocio.AltaEmpresa(razSoc, cuil, dom, DateTime.Today, idEmpl, idCliente);
            Console.WriteLine("El cliente fue ingresado con exito");
        }

        public void IngresarEmpresaPorEmpleado()
        {
            Console.WriteLine("Ingrese el id de la empresa:");
            int idEmpresa = Consola.ReadIntFromConsole();
            if (idEmpresa == -1) return;
            if (!_empresaNegocio.ValidarEmpresaExistente(idEmpresa))
            {
                Console.WriteLine("El id ingresado no corresponde a ninguna empresa");
                return;
            }

            Empresa emp = _empresaNegocio.GetByIdEmpresa(idEmpresa);
            Console.WriteLine(emp.ToString());
        }

        public void ConsultarLiquidacionesPorEmpleado()
        {
            Console.WriteLine("Ingrese el id del empleado:");
            int idEmpleado = Consola.ReadIntFromConsole();
            if (idEmpleado == -1) return;
            Console.WriteLine(_liquidacionNegocio.GetLiquidacionByEmpleado(idEmpleado));
        }

        public void IngresarLiquidacionesPorEmpleado()
        {
            Console.WriteLine("Ingrese el id del empleado:");
            int idEmpleado = Consola.ReadIntFromConsole();
            if (idEmpleado == -1) return;
            //TODO: Agregar validaciones
            Console.WriteLine("Ingrese el periodo de la liquidacion:");
            int periodo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese el codigo de transferencia:");
            string codtransferencia = Console.ReadLine();
            Console.WriteLine("Ingrese el salario bruto:");
            double bruto = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Ingrese el descuento:");
            int descuento = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingrese la fecha de alta:");
            DateTime fechaalta = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Ingrese el id:");
            int id = Convert.ToInt32(Console.ReadLine());

            _liquidacionNegocio.AltaLiquidacion(idEmpleado, periodo, codtransferencia, bruto, descuento, fechaalta, id);
        }

        public void ConsultarCategoriasPorEmpleado()
        {
            //TODO
            throw new NotImplementedException();
        }

        public void IngresarCategoriasPorEmpleado()
        {
            //TODO
            throw new NotImplementedException();
        }

        public void ReporteDeEmpleadosPorEmpresa()
        {
            Console.WriteLine("Ingrese el id de la empresa:");
            int idEmpresa = Consola.ReadIntFromConsole();
            if (idEmpresa == -1) return;
            StringBuilder reporte = new StringBuilder();
            List<Empleado> empleados = _empleadoNegocio.GetEmpleadosByEmpresa(idEmpresa);
            foreach (Empleado empleado in empleados)
            {
                reporte.Append(empleado + "\n");
            }

            Console.WriteLine(reporte);
        }

        public void ReporteDeLiquidacionesPorCategoria()
        {
            Console.WriteLine("Ingrese el id de la categoria:");
            int idCategoria = Consola.ReadIntFromConsole();
            if (idCategoria == -1) return;
            StringBuilder reporte = new StringBuilder();
            List<Empleado> empleados = _empleadoNegocio.GetEmpleadosByCategoria(idCategoria);
            List<Liquidacion> liquidacions = _liquidacionNegocio.GetLiquidacionesByEmpleados(empleados);
            foreach (Liquidacion liquidacion in liquidacions)
            {
                reporte.Append(liquidacion + "\n");
            }

            Console.WriteLine(reporte);
        }
    }
}