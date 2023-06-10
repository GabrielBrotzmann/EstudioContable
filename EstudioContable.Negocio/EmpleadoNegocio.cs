using System;
using System.Collections.Generic;
using EstudioContable.AccesoDatos;
using EstudioContable.Entidades;

namespace EstudioContable.Negocio
{
    public class EmpleadoNegocio
    {
        private readonly EmpleadoDatos _empleadoDatos;

        public EmpleadoNegocio(EmpleadoDatos empleadoDatos)
        {
            _empleadoDatos = empleadoDatos;
        }

        public List<Empleado> GetListaEmpleados()
        {
            return _empleadoDatos.TraerTodos();
        }

        public List<Empleado> GetEmpleadosByCategoria(int idCategoria)
        {
            List<Empleado> empleadosPorCategoria = new List<Empleado>();
            List<Empleado> empleados = _empleadoDatos.TraerTodos();
            foreach (Empleado empleado in empleados)
            {
                if (empleado.EsCategoria(idCategoria))
                {
                    empleadosPorCategoria.Add(empleado);
                }
            }

            return empleadosPorCategoria;
        }

        public Empleado GetByIdEmpleado(int idEmpleado)
        {
            foreach (var item in GetListaEmpleados())
            {
                if (idEmpleado == item.Id)
                    return item;
            }

            return null;
        }

        public Empleado GetEmpleadoByIdEmpresa(int idEmpresa)
        {
            foreach (var item in GetListaEmpleados())
            {
                if (idEmpresa == item.Id)
                    return item;
            }

            return null;
        }

        public void AltaEmpleado(int id, int idCategoria, int idEmpresa, string nombre, string apellido, long cuil,
            DateTime fnac, DateTime fechaAlta, bool activo)
        {
            Empleado empleado = new Empleado(id, idEmpresa, nombre, apellido, idCategoria, cuil, fnac, fechaAlta, true);

            _empleadoDatos.Insertar(empleado);
        }

        public List<Empleado> GetEmpleadosByEmpresa(int idEmpresa)
        {
            List<Empleado> empleadosByEmpresa = new List<Empleado>();
            List<Empleado> empleados = GetListaEmpleados();
            foreach (Empleado e in empleados)
            {
                if (idEmpresa == e.IdEmpresa)
                {
                    empleadosByEmpresa.Add(e);
                }
            }

            return empleadosByEmpresa;
        }

        public bool ValidarEmpleadoExistente(int id)
        {
            bool resultado = false;
            List<Empleado> listadoEmpleados = GetListaEmpleados();

            foreach (Empleado emp in listadoEmpleados)
            {
                if (emp.Id == id)
                {
                    resultado = true;
                    break;
                }
                else
                {
                    resultado = false;
                }
            }

            return resultado;
        }
    }
}