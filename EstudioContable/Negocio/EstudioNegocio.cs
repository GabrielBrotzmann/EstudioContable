using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using EstudioContable.AccesoDatos;
using EstudioContable.Entidades;
using EstudioContable.Utilidades;

namespace EstudioContable.Negocio
{
    public class EstudioNegocio
    {
        private readonly EmpleadoDatos _empleadoDatos;
        private readonly EmpresaDatos _empresaDatos;
        private readonly CategoriaDatos _categoriaDatos;
        private readonly LiquidacionDatos _liquidacionDatos;

        public EstudioNegocio(EmpleadoDatos empleadoDatos, EmpresaDatos empresaDatos, CategoriaDatos categoriaDatos, LiquidacionDatos liquidacionDatos)
        {
            _empleadoDatos = empleadoDatos;
            _empresaDatos = empresaDatos;
            _categoriaDatos = categoriaDatos;
            _liquidacionDatos = liquidacionDatos;
        }

        //Listas
        public List<Empleado> GetListaEmpleados()
        {
            return _empleadoDatos.TraerTodos();
        }
        public List<Empresa> GetListaEmpresa()
        {
            List<Empresa> list = _empresaDatos.TraerTodosEmpresa();

            return list;
        }
        public List<Categoria> GetListaCategoria()
        {
            List<Categoria> list = _categoriaDatos.TraerTodos();

            return list;
        }
        public List<Liquidacion> GetListaLiquidacion()
        {
            List<Liquidacion> list = _liquidacionDatos.TraerTodos();

            return list;
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


        // Get by Id
        
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
        public Empresa GetByIdEmpresa(int idEmpresa)
        {
            
            foreach (var item in GetListaEmpresa())
            {
                if (idEmpresa == item.Id)
                    return item;
            
            }

            return null;
        }
        public Categoria GetByIdCategoria(int idCategoria)
        {
           
            foreach (var item in GetListaCategoria())
            {
                if (idCategoria == item.Id)
                    return item;
                
            }

            return null;
        }

        public Liquidacion GetByIdLiquidacion(int idLiquidacion)
        {
           
            foreach (var item in GetListaLiquidacion())
            {
                if (idLiquidacion == item.Id)
                    return item;
                
            }

            return null;
        }
        
        public List<Liquidacion> GetLiquidacionByEmpleado(int idEmpleado)
        {
            List<Liquidacion> liquidacionPorEmpleado = new List<Liquidacion>();
            List<Liquidacion> liquidaciones = _liquidacionDatos.TraerTodos();
            foreach (Liquidacion liquidacion in liquidaciones)
            {
                if (liquidacion.EsDeEmpleado(idEmpleado))
                {
                    liquidacionPorEmpleado.Add(liquidacion);
                }
            }

            return liquidacionPorEmpleado;
        }

        public Categoria TraerCategoria(Categoria categoria)
        {
            return _categoriaDatos.TraerPorIdCategoria(categoria.Id);
        }
        public Liquidacion TraerLiquidacion(Liquidacion liquidacion)
        {
            return _liquidacionDatos.TraerPorIdLiquidacion(liquidacion.Id);
        }

        //Altas
        public void AltaEmpleado(int id, int idCategoria, int idEmpresa, string nombre, string apellido, long cuil, DateTime fnac, DateTime fechaAlta, bool activo)
        {
            Empleado empleado = new Empleado(id,idEmpresa,nombre,apellido, idCategoria, cuil,fnac,fechaAlta, true);

            Response transaction = _empleadoDatos.Insertar(empleado);



            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }
        public void AltaEmpresa(string razonSocial, long cuit, string domicilio, DateTime fechaAlta, int usuario, int id)
        {
            Empresa empresa = new Empresa(razonSocial,cuit,domicilio,fechaAlta,usuario,id);

            Response transaction = _empresaDatos.InsertarEmpresa(empresa);



            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }
             

        public void AltaCategoria(string nombre, string convenio, double sueldoBasico, int id)
        {
            Categoria categoria = new Categoria(nombre, convenio, sueldoBasico, id);

            Response transaction = _categoriaDatos.InsertarCategoria(categoria);


            if (!transaction.IsOk)
                throw new Exception(transaction.Error);

        }
                       
        public void AltaLiquidacion(int idEmpleado, int periodo, string codigoTransferencia, double bruto, double descuentos, DateTime fechaAlta, int id)
        {
            Liquidacion liquidacion = new Liquidacion(idEmpleado, periodo, codigoTransferencia, bruto, descuentos,fechaAlta, id);

            Response transaction = _liquidacionDatos.InsertarLiquidacion(liquidacion);


            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }



        //Reportes
        public string ReporteGetByIdEmpresa(int idEmpresa)
        {
            StringBuilder reporte = new StringBuilder();
            List<Empleado> empleados = GetListaEmpleados();
            foreach(Empleado e in empleados)
            {
                if(idEmpresa == e.IdEmpresa)
                {
                    reporte.Append(e + "\n");
                }
            }
            return reporte.ToString();
        }

        
        public string ReporteGetByIdCategoria(int idCategoria)
        {
            StringBuilder reporte = new StringBuilder();
            List<Liquidacion> liquidaciones = GetListaLiquidacion();
            List<Empleado> empleados = GetEmpleadosByCategoria(idCategoria);
            {
                foreach (Liquidacion liquidacion in liquidaciones)
                {
                    foreach (Empleado empleado in empleados)
                    {
                        if (liquidacion.EsDeEmpleado(empleado.Id))
                        {
                            reporte.Append(liquidacion + "\n");
                        }
                    }
                }
                return reporte.ToString();
            }
        }
        #endregion

        //Validaciones
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
        public bool ValidarEmpresaExistente(int id)
        {
            bool resultado = false;
            List<Empresa> listadoEmpresas = GetListaEmpresa();

            foreach (Empresa emp in listadoEmpresas)
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
        public bool ValidarCategoriaExistente(int id)
        {
            bool resultado = false;
            List<Categoria> listadoCategorias = GetListaCategoria();

            foreach (Categoria categoria in listadoCategorias)
            {
                if (categoria.Id == id)
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
        public bool ValidarLiquidacionExistente(int id)
        {
            bool resultado = false;
            List<Liquidacion> listadoLiquidaciones = GetListaLiquidacion();

            foreach (Liquidacion liquidacion in listadoLiquidaciones)
            {
                if (liquidacion.Id == id)
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
