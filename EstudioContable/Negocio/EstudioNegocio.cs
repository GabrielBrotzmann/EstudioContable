using System;
using System.Collections.Generic;
using EstudioContable.Entidades;

namespace EstudioContable.Negocio
{
    public class EstudioNegocio
    {
        public EmpleadoDatos _empleadoDatos;
        public EmpresaDatos _empresaDatos;
        public CategoriaDatos _categoriaDatos;
        public LiquidacionDatos _liquidacionDatos;

        public EstudioNegocio()
        {
            _empleadoDatos = new EmpleadoDatos();
            _empresaDatos = new EmpresaDatos();
            _categoriaDatos = new CategoriaDatos();
            _liquidacionDatos = new LiquidacionDatos();
        }

        #region Métodos para Listas
        public List<Empleado> GetListaEmpleados()
        {
            List<Empleado> list = _empleadoDatos.TraerTodos();

            return list;
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

        #endregion

        #region Métodos que devuelven Objetos

        public Categoria TraerCategoria(Categoria categoria)
        {
            // validar cliente no nulo

            return _categoriaDatos.TraerPorIdCategoria(categoria.Id);
        }
        public Liquidacion TraerLiquidacion(Liquidacion liquidacion)
        {
            // validar cliente no nulo

            return _liquidacionDatos.TraerPorIdLiquidacion(liquidacion.Id);
        }
        #endregion

        #region Métodos por Id


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


        #endregion

        #region Métodos de Altas
        public void AltaEmpleado(int id, int idCategoria, int idEmpresa, string nombre, string apellido, long cuil, DateTime fnac, DateTime fechaAlta, bool activo)
        {
            Empleado empleado = new Empleado(id,idEmpresa,nombre,apellido, idCategoria, cuil,fnac,fechaAlta, true);


            TransactionResult transaction = _empleadoDatos.Insertar(empleado);



            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }
        public void AltaEmpresa(string razonSocial, long cuit, string domicilio, DateTime fechaAlta, int usuario, int id)
        {
            Empresa empresa = new Empresa(razonSocial,cuit,domicilio,fechaAlta,usuario,id);

            TransactionResult transaction = _empresaDatos.InsertarEmpresa(empresa);



            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }
             

        public void AltaCategoria(string nombre, string convenio, double sueldoBasico, int id)
        {
            Categoria categoria = new Categoria(nombre, convenio, sueldoBasico, id);
           

            TransactionResult transaction = _categoriaDatos.InsertarCategoria(categoria);


            if (!transaction.IsOk)
                throw new Exception(transaction.Error);

        }
                       
        public void AltaLiquidacion(int idEmpleado, int periodo, string codigoTransferencia, double bruto, double descuentos, DateTime fechaAlta, int id)
        {
            Liquidacion liquidacion = new Liquidacion(idEmpleado, periodo, codigoTransferencia, bruto, descuentos,fechaAlta, id);


            TransactionResult transaction = _liquidacionDatos.InsertarLiquidacion(liquidacion);


            if (!transaction.IsOk)
                throw new Exception(transaction.Error);
        }

        #endregion

        #region Métodos Reportes
        //REPORTE EMPLEADO POR EMPRESA
        public List<Empleado> ReporteGetByIdEmpresa(int idEmpresa)
        {
            List<Empleado> empleados = new List<Empleado>();
            List<Empleado> _empleados = GetListaEmpleados();
            foreach(Empleado e in _empleados)
            {
                if(idEmpresa == e.IdEmpresa)
                {
                    empleados.Add(e);
                    
                }
            }
           if( empleados == null)
            {
                throw new Exception();
            }
            else
            {
                return empleados;
            }
           
        }

        //REPORTE LIQUIDACION POR CATEGORIA
    


        public List<Empleado> GetEmpleadoByIdCategoria(int idCategoria)
        {
            List<Empleado> empleados = new List<Empleado>();
            List<Empleado> _empleados = GetListaEmpleados();
            foreach (Empleado e in _empleados)
            {
                if (idCategoria == e.IdCategoria)
                {
                    empleados.Add(e);

                }
            }
            if (empleados == null)
            {
                throw new Exception();
            }
            else
            {
                return empleados;
            }

        }

        public List<Liquidacion> ReporteGetByIdCategoria(List<Empleado> empleados)
        {
            List<Liquidacion> liquidaciones = new List<Liquidacion>();
            List<Liquidacion> _liquidaciones = GetListaLiquidacion();

            {
                foreach(Empleado e in empleados)
                {

                    foreach (Liquidacion l in _liquidaciones)
                    {
                        if (e.Id == l.IdEmpleado)
                        {
                            liquidaciones.Add(l);

                        }
                    }
                  
                }
                if (liquidaciones == null)
                {
                    throw new Exception();
                }
                else
                {
                    return liquidaciones;
                }
            }


        }
        #endregion

        #region Métodos para Validar ID Existente
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
        #endregion

    }
}